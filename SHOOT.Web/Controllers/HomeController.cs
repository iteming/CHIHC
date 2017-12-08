using SHOOT.Common;
using SHOOT.Service.Bisness;
using SHOOT.Utils;
using System.Web.Mvc;

namespace SHOOT.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var appid = Common.WxPay.Lib.PayConfig.WxAppid();
            var ts = Common.WxShare.Lib.ShareUtil.getTimestamp();
            var ns = Common.WxShare.Lib.ShareUtil.getNoncestr();
            var sign = Common.WxShare.JsApiShare.GetShareSignature(ns, ts);
            ViewBag.appid = appid;
            ViewBag.ts = ts;
            ViewBag.ns = ns;
            ViewBag.sign = sign;

            return View();
        }

        [UserAuthorFilter]
        public ActionResult StartGame()
        {
            string redirectUrl = "/Good/GoodView/";

            var recordEntity = new RecordService().GetNoEndOrder(SessionTools.UserID);
            if (recordEntity != null)
                redirectUrl = string.Format(@"/Order/Success?OrderID={0}&PayType=Consume", recordEntity.RecordID);

            return Redirect(redirectUrl);
        }

        public ActionResult OAuth(string ReturnUrl)
        {
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                // 如果code参数存在，则拼接code
                var code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                    ReturnUrl += (ReturnUrl.Contains("?") ? "&" : "?") + "code=" + code;

                return Redirect(ReturnUrl);
            }
            return Redirect("Error");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}