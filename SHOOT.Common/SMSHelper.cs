using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SHOOT.Common
{
    public static class SMSHelper
    {
        //接口
        public static string loginURL = "http://sms.900sup.cn/WebService.aspx";

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string SendCodeSMS(string str, string tel)
        {
            string strResult = "";
            string loginCreateCodeURL = string.Format(str);
            string strCode = string.Format(str);
            loginCreateCodeURL = HttpUtility.UrlEncode(loginCreateCodeURL, Encoding.UTF8);
            strResult = SendSMS2(tel, loginCreateCodeURL, strCode);
            return strResult;
        }

        private static string SendSMS2(string tel, string str, string strCode)
        {
            string strRetstring = "";
            string KEY = "SxJzYSms2@.#%";
            string sign = MD5Helper.getMd5Hash("gxcx" + tel + strCode + KEY);
            string postStrTpl = "id=gxcx&Sign=" + sign + "&tel={0}&message=";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, tel) + str);

            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(loginURL);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = postData.Length;

                Stream newStream = myRequest.GetRequestStream();
                // Send the data.
                newStream.Write(postData, 0, postData.Length);
                newStream.Flush();
                newStream.Close();

                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                    //反序列化upfileMmsMsg.Text
                    //实现自己的逻辑
                    strRetstring = reader.ReadToEnd();
                    MYLog.Debug("发送短信：" + tel, "成功");
                    return strRetstring;
                }
                else
                {
                    //访问失败
                    return strRetstring = "访问失败！";
                }
            }
            catch (Exception ex)
            {
                MYLog.Error("发送短信：" + tel, ex.ToString());
                return strRetstring = "访问异常！";
            }
        }
    }
}
