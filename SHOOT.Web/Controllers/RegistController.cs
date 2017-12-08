using SHOOT.Common;
using SHOOT.Model.System;
using System.Web.Mvc;
using SHOOT.Service.System;
using SHOOT.Utils;

namespace SHOOT.Controllers
{
    public class RegistController : Controller
    {
        //
        // GET: /Regist/
        [UserAuthorFilter]
        public ActionResult RegistView()
        {
            ViewBag.User = new UserService().GetUserBase(SessionTools.UserID);
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