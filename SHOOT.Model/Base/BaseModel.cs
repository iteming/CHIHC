using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOOT.Common.Modules;
using System.Data;
using System.Reflection;

namespace SHOOT.Model.Base
{
    public class BaseModel
    {
        public string ID { get; set; }

        //public void CreateGuid()
        //{
        //    this.ID = Utils.CreateGUID();
        //}

        /// <summary>
        /// 将模型中的值放到数据行
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public void ToDataRow(ref DataRow dr)
        {
            DataTable dt = dr.Table;
            Type t = this.GetType();

            foreach (PropertyInfo p in t.GetProperties())
            {
                if (!dt.Columns.Contains(p.Name))
                    continue;
                try
                {
                    object obj = p.GetValue(this);
                    if (null == obj)
                        dr[p.Name] = DBNull.Value;
                    else
                        dr[p.Name] = p.GetValue(this);
                }
                catch
                {
                    continue;
                    //TODO:Exception处理
                }
            }
        }
    }
}
