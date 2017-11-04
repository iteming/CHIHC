using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Common.Modules
{
    /// <summary>
    /// Author Tianyf 20170726
    /// 类扩展
    /// </summary>
    public static class ExtendClass
    {

        /// <summary>
        /// 对datarow对象进行扩展，将datarow直接转换为实例对象
        /// 支持 int,string,bool,decimal,double,float,datetime类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns>失败返回default(T)</returns>
        public static T ToModel<T>(this DataRow dr){
            Type t = typeof(T);
            T instanceT = default(T);
            string strValue = string.Empty;
            int intValue = 0;
            bool bValue = false;
            DateTime dateValue = DateTime.MinValue;
            decimal dcmValue = 0;
            Single fValue = 0F;
            double dblValue = 0;
            byte bytValue = 0;

            //获取数据
            DataTable dtSource = dr.Table;
            //实例化对象
            instanceT = (T)Activator.CreateInstance(t);
            //反射赋值
            foreach (var p in t.GetProperties())
            {
                if (dtSource.Columns.Contains(p.Name))
                {
                    strValue = dr[p.Name] + "";

                    switch (p.PropertyType.ToString())
                    {
                        case "System.Int32":
                        case "System.Nullable`1[System.Int32]":
                            if (int.TryParse(strValue, out intValue))
                                p.SetValue(instanceT, intValue);
                            break;
                        case "System.Decimal":
                        case "System.Nullable`1[System.Decimal]":
                            if (decimal.TryParse(strValue, out dcmValue))
                                p.SetValue(instanceT, dcmValue);
                            break;
                        case "System.Boolean":
                        case "System.Nullable`1[System.Boolean]":
                            if (bool.TryParse(strValue, out bValue))
                                p.SetValue(instanceT, bValue);
                            break;
                        case "System.String":
                            p.SetValue(instanceT, strValue);
                            break;
                        case "System.DateTime":
                        case "System.Nullable`1[System.DateTime]":
                            if (DateTime.TryParse(strValue, out dateValue))
                                p.SetValue(instanceT, dateValue);
                            break;
                        case "System.Single":
                        case "System.Nullable`1[System.Single]":
                            if (Single.TryParse(strValue, out fValue))
                                p.SetValue(instanceT, fValue);
                            break;
                        case "System.Double":
                        case "System.Nullable`1[System.Double]":
                            if (System.Double.TryParse(strValue, out dblValue))
                                p.SetValue(instanceT, dblValue);
                            break;
                        case "System.Byte":
                        case "System.Nullable`1[System.Byte]":
                            if (byte.TryParse(strValue, out bytValue))
                                p.SetValue(instanceT, bytValue);
                            break;
                        default:
                            break;
                    }
                }
            }
            return instanceT;
        }

        /// <summary>
        /// 将数据表装换成实例队列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns>失败返回空List</returns>
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> ret = new List<T>();
            T oneT = default(T);
            if (null != dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    oneT = row.ToModel<T>();
                    if (null != oneT)
                        ret.Add(oneT);
                }
            }
            return ret;
        }
    }
}
