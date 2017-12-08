using SHOOT.Common;
using SHOOT.Model.Bisness;
using SHOOT.Service.Bisness;
using SHOOT.Service.System;
using SHOOT.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOOT.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        [UserAuthorFilter]
        public ActionResult OrderView()
        {
            var GiftDetail = (Bis_Gift)TempData["GiftDetail"];
            if (GiftDetail != null)
            {
                TempData["GiftDetail"] = GiftDetail;
                ViewBag.GiftDetail = JsonHelper.SerializeObject(GiftDetail);
                return View();
            }
            else
            {
                return Redirect("/Good/GoodView/");
            }
        }

        [HttpPost]
        public ActionResult GetGoodData(string jsonData)
        {
            var entity = JsonHelper.DeserializeObject<Bis_Gift>(jsonData);
            var resultData = new GoodService().GetGoodData(entity);
            return Content(JsonHelper.SerializeObject(resultData));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitOrder(string GiftJsonData, string GoodJsonData)
        {
            var GiftEntity = JsonHelper.DeserializeObject<Bis_Gift>(GiftJsonData);
            var GoodList = JsonHelper.DeserializeObject<List<Bis_Goods>>(GoodJsonData);
            // 提交订单
            var resultData = new RecordService().SubmitOrder(GiftEntity, GoodList, SessionTools.UserID);
            return Content(JsonHelper.SerializeObject(resultData));
        }

        [UserAuthorFilter]
        public ActionResult Success(string OrderID = "")
        {
            var RecordEntity = new RecordService().SelectByID(OrderID);
            //var CouponEntity = new CouponService().GetCouponByOrderID(OrderID);

            //ViewBag.PayType = PayType == "Consume" ? "消费" : "充值";
            ViewBag.OrderID = RecordEntity != null ? RecordEntity.RecordID : "";
            ViewBag.OrderNo = RecordEntity != null ? RecordEntity.OrderNo : "";
            ViewBag.Description = RecordEntity != null ? RecordEntity.Description: "";
            ViewBag.Status = RecordEntity != null ? RecordEntity.Status : 0;
            //ViewBag.Coupon = CouponEntity != null ? CouponEntity.Coupon : "";

            return View();
        }

        [HttpPost]
        public ActionResult UseCoupon(string coupon)
        {
            var resultData = new CouponService().GetGoodsByCoupon(coupon);
            if (resultData != null && resultData.status > 0)
            {
                string result = "";
                foreach (var item in resultData.data)
                {
                    result += string.Format(@"【{0}】:{1} ", item.GoodName, item.Description) + System.Environment.NewLine;
                }
                return Content(JsonHelper.SerializeObject(result));
            }
            else
            {
                return Content(JsonHelper.SerializeObject("获取失败!"));
            }
        }



        /// <summary>
        /// 填写保单信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult SetInsurance(string OrderID = "")
        {
            var CouponEntity = new CouponService().GetCouponByOrderID(OrderID);
            var UserEntity = new UserService().SelectByID(SessionTools.UserID);
            //if (CouponEntity !=null && UserEntity != null)
            //{
            //    CouponEntity.InsuranceName = !string.IsNullOrEmpty(CouponEntity.InsuranceName) ? CouponEntity.InsuranceName : UserEntity.UserName;
            //    CouponEntity.InsuranceIdCard = !string.IsNullOrEmpty(CouponEntity.InsuranceIdCard) ? CouponEntity.InsuranceIdCard : UserEntity.IdCard;
            //    CouponEntity.InsurancePhone = !string.IsNullOrEmpty(CouponEntity.InsurancePhone) ? CouponEntity.InsurancePhone : UserEntity.TelePhone;
            //    CouponEntity.InsuranceSex = (CouponEntity.InsuranceSex??0) != 0 ? CouponEntity.InsuranceSex : UserEntity.Sex;
            //}
            ViewBag.CouponEntity = JsonHelper.SerializeObject(CouponEntity);
            return View();
        }
        
        [HttpPost]
        public ActionResult SubmitInsurance(string jsonData)
        {
            var CouponEntity = JsonHelper.DeserializeObject<Bis_Coupon>(jsonData);
            var resultData = new CouponService().SubmitInsurance(CouponEntity);
            return Content(JsonHelper.SerializeObject(resultData));
        }
    }
}