using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SHOOT.Base
{
    interface IDao<T>
    {
        List<T> SelectAll(string orderby="");

        List<T> SelectAll(string orderby, int pageNum, int pageSize);

        List<T> Select(string sql);

        List<T> SelectPage(string sql, string orderby, int pageNum, int pageSize, ref uint recordCount);

        List<T> SelectByFilter(string filter,string orderby="");

        List<T> SelectByFilter(string filter, string orderby, int pageNum, int pageSize);

        DataTable GetDataAll(string orderby = "");

        DataTable GetDataAll(string orderby, int pageNum, int pageSize);

        DataTable GetData(string sql);

        DataTable GetPageData(string sql, string orderby, int pageNum, int pageSize, ref uint recordCount);

        DataTable GetDataByFilter(string filter, string orderby = "");

        DataTable GetDataByFilter(string fileter, string orderby, int pageNum, int pageSize);

        UInt32 GetRecordCount(string filter="");

        T SelectByID(string ID);

        bool Insert(T model);

        bool Insert(List<T> models);

        bool Update(T model);

        bool Exist(T model);

        bool Exist(string ID);

        bool Delete(T model);

        bool Delete(string ID);

        bool Delete(List<T> models);

        bool Delete(string[] IDs);

        bool DeleteIn(string IDs);
    }
}
