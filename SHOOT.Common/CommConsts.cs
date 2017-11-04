using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHOOT.Common
{
    public class CommConsts
    {
        public static string MD5Code(string code, Encoding encoding)
        {
            return HttpUtility.UrlEncode(code, encoding);
        }
        public static string UrlEncode(string Url)
        {
            return HttpUtility.UrlEncode(Url);
        }
    }

    public enum Good_Type
    {
        /// <summary>
        /// 枪支
        /// </summary>
        Gun = 1,
        /// <summary>
        /// 子弹
        /// </summary>
        Bullet = 2,
        /// <summary>
        /// 距离
        /// </summary>
        Distance = 3,
        /// <summary>
        /// 保险
        /// </summary>
        Insurance = 4,
    }

    public enum Order_Type
    {
        /// <summary>
        /// 充值
        /// </summary>
        Recharge = 1,
        /// <summary>
        /// 消费
        /// </summary>
        Consume = 2,
    }

    public enum Order_Status
    {
        /// <summary>
        /// 1.未支付
        /// </summary>
        NotPay = 1,
        /// <summary>
        /// 2.已支付
        /// </summary>
        Payed = 2,
        /// <summary>
        /// 3.退款中
        /// </summary>
        Refunding = 3,
        /// <summary>
        /// 4.已退款
        /// </summary>
        Refunded = 4,
        /// <summary>
        /// 5.结束订单
        /// </summary>
        End = 5,
    }

    public enum Coupon_Status
    {
        /// <summary>
        /// 1.未使用
        /// </summary>
        NotUse = 1,
        /// <summary>
        /// 2.已使用
        /// </summary>
        Used = 2,
    }

    /// <summary>
    /// 验证码
    /// </summary>
    public enum Code_Type
    {
        /// <summary>
        /// 1.成绩录入
        /// </summary>
        Rank = 1,
        /// <summary>
        /// 2.退款申请
        /// </summary>
        Refund = 2,
    }
}
