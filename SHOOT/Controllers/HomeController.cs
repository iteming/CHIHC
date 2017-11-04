using SHOOT.Common;
using SHOOT.Common.WxPay.Lib;
using SHOOT.Model;
using SHOOT.Model.System;
using SHOOT.Service.Bisness;
using SHOOT.Service.System;
using SHOOT.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SHOOT.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
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