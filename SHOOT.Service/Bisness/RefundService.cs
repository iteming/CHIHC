using SHOOT.Common;
using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class RefundService : Base.BaseDao<Bis_Refund>
    {
        public RefundService()
        {
            _TableName = "[Bis_Refund]";
            _KeyName = "RecordID";
        }


        /// <summary>
        /// 添加退款申请
        /// </summary>
        /// <returns></returns>
        public ResultModel AddRefundApply(string OrderID, string RefundNo, string UserID, string Remark, decimal? Amount) 
        {
            try
            {
                var entity = base.SelectByID(OrderID);
                if (entity == null)
                {
                    entity = new Bis_Refund
                    {
                        Amount = Amount,
                        CreateTime = DateTime.Now,
                        RecordID = OrderID,
                        RefundNo = RefundNo,
                        RefundStatus = (int)Order_Status.Refunding,
                        Remark = Remark,
                        UserID = UserID,
                    };

                    if (base.Insert(entity))
                    {
                        return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                    }
                }
                else
                {
                    entity.Amount = Amount;
                    entity.Remark = Remark;

                    //entity.CreateTime = DateTime.Now;
                    //entity.RefundNo = RefundNo;
                    //entity.RefundStatus = (int)Order_Status.Refunding;
                    //UserID = UserID;

                    if (base.Update(entity))
                    {
                        return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                    }
                }
                // 退款单已存在
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("新增退款申请单：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }


        public ResultModel UpdateRefundStatus(string OrderID, string OtherRefundNum, Order_Status Status)
        {
            try
            {
                var entity = base.SelectByID(OrderID);
                if (entity != null)
                {
                    entity.RefundStatus = (int)Status;
                    entity.OtherRefundNum = OtherRefundNum;

                    if (base.Update(entity))
                        return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                }
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("修改退款申请单状态：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }
    }
}
