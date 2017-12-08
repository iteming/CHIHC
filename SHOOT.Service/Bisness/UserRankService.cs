using SHOOT.Common.Modules;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOOT.Model.Base;

namespace SHOOT.Service.Bisness
{
    public class UserRankService : Base.BaseDao<Bis_UserRank>
    {
        public UserRankService()
        {
            _TableName = "[Bis_UserRank]";
            _KeyName = "ID";
        }

        /// <summary>
        /// 提交射击分数
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="Score"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public object SubmitScore(string OrderID, string Score, string UserID)
        {
            try
            {
                var rsvc = new RecordService();
                var cpsvc = new CouponService();
                var recordEntity = rsvc.SelectByFilter(string.Format(@" RecordID='{0}' AND UserID='{1}' ", OrderID, UserID)).FirstOrDefault();
                var couponEntity = cpsvc.SelectByFilter(string.Format(@" RecordID='{0}' AND UserID='{1}' ", OrderID, UserID)).FirstOrDefault();

                // 判断订单是否存在，且订单状态是否为已支付
                if (recordEntity != null && recordEntity.Status == (int)Common.Order_Status.Payed)
                {
                    var rankEntity = new Bis_UserRank
                    {
                        ID = Utils.CreateGUID(),
                        CreateTime = DateTime.Now,
                        Score = Convert.ToDecimal(Score),
                        UserID = UserID
                    };

                    if (base.Insert(rankEntity))
                    {
                        recordEntity.Status = (int)Common.Order_Status.End;
                        couponEntity.Status = (int)Common.Coupon_Status.Used;
                        if (rsvc.Update(recordEntity) && cpsvc.Update(couponEntity))
                        {
                            return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                        }
                    }
                }
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("提交射击分数：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }

        /// <summary>
        /// 获取排行榜列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<Dto_Rank> GetRankList(string UserID, int PageIndex = 0, int PageSize = 10)
        {
            try
            {
                string sql = string.Format(@" SELECT * FROM ({0}) AS A ", CommonSql(UserID));
                var resultList = base.GetData(sql).ToList<Dto_Rank>();
                var myEntity = resultList.Where(A => A.UserID == UserID).FirstOrDefault();
                if (myEntity != null)
                {
                    var newEntity = new Dto_Rank {
                        UserID = myEntity.UserID,
                        UserName = myEntity.UserName,
                        Rank = myEntity.Rank,
                        Score = myEntity.Score,
                        CreateTime = myEntity.CreateTime,
                        Focus = true,
                    };
                    resultList.Insert(0, newEntity);
                }
                return resultList.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("提交射击分数：" + Common.SessionTools.UserName, ex.ToString());
                return null;
            }
        }

        private string CommonSql(string UserID)
        {
            string tmpsql = string.Format(@"
                SELECT Row_Number() over(order by A.Score DESC) Rank ,A.UserID, U.UserName, A.Score, R.CreateTime
                FROM ( 
	                SELECT R.UserID, MAX(R.Score) AS Score
	                FROM Bis_UserRank AS R
	                GROUP BY R.UserID 
                ) AS A
                LEFT JOIN Sys_User AS U ON U.UserID = A.UserID
                LEFT JOIN Bis_UserRank AS R ON R.UserID = A.UserID AND R.Score = A.Score");

            return tmpsql;
        }
    }
}
