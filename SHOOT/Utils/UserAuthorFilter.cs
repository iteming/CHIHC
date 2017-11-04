using SHOOT.Common;
using SHOOT.Common.WxPay.Lib;
using SHOOT.Model;
using SHOOT.Model.System;
using SHOOT.Service.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOOT.Utils
{
    public class UserAuthorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string returnURL = filterContext.HttpContext.Request.Url.AbsolutePath;
            //SessionTools.UserID = "99dc2d9c-e134-4cfc-a07e-0943698d899b";
            if (string.IsNullOrEmpty(SessionTools.UserID))
            {
                if ("/" == returnURL || string.IsNullOrEmpty(returnURL))
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }

                string redirectUrl = GetReturnPath(filterContext, returnURL);
                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    redirectUrl += (redirectUrl.Contains("?") ? "&" : "?") + "ReturnUrl=" + returnURL;
                    filterContext.HttpContext.Response.Redirect(redirectUrl);
                    filterContext.HttpContext.Response.End();
                    return;
                }
            }
            else if (!returnURL.Contains("/Regist/RegistView"))
            {
                var User = new UserService().SelectByID(SessionTools.UserID);
                if (User != null && string.IsNullOrEmpty(User.TelePhone))
                {
                    string redirectUrl = "/Regist/RegistView?jsonUser=" + JsonHelper.SerializeObject(User);
                    redirectUrl += (redirectUrl.Contains("?") ? "&" : "?") + "ReturnUrl=" + returnURL;
                    filterContext.HttpContext.Response.Redirect(redirectUrl);
                    filterContext.HttpContext.Response.End();
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }

        private static string GetReturnPath(ActionExecutingContext filterContext, string returnURL)
        {
            try
            {
                // Session.UserID 为空，则拉取用户注册信息
                if (string.IsNullOrEmpty(SessionTools.UserID))
                {
                    var code = filterContext.HttpContext.Request.QueryString["code"];
                    if (string.IsNullOrEmpty(code))
                    {
                        // CODE 为空，则根据appid拉取网页授权
                        var redirect_uri = HttpUtility.UrlEncode(PayConfig.WebSiteDomain() + "/Home/OAuth?ReturnUrl=" + returnURL);
                        string url = string.Format(@"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect",
                            PayConfig.WxAppid(), redirect_uri);
                        filterContext.HttpContext.Response.Redirect(url);
                        filterContext.HttpContext.Response.End();
                        return string.Empty;
                    }

                    // CODE 不为空，则根据 code获取用户信息，并注册
                    var User = Registered(code);

                    // 用户手机号不存在则跳转至完善注册信息界面
                    if (User != null && string.IsNullOrEmpty(User.TelePhone))
                        return "/Regist/RegistView?jsonUser=" + JsonHelper.SerializeObject(User);
                }
            }
            catch (Exception ex)
            {
                MYLog.Error("拉取用户网页授权信息并且注册异常", ex.ToString());
            }
            return string.Empty;
        }

        private static Sys_User Registered(string code)
        {
            try
            {
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;


                // 通过code换取网页授权access_token 
                var strTokenUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                    PayConfig.WxAppid(), PayConfig.WxAppSecret(), code);
                var strTokenData = client.DownloadString(strTokenUrl);
                var TokenEntity = JsonHelper.DeserializeObject<WxAccessToken>(strTokenData);
                if (TokenEntity == null || string.IsNullOrEmpty(TokenEntity.access_token))
                    return null;


                // 通过access_token和openid 拉取用户信息
                var strUserUrl = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", TokenEntity.access_token, TokenEntity.openid);
                var strUserData = client.DownloadString(strUserUrl);
                var UserEntity = JsonHelper.DeserializeObject<WxUserInfo>(strUserData);
                if (UserEntity == null || string.IsNullOrEmpty(UserEntity.openid))
                    return null;


                // 注册
                var User = new UserService().Regist(UserEntity);
                if (User != null)
                {
                    SessionTools.UserID = User.UserID;
                    SessionTools.UserName = User.UserName;
                    return User;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}