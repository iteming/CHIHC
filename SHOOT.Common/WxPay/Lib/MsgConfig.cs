using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Common.WxPay.Lib
{
    /// <summary>
    /// 微信消息模版ID
    /// </summary>
    public class MsgConfig
    {
        /// <summary>
        /// 消费通知
        /// {{first.DATA}}
        /// 游戏名：{{keyword1.DATA}}
        /// 消费金额：{{keyword2.DATA}}
        /// 订单号：{{keyword3.DATA}}
        /// 时间：{{keyword4.DATA}}
        /// {{remark.DATA}}
        /// </summary>
        public static string Msg1 = "b02xlcYfo_2O9HLgsszkKLNXO9Moh8wKS0d1WnPHEfg";

        /// <summary>
        /// 退款通知
        /// {{first.DATA}}
        /// 退款金额：{{keyword1.DATA}}
        /// 订单号：{{keyword2.DATA}}
        /// 时间：{{keyword3.DATA}}
        /// {{remark.DATA}}
        /// </summary>
        public static string Msg2 = "KoeAGu_1wEEdMzFMRiUpq78b9YKtW2KWgQ3YwHxQDRU";

        /// <summary>
        /// 验证码提醒
        /// {{first.DATA}}
        /// 验证码类型：{{keyword1.DATA}}
        /// 验证码：{{keyword2.DATA}}
        /// {{remark.DATA}}
        /// </summary>
        public static string Msg3 = "3gaxfnEJljqa1Wj4sIrhqIGdPaWJHCZNVReR7RTpKFY";

        /// <summary>
        /// 申请确认通知
        /// {{first.DATA}}
        /// 申请人：{{keyword1.DATA}}
        /// 申请操作：{{keyword2.DATA}}
        /// 时间：{{keyword3.DATA}}
        /// {{remark.DATA}}
        /// </summary>
        public static string Msg4 = "ClsyE83zMkyOr7asyb5T2ROFrgUvscWvGtOfGZfz3g0";
    }

    public class MsgModel
    {
        public string touser { get; set; }
        public string template_id { get; set; }
        public string url { get; set; }
        public object data { get; set; }
    }

    public class MsgValue
    {
        public string value { get; set; }
        public string color { get { return "#000000"; } }
    }
}
