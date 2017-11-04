using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SHOOT.Common.Modules;

namespace SHOOT.Base
{
    public class DBHelper : IDisposable
    {
        //private LogHelper logHelper = new LogHelper();//日志管理
        public static string conString = ConfigurationManager.ConnectionStrings["Entities"].ToString();
        private SqlConnection mysqlCon = null;
        private SqlTransaction myTransaction = null;

        public DBHelper()
        {
            try
            {
                if (null == mysqlCon)
                    mysqlCon = new SqlConnection(conString);
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                if (mysqlCon.State != ConnectionState.Open)
                    mysqlCon.Open();
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (null == myTransaction)
                    if (mysqlCon.State == ConnectionState.Open)
                        mysqlCon.Close();
            }
            catch { }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="mysql">sql语句</param>
        /// <param name="conString">连接字符串</param>
        /// <returns>查询结果</returns>
        public DataTable GetData(string mysql)
        {
            DataTable dtResult = new DataTable();
            try
            {
                OpenConnection();
                using (SqlDataAdapter msda = new SqlDataAdapter(mysql, mysqlCon))
                {
                    msda.Fill(dtResult);
                }
            }
            catch (Exception ex)
            {
                //logHelper.WriteToLog("异常语句：" + mysql + "\r\n" + ex.Message.ToString());
                throw new Exception("异常语句：" + mysql + "\r\n" + ex.ToString());
            }
            finally { CloseConnection(); }
            return dtResult;
        }

        //added by Tianyf 20170725

        /// <summary>
        /// 更新model数据到表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update<T>(T model, string tableName, string keyName, string keyValue = "") where T : SHOOT.Model.Base.BaseModel
        {
            bool ret = false;

            #region 根据keyName获取主键 字段名称 和 字段值
            PropertyInfo[] properties = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0)
                return false;
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                string value = Convert.ToString(item.GetValue(model, null));
                if (name == keyName)
                {
                    keyValue = value;
                    break;
                }
            }
            #endregion

            string sql = string.Format("Select * From {0} Where {1}='{2}'", tableName, keyName, keyValue);
            SqlCommand selectCommand = new SqlCommand(sql, mysqlCon);

            if (null != myTransaction)
                selectCommand.Transaction = myTransaction;
            try
            {
                OpenConnection();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.SelectCommand = selectCommand;

                    DataTable dt = new DataTable();
                    DataRow dr;
                    bool isNew = false;
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                        dr = dt.Rows[0];
                    else
                    {
                        dr = dt.NewRow();
                        isNew = true;
                    }

                    //model到row的赋值
                    model.ToDataRow(ref dr);

                    //递交更新
                    if (isNew)
                        dt.Rows.Add(dr);
                    adapter.Update(dt);
                    ret = true;

                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { CloseConnection(); }
            return ret;
        }

        /// <summary>
        /// 执行sql语句返回实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public List<T> ExecuteList<T>(string mysql)
        {
            DataTable dt = GetData(mysql);
            return dt.ToList<T>();
        }

        #region 事物处理

        /// <summary>
        /// 开始执行事物
        /// </summary>
        public void BegionTransaciton(string transactionName = "")
        {
            try
            {
                if (mysqlCon.State != ConnectionState.Open)
                    mysqlCon.Open();
                if (!string.IsNullOrEmpty(transactionName))
                    myTransaction = mysqlCon.BeginTransaction(transactionName);
                else
                    myTransaction = mysqlCon.BeginTransaction();
            }
            catch (Exception ex) { throw ex; }

        }

        /// <summary>
        /// 递交事物   
        /// 对于没有名称的事物，递交失败后自动回滚，否则需根据事物名称手动回滚
        /// </summary>
        public void CommitTransaciton()
        {
            try
            {
                myTransaction.Commit();
            }
            catch (Exception ex)
            {
                myTransaction.Rollback();
                throw ex;
            }
            finally
            {
                if (mysqlCon.State == ConnectionState.Open)
                    mysqlCon.Close();
            }
        }

        /// <summary>
        /// 创建事物回滚片段(回滚点)
        /// </summary>
        /// <param name="savePointName"></param>
        /// <returns></returns>
        public string SaveTransactionPoint(string savePointName)
        {
            if (string.IsNullOrEmpty(savePointName)) return string.Empty;

            if (null != myTransaction)
            {
                myTransaction.Save(savePointName);
                return savePointName;
            }

            return null;
        }

        /// <summary>
        /// 事物回滚,回滚整个事物或者片段
        /// 事物递交成功后，无法回滚
        /// </summary>
        /// <param name="transactionName"></param>
        public void RollBackTransaction(string transactionName = "")
        {
            if (null != myTransaction)
            {
                try
                {
                    if (!string.IsNullOrEmpty(transactionName))
                        myTransaction.Rollback(transactionName);
                    else
                        myTransaction.Rollback();
                }
                catch { }
                finally
                {
                    if (mysqlCon.State == ConnectionState.Open)
                        mysqlCon.Close();
                }
            }
        }
        #endregion

        private SqlCommand GetSqlCommand(string sql)
        {
            SqlCommand cmd = null;
            if (null == myTransaction)
                cmd = new SqlCommand(sql, mysqlCon);
            else
                cmd = new SqlCommand(sql, mysqlCon, myTransaction);
            return cmd;
        }

