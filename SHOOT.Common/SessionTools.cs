using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHOOT.Common
{
    public static class SessionTools
    {
        public static void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static object GetSession(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static string UserID
        {
            get
            {
                var userid = HttpContext.Current.Session["UserID"];
                return userid == null ? "" : userid.ToString();
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                var username = HttpContext.Current.Session["UserName"];
                return username == null ? "" : username.ToString();
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
    }
}
