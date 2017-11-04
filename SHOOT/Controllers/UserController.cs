using SHOOT.Common;
using SHOOT.Common.WxPay;
using SHOOT.Common.WxPay.Lib;
using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using SHOOT.Model.System;
using SHOOT.Service.Bisness;
using SHOOT.Service.System;
using SHOOT.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOOT.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [UserAuthorFilter]
        public ActionResult UserBase()
        {
            var user = new UserService().GetUserBase(SessionTools.UserID);
            ViewBag.User = JsonHelper.SerializeObject(user);

            var rankList = new UserRankService().GetRankList(SessionTools.UserID);
            ViewBag.RankList = JsonHelper.SerializeObject(rankList);

            return View();
        }

        [UserAuthorFilter]
        public ActionResult UserRecord()
        {
            var user = new UserService().GetUserBase(SessionTools.UserID);
            ViewBag.User = JsonHelper.SerializeObject(user);

            var recordList = new RecordService().GetOrderList(SessionTools.UserID);
            ViewBag.RecordList = JsonHelper.SerializeObject(recordList);

            return View();
        }


        /// <summary>
        /// 录入成绩前输入密码
        /// </summary>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult EnterPassword(string OrderID, string Password = "", int CodeType = (int)Code_Type.Rank)
        {
            #region 直接输入管理密码
            //var ConfigPassword = ConfigurationManager.AppSettings["ManagerPassword"].ToString();
            //if (!string.IsNullOrEmpty(Password.Trim()))
            //{
            //    if (Password.Trim() != ConfigPassword.Trim())
            //    {
            //        ViewBag.tipStr = "密码错误";
            //    }
            //    else
            //    {
            //        TempData["PWD_SUCCESS"] = "PWD_SUCCESS";
            //        ViewBag.tipStr = "";
            //    }
            //}
            //else
            //{
            //    ViewBag.tipStr = "Enter";
            //}

            //ViewBag.CodeType = CodeType;
            //ViewBag.OrderID = OrderID;
            #endregion

            #region 向管理员索要验证码
            if (!string.IsNullOrEmpty(Password.Trim()))
            {
                var entity = new UserService().GetUserBase(SessionTools.UserID);
                var validateResult = entity != null ? new CodeService().ValidateCode(entity.TelePhone, Password) : null;
                if (validateResult != null && validateResult.status > 0)
                {
                    TempData["PWD_SUCCESS"] = "PWD_SUCCESS";
                    ViewBag.tipStr = "";
                }
                else
                {
                    ViewBag.tipStr = "验证码错误";
                }
            }
            else
            {
                this.SendCode(OrderID, CodeType);
                ViewBag.tipStr = "Enter";
            }

            ViewBag.CodeType = CodeType;
            ViewBag.OrderID = OrderID;
            #endregion

            return View();
        }
        

        /// <summary>
        /// 录入成绩
        /// </summary>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult EnterRank(string OrderID)
        {
            var PWD_SUCCESS = Convert.ToString(TempData["PWD_SUCCESS"]);
            if (string.IsNullOrEmpty(PWD_SUCCESS))
            {
                return Redirect("/User/EnterPassword?OrderID=" + OrderID);
            }
            ViewBag.OrderID = OrderID;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitScore(string OrderID, string Score)
        {
            var resultData = new UserRankService().SubmitScore(OrderID, Score, SessionTools.UserID);
            return Content(JsonHelper.SerializeObject(resultData));
        }


        /// <summary>
        ///（暂时作废）输入管理员收到的退款验证码后，进入退款申请界面 
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult EnterRefund(string OrderID)
        {
            var PWD_SUCCESS = Convert.ToString(TempData["PWD_SUCCESS"]);

            var RecordEntity = new RecordService().SelectByID(OrderID);
            ViewBag.OrderID = RecordEntity != null ? RecordEntity.RecordID : "";
            ViewBag.OrderNo = RecordEntity != null ? RecordEntity.OrderNo : "";
            ViewBag.Amount = RecordEntity != null ? RecordEntity.Amount : 0;
            ViewBag.Description = RecordEntity != null ? RecordEntity.Description : "";

            return View();
        }

        /// <summary>
        /// 退款申请
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult EnterRefundApply(string OrderID)
        {
            var RecordEntity = new RecordService().SelectByID(OrderID);
            ViewBag.OrderID = RecordEntity != null ? RecordEntity.RecordID : OrderID;
            ViewBag.OrderNo = RecordEntity != null ? RecordEntity.OrderNo : "";
            ViewBag.Amount = RecordEntity != null ? RecordEntity.Amount : 0;
            ViewBag.Description = RecordEntity != null ? RecordEntity.Description : "";

            return View();
        }
        
        /// <summary>
        /// 提交退款申请
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="Remark"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitRefundApply(string OrderID, string Remark, decimal? Amount)
        {
            string RefundNo = WxPayApi.GenerateOutTradeNo();
            var resultData = new RefundService().AddRefundApply(OrderID, RefundNo, SessionTools.UserID, Remark, Amount);
            if (resultData != null &&resultData.status > 0)
            {
                // 修改订单状态为退款中
                var resultOrderStatus = new RecordService().RefundOrder(OrderID);
                // 退款申请提交成功后，（修改订单状态为退款中），向管理员发送退款申请验证码
                // 消息携带链接：/User/ValidateRefund?OrderID=&TelePhone=&CodeStr=
                // 管理员点击退款申请信息后，跳转至link，验证通过，管理员输入允许的退款金额
                // 然后调用 POST - /User/RefundAmount 进行退款
                // 退款成功后，修改订单状态、退款单状态、使用券状态
                if (resultOrderStatus != null && resultOrderStatus.status > 0)
                {
                    this.SendCode(OrderID, (int)Code_Type.Refund);
                }
            }
            return Content(JsonHelper.SerializeObject(resultData));
        }

        /// <summary>
        /// 使用管理员的权限，验证退款申请单，并进行退款操作
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="TelePhone"></param>
        /// <param name="CodeStr"></param>
        /// <returns></returns>
        [UserAuthorFilter]
        public ActionResult ValidateRefund(string OrderID, string TelePhone, string CodeStr)
        {
            var validateResult = new CodeService().ValidateCodeWithOutTime(TelePhone, CodeStr, Code_Type.Refund);
            if (!(validateResult != null && validateResult.status > 0))
                ViewBag.tipStr = "验证申请授权错误";

            var refundResult = new RefundService().SelectByID(OrderID);
            if (refundResult != null && refundResult.RefundStatus == (int)Order_Status.Refunding)
            {
                var RecordEntity = new RecordService().SelectByID(OrderID);
                ViewBag.OrderID = RecordEntity != null ? RecordEntity.RecordID : OrderID;
                ViewBag.OrderNo = RecordEntity != null ? RecordEntity.OrderNo : "";
                ViewBag.Amount = RecordEntity != null ? RecordEntity.Amount : 0;
                ViewBag.Description = RecordEntity != null ? RecordEntity.Description : "";

                ViewBag.RefundAmount = refundResult.Amount;
                ViewBag.RefundRemark = refundResult.Remark;

                ViewBag.tipStr = "";
            }
            else 
            {
                ViewBag.tipStr = "退款单已处理";
            }
            return View();
        }

        /// <summary>
        /// 直接输入退款金额，触发退款功能
        /// </summary>
        /// <param name="OrderID">  </param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RefundAmount(string OrderID, decimal? Amount=null)
        {
            var recordEntity = new RecordService().SelectByID(OrderID);
            var refundEntity = new RefundService().SelectByID(OrderID);
            if (recordEntity != null)
            {
                JsApiPay jsApiPay = new JsApiPay(this);

                var userEntity = new UserService().SelectByID(recordEntity.UserID);
                jsApiPay.op_user_id = userEntity != null ? userEntity.WeiXin_Openid : "";

                jsApiPay.order_no = recordEntity.OrderNo;
                jsApiPay.out_refund_no = refundEntity != null ? refundEntity.RefundNo : WxPayApi.GenerateOutTradeNo();
                jsApiPay.total_fee = Convert.ToInt32(recordEntity.Amount * 100);
                jsApiPay.refund_fee = Amount != null ? Convert.ToInt32(Amount * 100) : 
                    ( refundEntity != null ? Convert.ToInt32(refundEntity.Amount * 100) : 0);

                try
                {
                    WxPayData result = jsApiPay.GetRefundOrderResult();
                    if (result.IsSet("result_code") && result.GetValue("result_code").ToString() == "SUCCESS")
                    {
                        return Content(JsonHelper.SerializeObject(Common.MessageRes.OperateSuccess.SetResult("SUCCESS")));
                    }
                    else
                    {
                        MYLog.Error("退款申请失败：" + SessionTools.UserName, JsonHelper.SerializeObject(result.GetValues()));
                        return Content(JsonHelper.SerializeObject(result.GetValue("err_code_des").ToString().SetResult(null)));
                    }
                }
                catch (Exception ex)
                {
                    MYLog.Error("退款申请失败，请返回重试：" + SessionTools.UserName, ex.ToString());
                    return Content(JsonHelper.SerializeObject("退款申请失败，请返回重试".SetResult(null)));
                }
            }
            return Content(JsonHelper.SerializeObject(Common.MessageRes.OperateFailed.SetResult(null)));
        }
        

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="MsgType">消息类型：1 成绩录入，2 退款申请</param>
        /// <returns></returns>
        public ResultModel SendCode(string OrderID, int CodeType = (int)Code_Type.Rank)
        {
            var entity = new UserService().GetUserBase(SessionTools.UserID);
            return SendCodeMsg(entity, OrderID, CodeType);
        }

        /// <summary>
        /// 向管理员发送请求用户所需要的验证码
        /// </summary>
        /// <param name="toUser">请求的用户</param>
        /// <param name="MstType">消息类型：1 成绩录入，2 退款申请</param>
        private ResultModel SendCodeMsg(Sys_User toUser, string OrderID, int CodeType, string ReturnUrl="")
        {
            try
            {
                var USVC = new UserService();
                var CSVC = new CodeService();

                var telephone = ConfigurationManager.AppSettings["ManagerPhone"].ToString();
                var codeStr = CSVC.CreateCode(toUser.TelePhone, CodeType);
                var baseUser = USVC.GetUserBaseByTelePhone(telephone);

                if (baseUser != null && !string.IsNullOrEmpty(codeStr))
                {
                    var first = string.Empty;
                    var keyword1 = string.Empty;
                    var remark = string.Empty;
                    if (CodeType == 1)
                    {
                        first = string.Format(@"用户 {0} 正在进行成绩录入，向您请求验证码。", string.IsNullOrEmpty(toUser.TelePhone) ? toUser.UserName : toUser.TelePhone);
                        keyword1 = "成绩录入";
                        remark = "验证码5分钟内有效！";

                        Common.WxPay.JsApiPay.SendMsg(baseUser.WeiXin_Openid, Common.WxPay.Lib.MsgConfig.Msg3, new
                        {
                            first = new Common.WxPay.Lib.MsgValue() { value = first },
                            keyword1 = new Common.WxPay.Lib.MsgValue() { value = keyword1 },
                            keyword2 = new Common.WxPay.Lib.MsgValue() { value = codeStr },
                            remark = new Common.WxPay.Lib.MsgValue() { value = remark },
                        });
                    }
                    else
                    {
                        first = string.Format(@"用户 {0} 提交了一条退款申请，请尽快处理。", string.IsNullOrEmpty(toUser.TelePhone) ? toUser.UserName : toUser.TelePhone);
                        keyword1 = "退款申请";
                        var recordEntity = new RecordService().SelectByID(OrderID);
                        remark = string.Format(@"订单编号 {0}", recordEntity.OrderNo);

                        ReturnUrl = string.Format(@"{0}/User/ValidateRefund?OrderID={1}&TelePhone={2}&CodeStr={3}",
                            PayConfig.WebSiteDomain(), OrderID, toUser.TelePhone, codeStr);

                        Common.WxPay.JsApiPay.SendMsg(baseUser.WeiXin_Openid, Common.WxPay.Lib.MsgConfig.Msg4, new
                        {
                            first = new Common.WxPay.Lib.MsgValue() { value = first },
                            keyword1 = new Common.WxPay.Lib.MsgValue() { value = string.IsNullOrEmpty(toUser.TelePhone) ? toUser.UserName : toUser.TelePhone },
                            keyword2 = new Common.WxPay.Lib.MsgValue() { value = keyword1 },
                            keyword3 = new Common.WxPay.Lib.MsgValue() { value = DateTime.Now.ToString("yyyy-MM-dd") },
                            remark = new Common.WxPay.Lib.MsgValue() { value = remark },
                        }, ReturnUrl);
                    }


                    // 验证码发送过一次之后，就设为失效，5分钟之内不再重复发送
                    CSVC.SetCodeInvalid(toUser.TelePhone, codeStr);
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                }

                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }
    }
}