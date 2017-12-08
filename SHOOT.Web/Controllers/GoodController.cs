using SHOOT.Common;
using SHOOT.Model.Bisness;
using SHOOT.Service.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOOT.Model.Base;
using SHOOT.Utils;

namespace SHOOT.Controllers
{
    public class GoodController : Controller
    {
        //
        // GET: /Good/

        [UserAuthorFilter]
        public ActionResult GoodView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGiftsData()
        {
            var result = new GiftService().GetGiftsData();
            return Content(JsonHelper.SerializeObject(result));
        }

        /// <summary>
        /// 选择礼包
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitGift(string jsonData)
        {
            try
            {
                var entity = JsonHelper.DeserializeObject<Bis_Gift>(jsonData);
                TempData["GiftDetail"] = entity;
                return Content(JsonHelper.SerializeObject(Common.MessageRes.OperateSuccess.SetResult(entity.GiftID)));
            }
            catch (Exception ex)
            {
                MYLog.Error("选择礼包：" + SessionTools.UserName, ex.ToString());
                return Content(JsonHelper.SerializeObject((Common.MessageRes.OperateException + ex.ToString()).SetResult(null)));
            }
        }
	}
}