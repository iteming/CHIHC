using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Common.WxPay.Lib
{
    public class PayConfig
    {
        #region 微信

        ///<summary>
        ///页面跳转同步通知页面路径
        ///</summary>
        ///<remarks></remarks>
        public static string WxReturn_url()
        {
            return PayConfig.WebSiteDomain() + ConfigurationManager.AppSettings["ALIPAY_WxRETURN_URL"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string WxAppSecret()
        {
            return ConfigurationManager.AppSettings["WeiXin.APPSECRET"].ToString();
        }

        ///<summary>
        ///
        ///</summary>
        ///<remarks></remarks>
        public static string WxKey()
        {
            return ConfigurationManager.AppSettings["WeiXin.KEY"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string WxMchid()
        {
            return ConfigurationManager.AppSettings["WeiXin.MCHID"].ToString();
        }
        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string WxAppid()
        {
            return ConfigurationManager.AppSettings["WeiXin.APPID"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string ProxyEnable()
        {
            return ConfigurationManager.AppSettings["Proxy.Enable"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string ProxyIP()
        {
            return ConfigurationManager.AppSettings["Proxy.IP"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string ProxyPoint()
        {
            return ConfigurationManager.AppSettings["Proxy.Point"].ToString();
        }

        ///<summary>
        ///</summary>
        ///<remarks></remarks>
        public static string WebSiteDomain()
        {
            return ConfigurationManager.AppSettings["WebSite.Domain"].ToString();
        }
        #endregion
    }
}
