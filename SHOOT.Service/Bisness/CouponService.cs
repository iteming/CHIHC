using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class CouponService : Base.BaseDao<Bis_Coupon>
    {
        public CouponService()
        {
            _TableName = "[Bis_Coupon]";
            _KeyName = "ID";
        }

        public Bis_Coupon GetCouponByOrderID(string OrderID)
        {
            var filter = string.Format(@" RecordID='{0}' ", OrderID);
            var Entity = base.SelectByFilter(filter).FirstOrDefault();
            return Entity;
        }

        /// <summary>
        /// 消费使用券
        /// </summary>
        /// <param name="Coupon"></param>
        /// <returns></returns>
        public ResultModel UseCouponByCoupon(string Coupon)
        {
            try
            {
                var filter = string.Format(@" Coupon='{0}' ", Coupon);
                var Entity = base.SelectByFilter(filter).FirstOrDefault();
                if (Entity != null)
                {
                    Entity.Status = (int)Common.Coupon_Status.Used;
                    base.Update(Entity);
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                }
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("消费使用券：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }

        /// <summary>
        /// 通过使用券获取订单明细
        /// </summary>
        /// <param name="Coupon"></param>
        /// <returns></returns>
        public ResultModel<List<Bis_Goods>> GetGoodsByCoupon(string Coupon)
        {
            try
            {
                var filter = string.Format(@" Coupon='{0}' ", Coupon);
                var Entity = base.SelectByFilter(filter).FirstOrDefault();
                if (Entity != null)
                {
                    List<Bis_RecordDetail> RDList = new RecordDetailService().SelectByFilter(string.Format(@" RecordID='{0}' ", Entity.RecordID));
                    string[] GoodIDs = RDList.Select(A => A.GoodID).ToArray();
                    string GFilter = string.Format(@" GoodID IN ('{0}')", string.Join("','", GoodIDs));
                    List<Bis_Goods> GList = new GoodService().SelectByFilter(GFilter);

                    return Common.MessageRes.OperateSuccess.SetResult<List<Bis_Goods>>(GList);
                }
                return Common.MessageRes.OperateFailed.SetResult<List<Bis_Goods>>(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("通过使用券获取订单明细：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<List<Bis_Goods>>(null);
            }
        }

        /// <summary>
        /// 提交保单信息
        /// </summary>
        /// <param name="CouponEntity"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public ResultModel SubmitInsurance(Bis_Coupon CouponEntity)
        {
            try
            {
                var Entity = base.SelectByID(CouponEntity.ID);
                if (Entity != null)
                {
                    Entity.InsuranceIdCard = CouponEntity.InsuranceIdCard;
                    Entity.InsuranceName = CouponEntity.InsuranceName;
                    Entity.InsurancePhone = CouponEntity.InsurancePhone;
                    Entity.InsuranceSex = CouponEntity.InsuranceSex;
                    Entity.InsuranceAddress = CouponEntity.InsuranceAddress;

                    base.Update(Entity);
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                }
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("提交保单信息：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }
    }
}
