using SHOOT.Common;
using SHOOT.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOOT.Model.Base;
using SHOOT.Service.System;
using SHOOT.Utils;

namespace SHOOT.Controllers
{
    public class RegistController : Controller
    {
        //
        // GET: /Regist/
        [UserAuthorFilter]
        public ActionResult RegistView(string jsonUser="")
        {
            ViewBag.User = JsonHelper.DeserializeObject<Sys_User>(jsonUser);
            return View();
        }

        [HttpPost]
        public ActionResult SubmitUser(string jsonData)
        {
            var Entity = JsonHelper.DeserializeObject<Sys_User>(jsonData);
            var resultData = new UserService().UpdateUserInfo(Entity);
            return Content(JsonHelper.SerializeObject(resultData));
        }
	}
}