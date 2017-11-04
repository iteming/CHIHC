using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SHOOT.Common.Modules;

namespace SHOOT.Base
{
    public class BaseDao<T> : IDao<T> where T : SHOOT.Model.Base.BaseModel
    {
        protected string _TableName = string.Empty;
        protected string _KeyName = "ID";

        protected DBHelper help = null;

        public BaseDao(string tableName)
            : this()
        {
            _TableName = tableName;
        }

        public BaseDao()
        {
            if (null == help)
                help = new DBHelper();
        }


        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataTable GetDataAll(string orderby = "")
        {
            return GetDataByFilter("", orderby);
        }

        /// <summary>
        /// 获取数据库中所有对象
        /// </summary>
        /// <param name="orderby">可选参数 排序依据</param>
        /// <returns>List</returns>
        public List<T> SelectAll(string orderby = "")
        {
            return SelectByFilter("", orderby);
        }

        /// <summary>
        /// 根据sql语句获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>获取失败返回null</returns>
        public DataTable GetData(string sql)
        {
            DataTable ret = null;

            if (string.IsNullOrEmpty(_TableName))
                return ret;

            try
            {
                ret = help.GetData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        /// <summary>
        /// 根据SQL语句获取分页数据
        /// </summary>
        /// <param name="sql">完整查询语句，支持多表</param>
        /// <param name="orderby">排序依据，为空抛错</param>
        /// <param name="pageNum">显示第几页数据，首页为0</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">ref 返回总数据行</param>
        /// <returns></returns>
        public DataTable GetPageData(string sql, string orderby, int pageNum, int pageSize, ref uint recordCount)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(orderby))
                throw new Exception("排序依据不能为空");

            int iEnd = (pageNum + 1) * pageSize;
            int iStart = pageNum * pageSize + 1;

            string mySql = string.Format("Select Count(*) From ({0}) Temp", sql);
            object oCount = help.ExecuteScalar(mySql);
            if (uint.TryParse(oCount + "", out recordCount))
            {
                mySql = string.Format("Select * From ( Select Row_Number() over(order by {1}) RowNum ,* From ({0}) as T1 ) as Temp where Temp.RowNum Between {2} and {3}", sql, orderby, iStart, iEnd);

                dt = help.GetData(mySql);
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">完整查询语句，支持多表</param>
        /// <param name="orderby">排序依据，为空抛错</param>
        /// <param name="pageNum">显示第几页数据，首页为0</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">ref 返回总数据行</param>
        /// <returns></returns>
        public List<T> SelectPage(string sql, string orderby, int pageNum, int pageSize, ref uint recordCount)
        {
            List<T> ret = new List<T>();
            DataTable dt = GetPageData(sql, orderby, pageNum, pageSize, ref recordCount);
            if (null != dt && dt.Rows.Count > 0)
                ret = dt.ToList<T>();
            return ret;
        }

        /// <summary>
        /// 根据sql语句获取所有对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>获取失败返回长度为0的list</returns>
        public List<T> Select(string sql)
        {
            List<T> ret = new List<T>();

            DataTable dt = GetData(sql);
            if (null == dt) return ret;
            ret = dt.ToList<T>();
            return ret;
        }

        public T SelectOneByFilter(string filter)
        {
            T ret = default(T);
            var list = SelectByFilter(filter);
            if (null != list && list.Count > 0)
                ret = list.First();
            return ret;
        }

        /// <summary>
        /// 根据过滤条件获取数据表
        /// </summary>
        /// <param name="filter">过滤条件SQL Where后面语句</param>
        /// <param name="orderby">可选参数 排序依据  Order By 后面语句</param>
        /// <returns>失败返回null</returns>
        public DataTable GetDataByFilter(string filter, string orderby = "")
        {
            DataTable ret = null;

            if (string.IsNullOrEmpty(_TableName))
                return ret;

            try
            {
                string sql = string.Format("Select * From {0}", _TableName);
                if (!string.IsNullOrEmpty(filter))
                    sql = string.Format("{0} Where {1}", sql, filter);

                if (!string.IsNullOrEmpty(orderby))
                    sql = string.Format("{0} order by {1}", sql, orderby);
                ret = help.GetData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        /// <summary>
        /// 根据过滤条件获取对象
        /// </summary>
        /// <param name="filter">过滤条件SQL Where后面语句</param>
        /// <param name="orderby">可选参数 排序依据  Order By 后面语句</param>
        /// <returns>List</returns>
        public List<T> SelectByFilter(string filter, string orderby = "")
        {
            List<T> ret = new List<T>();

            DataTable dt = GetDataByFilter(filter, orderby);
            if (null != dt && dt.Rows.Count > 0)
                ret = dt.ToList<T>();
            return ret;
        }

        /// <summary>
        /// 根据对象ID获取对象实例
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T SelectByID(string ID)
        {
            T ret = default(T);
            string sql = string.Format("Select * From {0} Where {1}='{2}'", _TableName, _KeyName, ID);
            DataTable dt = help.GetData(sql);
            if (dt.Rows.Count > 0)
                ret = dt.Rows[0].ToModel<T>();
            return ret;
        }

        /// <summary>
        /// 将对象插入到数据库,已存在会更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(T model)
        {
            bool ret = false;
            ret = help.Update(model, _TableName, _KeyName);
            return ret;
        }

        /// <summary>
        /// 批量插入数据，出错会回滚事务
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool Insert(List<T> models)
        {
            bool ret = false;
            DBHelper helpInsert = new DBHelper();

            helpInsert.BegionTransaciton();
            foreach (T model in models)
            {
                try
                {
                    helpInsert.Update(model, _TableName, _KeyName);
                }
                catch (Exception ex)
                {
                    helpInsert.RollBackTransaction();
                    throw ex;
                }
                ret = true;
            }
            helpInsert.CommitTransaciton();
            return ret;
        }

        /// <summary>
        /// 更新对象到数据库，如果不存在则插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            bool ret = false;
            ret = help.Update(model, _TableName, _KeyName);
            return ret;
        }

        /// <summary>
        /// 批量更新数据，出错会回滚事务
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool Update(List<T> models)
        {
            bool ret = false;
            DBHelper helpInsert = new DBHelper();

            helpInsert.BegionTransaciton();
            foreach (T model in models)
            {
                try
                {
                    helpInsert.Update(model, _TableName, _KeyName);
                }
                catch (Exception ex)
                {
                    helpInsert.RollBackTransaction();
                    throw ex;
                }
                ret = true;
            }
            helpInsert.CommitTransaciton();
            return ret;
        }


        /// <summary>
        /// 对象是否已经存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exist(T model)
        {
            bool ret = false;
            if (string.IsNullOrEmpty(model.ID))
                return ret;

            ret = Exist(model.ID);
            return ret;
        }

        /// <summary>
        /// 根据ID判断对象是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Exist(string ID)
        {
            bool ret = false;
            if (string.IsNullOrEmpty(_TableName))
                return ret;

            string sql = string.Format("Select Count(ID) From {0} Where ID='{1}'", _TableName, ID);
            object obj = help.ExecuteScalar(sql);
            int count = 0;
            if (int.TryParse(obj + "", out count))
                ret = count > 0;
            return ret;
        }



        /// <summary>
        /// 分页获取所有记录
        /// </summary>
        /// <param name="orderby">分页排序依据</param>
        /// <param name="pageNum">要获取第几页  首页为1</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>List</returns>
        public List<T> SelectAll(string orderby, int pageNum, int pageSize)
        {
            List<T> ret = new List<T>();
            DataTable dt = GetDataAll(orderby, pageNum, pageSize);
            if (null != dt && dt.Rows.Count > 0)
                ret = dt.ToList<T>();
            return ret;
        }

        /// <summary>
        /// 根据条件分页查询记录
        /// </summary>
        /// <param name="filter">过滤条件 sql语句Where后面部分</param>
        /// <param name="orderby">分页排序依据</param>
        /// <param name="pageNum">要获取第几页  首页为1</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>List</returns>
        public List<T> SelectByFilter(string filter, string orderby, int pageNum, int pageSize)
        {
            List<T> ret = new List<T>();
            DataTable dt = GetDataByFilter(filter, orderby, pageNum, pageSize);
            if (null != dt && dt.Rows.Count > 0)
                ret = dt.ToList<T>();
            return ret;
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="orderby">分页排序依据</param>
        /// <param name="pageNum">要获取第几页  首页为1 </param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="filter" >过滤条件，可选参数 </param>
        /// <returns>DataTable</returns>
        public DataTable GetDataAll(string orderby, int pageNum, int pageSize)
        {
            return GetDataByFilter("", orderby, pageNum, pageSize);
        }

        /// <summary>
        /// 根据过滤条件进行分页查询
        /// </summary>
        /// <param name="fileter">过滤条件 sql语句Where后面部分</param>
        /// <param name="orderby">排序依据 sql语句Order by 后面部分</param>
        /// <param name="pageNum">要获取第几页  首页为1 </param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public DataTable GetDataByFilter(string fileter, string orderby, int pageNum, int pageSize)
        {
            DataTable dt = null;
            if (!HasTableName)
                return dt;

            //每页第一条和最后一条记录的索引号
            int iStart = 0, iEnd = 0;
            string myOrder = (string.IsNullOrEmpty(orderby) ? "ID" : orderby);

            //数量不够直接返回
            if (pageNum * pageSize >= GetRecordCount()) return dt;

            iStart = pageNum * pageSize + 1;
            iEnd = (pageNum + 1) * pageSize;

            string sql = string.Format("Select ROW_NUMBER() over(order by {0}) RowNum ,* From {1}", myOrder, _TableName);
            if (!string.IsNullOrEmpty(fileter))
                sql = string.Format("{0} Where {1}", sql, fileter);

            sql = string.Format("Select * From ({0}) Temp Where Temp.RowNum Between {1} And {2}", sql, iStart, iEnd);

            dt = help.GetData(sql);
            return dt;
        }

        private bool HasTableName
        {
            get { return !string.IsNullOrEmpty(_TableName); }
        }


        /// <summary>
        /// 获取数据库记录数
        /// </summary>
        /// <param name="filter">可选参数 过滤条件 sql语句Where后面部分</param>
        /// <returns>Uint32</returns>
        public UInt32 GetRecordCount(string filter = "")
        {
            uint count = 0;
            string sql = string.Format("Select Count(ID) From {0}", _TableName);
            if (!string.IsNullOrEmpty(filter))
                sql = string.Format("{0} Where {1}", sql, filter);

            try
            {
                object ret = help.ExecuteScalar(sql);
                uint.TryParse(ret + "", out count);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }

        /// <summary>
        /// 获取数据库记录数
        /// </summary>
        /// <param name="filter">可选参数 过滤条件 sql语句Where后面部分</param>
        /// <returns>Uint32</returns>
        public UInt32 GetRecordCountBySql(string sqlCount)
        {
            uint count = 0;
            string sql = string.Format("Select Count(ID) From ({0}) Temp", sqlCount);

            try
            {
                object ret = help.ExecuteScalar(sql);
                uint.TryParse(ret + "", out count);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }

        public bool Delete(T model)
        {
            return Delete(model.ID);
        }

        public bool Delete(string ID)
        {
            bool ret = false;
            if (!HasTableName) return ret;

            if (string.IsNullOrEmpty(ID)) return ret;
            try
            {
                string sql = string.Format("Delete From {0} Where ID='{1}'", _TableName, ID);
                help.ExecuteScalar(sql);
                ret = true;
            }
            catch (Exception ex) { throw ex; }

            return ret;
        }

        ~BaseDao()
        {
            if (null != help)
                help.Dispose();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool Delete(List<T> models)
        {
            bool ret = false;

            var lstID = from model in models select model.ID;
            ret = Delete(lstID.ToArray<string>());
            return ret;
        }

        /// <summary>
        /// 根据ＩＤ进行批量删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool Delete(string[] IDs)
        {
            bool ret = false;
            string ids = string.Join(",", IDs);
            ret = DeleteIn(ids);
            return ret;
        }

        /// <summary>
        /// 根据ID进行批量删除
        /// </summary>
        /// <param name="IDs">使用英文小写逗号间隔的多个ID</param>
        /// <returns></returns>
        public bool DeleteIn(string IDs)
        {
            bool ret = false;
            if (string.IsNullOrEmpty(IDs))
                return ret;

            string strID = IDs;
            strID = strID.Replace(",", "','");
            string sql = string.Format("Delete From {0} Where ID in ('{1}')", _TableName, strID);
            try
            {
                help.ExecuteScalar(sql);
                ret = true;
            }
            catch (Exception ex) { throw ex; }
            return ret;
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool TableExists(string tableName)
        {
            bool ret = true;
            string sql = string.Format("select * from dbo.sysobjects where id = object_id(N'[dbo].{0}') and OBJECTPROPERTY(id, N'IsUserTable') = 1", tableName);

            try
            {
                DataTable dt = GetData(sql);
                if (null != dt && dt.Rows.Count > 0)
                    ret = true;
            }
            catch (Exception ex) { throw ex; }
            return ret;
        }

        /// <summary>
        /// code 每位长度
        /// </summary>
        public int code_lenght = 3;
        public string GenerateCode(string ParentID)
        {
            // 初始化 Code
            string nextCode = "1".PadLeft(code_lenght, '0');
            string parentCode = string.Empty;

            DataTable dt = null;
            if (string.IsNullOrEmpty(ParentID))
            {
                string filter = " ParentID IS NULL OR ParentID='' ";
                dt = this.GetDataByFilter(filter);
            }
            else
            {
                string filter = string.Format(" ParentID='{0}' ", ParentID);
                dt = this.GetDataByFilter(filter);

                string sql = string.Format("Select * From {0} Where ID='{1}'", _TableName, ParentID);
                DataTable dtParent = help.GetData(sql);
                if (dtParent != null && dtParent.Rows.Count > 0 && dtParent.Columns.Contains("Code"))
                {
                    parentCode = Convert.ToString(dtParent.Rows[0]["Code"]);
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select(" code =Max(code)");
                var MaxCode = Convert.ToString(drs[0]["Code"]);

                var strOne = MaxCode.Substring(0, MaxCode.Length - 3);
                var strTwo = MaxCode.Substring(MaxCode.Length - 3);
                var strNew = (Convert.ToInt64(strTwo) + 1).ToString().PadLeft(code_lenght, '0');
                nextCode = strOne + strNew;
            }
            else
                nextCode = parentCode + nextCode;

            return nextCode;
        }
    }
}