        bool isDisposed = false;
        public void Dispose()
        {
            try
            {
                if (null != mysqlCon)
                    mysqlCon.Dispose();
            }
            catch { };
            isDisposed = true;
        }

        ~DBHelper()
        {
            if (!isDisposed)
                Dispose();
        }
        //end added Tianyf


        /// <summary>
        /// 查询数据（返回第一行第一列数据，比如：select count(1) count from...）
        /// </summary>
        /// <param name="mysql">sql语句</param>
        /// <param name="conString">连接字符串</param>
        /// <returns>获取查询结果第1条记录</returns>
        public object ExecuteScalar(string mysql)
        {
            object item = null;
            try
            {
                OpenConnection();
                SqlCommand mysqlcmd = GetSqlCommand(mysql);
                item = mysqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //logHelper.WriteToLog(ex.Message.ToString());
                //logHelper.WriteToLog("异常语句：" + mysql + "\r\n" + ex.Message.ToString());
                throw new Exception("异常语句：" + mysql + "\r\n" + ex.ToString());
            }
            finally { CloseConnection(); }
            return item;
        }



        /// <summary>
        /// 执行更改等操作
        /// </summary>
        /// <param name="mysql">sql语句</param>
        /// <param name="conString">连接字符串</param>
        /// <returns>返回影响记录条数</returns>
        public int ExecuteNonQuery(string mysql)
        {
            int result = 0;
            try
            {
                OpenConnection();
                SqlCommand mysqlcmd = GetSqlCommand(mysql);
                result = mysqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logHelper.WriteToLog(ex.Message.ToString());
                //logHelper.WriteToLog("异常语句：" + mysql + "\r\n" + ex.Message.ToString());
                throw new Exception("异常语句：" + mysql + "\r\n" + ex.ToString());
            }
            finally { CloseConnection(); }
            return result;
        }



        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="array">sql语句</param>
        /// <param name="conString">连接字符串</param>
        /// <returns>成功执行事务返回true,否则返回false</returns>
        public bool Transaction(ArrayList array)
        {
            bool isSuccess = true;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();

                    SqlTransaction mysqltran = sqlCon.BeginTransaction();
                    SqlCommand mysqlcmd = new SqlCommand();
                    mysqlcmd.Connection = sqlCon;
                    mysqlcmd.Transaction = mysqltran;

                    try
                    {
                        foreach (string arr in array)
                        {
                            mysqlcmd.CommandText = arr.ToString();
                            if (mysqlcmd.ExecuteNonQuery() < 1)
                            {
                                isSuccess = false;
                                break;
                            }
                        }
                        if (isSuccess)
                        {
                            mysqltran.Commit();
                        }
                        else
                        {
                            mysqltran.Rollback();
                        }
                    }
                    catch
                    {
                        isSuccess = false;
                        mysqltran.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                //logHelper.WriteToLog(ex.Message.ToString());
                //logHelper.WriteToLog("异常语句：" + array.ToString() + "\r\n" + ex.Message.ToString());
                throw new Exception("异常语句：" + array.ToString() + "\r\n" + ex.ToString());
            }
            return isSuccess;
        }

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public string RunProcedureReturnSqlDataReader(string storedProcName, IDataParameter[] parameters)
        {
            SqlDataReader returnReader;
            SqlCommand command = BuildQueryCommand(mysqlCon, storedProcName, parameters);
            if (null != myTransaction)  //增加事物控制　　addedby Tianyf 20170731
                command.Transaction = myTransaction;
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                OpenConnection();
                returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return returnReader[0].ToString();
            }
            catch { }
            finally { CloseConnection(); }
            return null;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureReturnDataSet(string storedProcName, IDataParameter[] parameters)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                OpenConnection();
                sqlDA.SelectCommand = BuildQueryCommand(mysqlCon, storedProcName, parameters);
                sqlDA.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("异常存储过程：" + storedProcName + "\r\n" + ex.ToString());
            }
            finally { CloseConnection(); }

            return dataSet;
        }
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }


        /// <summary>
        /// 使用存储过程接收返回的字符串
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="pid">商户编号</param>
        /// <param name="transmoney">金额</param>
        /// <param name="payment">支付通道</param>
        /// <returns>返回的字符串</returns>
        public string procUseProc(string procName)
        {
            string result = string.Empty;

            try
            {

                using (SqlCommand mysqlcmd = new SqlCommand())
                {
                    mysqlcmd.CommandType = CommandType.StoredProcedure;
                    mysqlcmd.Connection = mysqlCon;
                    mysqlcmd.CommandText = procName;
                    OpenConnection();
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(mysqlcmd))
                        adapter.Fill(ds);

                    if (ds != null)
                        if (ds.Tables.Count > 0)
                            if (ds.Tables[0].Rows.Count > 0)
                                result = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                //logHelper.WriteToLog("方法:procUseProc发生异常:" + ex.Message + ",存储过程名称为:" + procName);
                throw new Exception("异常存储过程：" + procName + "\r\n" + ex.ToString());
            }
            finally { CloseConnection(); }

            return result;
        }
    }
}
