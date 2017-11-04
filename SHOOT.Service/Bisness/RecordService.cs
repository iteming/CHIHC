using SHOOT.Common.Modules;
using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using SHOOT.Service.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class RecordService : Base.BaseDao<Bis_Record>
    {
        public RecordService()
        {
            _TableName = "[Bis_Record]";
            _KeyName = "RecordID";
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="otherOrderNum"></param>
        /// <returns></returns>
        public ResultModel<Bis_Record> ModifyOrderStatus(string orderNo, string otherOrderNum)
        {
            // 修改订单状态，订单生成使用券/充值修改账户余额
            try
            {
                var RecFilter = string.Format(@" OrderNo='{0}' ", orderNo);
                var recordEntity = base.SelectByFilter(RecFilter).FirstOrDefault();
                if (recordEntity != null)
                {
                    recordEntity.Status = (int)Common.Order_Status.Payed;
                    recordEntity.OtherOrderNum = otherOrderNum;
                    recordEntity.UpdateTime = DateTime.Now;

                    // 修改订单状态
                    if (base.Update(recordEntity))
                    {
                        this.PaySuccessAfter(recordEntity);
                        return Common.MessageRes.OperateSuccess.SetResult<Bis_Record>(recordEntity);
                    }
                }
                return Common.MessageRes.OperateFailed.SetResult<Bis_Record>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("修改订单状态：" + Common.SessionTools.UserName, ("订单编号：" + orderNo + " " + ex.ToString()));
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Bis_Record>(null);
            }
        }

        /// <summary>
        /// 订单退款申请
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public ResultModel<Bis_Record> RefundOrder(string OrderID)
        {
            // 修改订单状态，订单生成使用券/充值修改账户余额
            try
            {
                var recordEntity = base.SelectByID(OrderID);
                if (recordEntity != null)
                {
                    recordEntity.Status = (int)Common.Order_Status.Refunding;
                    recordEntity.UpdateTime = DateTime.Now;

                    // 修改订单状态
                    if (base.Update(recordEntity))
                    {
                        this.RefundSuccessAfter(recordEntity);
                        return Common.MessageRes.OperateSuccess.SetResult<Bis_Record>(recordEntity);
                    }
                }
                return Common.MessageRes.OperateFailed.SetResult<Bis_Record>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("修改订单退款状态：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Bis_Record>(null);
            }
        }

        /// <summary>
        /// 订单退款申请
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public ResultModel<Bis_Record> ModifyOrderStatusRefund(string orderNo, string otherOrderNum)
        {
            // 修改订单状态
            try
            {
                var RecFilter = string.Format(@" OrderNo='{0}' ", orderNo);
                var recordEntity = base.SelectByFilter(RecFilter).FirstOrDefault();
                if (recordEntity != null)
                {
                    recordEntity.Status = (int)Common.Order_Status.Refunded;
                    recordEntity.UpdateTime = DateTime.Now;

                    // 修改订单状态
                    if (base.Update(recordEntity))
                    {
                        return Common.MessageRes.OperateSuccess.SetResult<Bis_Record>(recordEntity);
                    }
                }
                return Common.MessageRes.OperateFailed.SetResult<Bis_Record>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("修改订单退款状态：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Bis_Record>(null);
            }
        }

        private void RefundSuccessAfter(Bis_Record recordEntity)
        {
            try
            {
                if (recordEntity.Type == (int)Common.Order_Type.Consume)
                {
                    // 消费成功，生成使用券
                    CouponService CPSVC = new CouponService();
                    var filter = string.Format(@" RecordID='{0}' AND UserID='{1}'", recordEntity.RecordID, recordEntity.UserID);
                    var cpEntity = CPSVC.SelectByFilter(filter).FirstOrDefault();
                    if (cpEntity != null)
                    {
                        cpEntity.Status = (int)Common.Coupon_Status.Used;
                        CPSVC.Update(cpEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("修改使用券退款状态：" + Common.SessionTools.UserName, ("订单编号：" + recordEntity.OrderNo + " " + ex.ToString()));
            }
        }

        /// <summary>
        /// 订单生成使用券/充值修改账户余额
        /// </summary>
        /// <param name="recordEntity">订单记录</param>
        private void PaySuccessAfter(Bis_Record recordEntity)
        {
            try
            {
                if (recordEntity.Type == (int)Common.Order_Type.Consume)
                {
                    // 消费成功，生成使用券
                    CouponService CPSVC = new CouponService();
                    var filter = string.Format(@" RecordID='{0}' AND UserID='{1}'", recordEntity.RecordID, recordEntity.UserID);
                    var cpEntity = CPSVC.SelectByFilter(filter).FirstOrDefault();
                    if (cpEntity == null)
                    {
                        cpEntity = new Bis_Coupon
                        {
                            ID = Utils.CreateGUID(),
                            Coupon = Utils.GetCoupon(Convert.ToInt64(Utils.GetRandomNum())),
                            ExpireDate = DateTime.Now.AddMonths(1),
                            RecordID = recordEntity.RecordID,
                            Status = (int)Common.Coupon_Status.NotUse,
                            UserID = recordEntity.UserID,
                        };
                        CPSVC.Insert(cpEntity);
                    }
                }
                else 
                {
                    // 充值成功，充值到余额
                    Service.System.UserAccountService UASVC = new UserAccountService();
                    var filter = string.Format(@" UserID='{0}'", recordEntity.UserID);
                    var uaEntity = UASVC.SelectByFilter(filter).FirstOrDefault();
                    if (uaEntity != null)
                    {
                        uaEntity.Balance += recordEntity.Amount;
                        UASVC.Update(uaEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("订单生成使用券/充值修改账户余额：" + Common.SessionTools.UserName, ("订单编号：" + recordEntity.OrderNo + " " + ex.ToString()));
            }
        }

        /// <summary>
        /// 提交消费订单
        /// </summary>
        /// <param name="GiftEntity"></param>
        /// <param name="GoodList"></param>
        /// <returns></returns>
        public ResultModel<Bis_Record> SubmitOrder(Bis_Gift GiftEntity, List<Bis_Goods> GoodList, string UserID)
        {
            try
            {
                var UserAccount = new UserAccountService().SelectByFilter(string.Format(@" UserID='{0}'", UserID)).FirstOrDefault();
                var recordEntity = new Bis_Record
                {
                    RecordID = Utils.CreateGUID(),
                    Amount = GiftEntity.Price ?? 0,
                    CreateTime = DateTime.Now,
                    Description = CreateOrderDesc(Common.Order_Type.Consume, GiftEntity, null),
                    OrderNo = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    Status = (int)Common.Order_Status.NotPay,
                    Type = (int)Common.Order_Type.Consume,
                    UserID = UserID,
                    AccountID = UserAccount != null ? UserAccount.AccountID : string.Empty,
                };
                var recordDetail = new List<Bis_RecordDetail>();
                var tmpGoodList = GoodList.Where(A => A.IsChecked == true).ToList();
                foreach (var item in tmpGoodList)
                {
                    recordDetail.Add(new Bis_RecordDetail
                    {
                        ID = Utils.CreateGUID(),
                        RecordID = recordEntity.RecordID,
                        GoodID = item.GoodID
                    });
                }
                if (base.Insert(recordEntity))
                {
                    if (new RecordDetailService().Insert(recordDetail))
                        return Common.MessageRes.OperateSuccess.SetResult<Bis_Record>(recordEntity);
                }
                return Common.MessageRes.OperateFailed.SetResult<Bis_Record>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("提交消费订单：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Bis_Record>(null);
            }
        }

        /// <summary>
        /// 提交充值订单
        /// </summary>
        /// <param name="GiftEntity"></param>
        /// <param name="GoodList"></param>
        /// <returns></returns>
        public ResultModel<Bis_Record> SubmitRecharge(decimal Amount, string UserID)
        {
            try
            {
                var UserAccount = new UserAccountService().SelectByFilter(string.Format(@" UserID='{0}'", UserID)).FirstOrDefault();
                var recordEntity = new Bis_Record
                {
                    RecordID = Utils.CreateGUID(),
                    Amount = Amount,
                    CreateTime = DateTime.Now,
                    Description = CreateOrderDesc(Common.Order_Type.Recharge, null, Amount),
                    OrderNo = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    Status = (int)Common.Order_Status.NotPay,
                    Type = (int)Common.Order_Type.Recharge,
                    UserID = UserID,
                    AccountID = UserAccount != null ? UserAccount.AccountID : string.Empty,
                };

                if (base.Insert(recordEntity))
                    return Common.MessageRes.OperateSuccess.SetResult<Bis_Record>(recordEntity);
                else
                    return Common.MessageRes.OperateFailed.SetResult<Bis_Record>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("提交充值订单：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Bis_Record>(null);
            }
        }

        private string CreateOrderDesc(Common.Order_Type OType, Bis_Gift GiftEntity, decimal? Amount)
        {
            if (OType == Common.Order_Type.Consume)
                return string.Format(@"【中猎国际俱乐部】商品名称：{0}, 商品描述：{1}", GiftEntity.GiftName, GiftEntity.Description);
            else
                return string.Format(@"【中猎国际俱乐部】充值金额：{0}", Amount);
        }

        /// <summary>
        /// 获取未结束订单
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public Bis_Record GetNoEndOrder(string UserID) 
        {
            try
            {
                var filter = string.Format(@" UserID='{0}' AND Type='{1}' AND Status='{2}'", UserID, (int)Common.Order_Type.Consume, (int)Common.Order_Status.Payed);
                var entity = base.SelectByFilter(filter).FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("获取未结束订单：" + Common.SessionTools.UserName, ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取用户订单列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<Bis_Record> GetOrderList(string UserID)
        {
            try
            {
                var filter = string.Format(@" UserID='{0}' ", UserID);
                var recordList = base.SelectByFilter(filter, " CreateTime ");
                if (recordList == null)
                    return new List<Bis_Record>();

                foreach (var item in recordList)
	            {
                    item.StatusName = SetStatusName(item.Status);
	            }
                return recordList;
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("获取用户订单列表：" + Common.SessionTools.UserName, ex.ToString());
                return null;
            }
        }

        private string SetStatusName(Nullable<int> Status)
        {
            if (Status == null)
                return "未知";

            switch (Status.Value)
            {
                case (int)Common.Order_Status.NotPay:
                    return "未支付";
                case (int)Common.Order_Status.Payed:
                    return "已支付";
                case (int)Common.Order_Status.Refunding:
                    return "退款中";
                case (int)Common.Order_Status.Refunded:
                    return "已退款";
                case (int)Common.Order_Status.End:
                    return "已结束";
                default:
                    return "未知";
            }
        }
    }
}
