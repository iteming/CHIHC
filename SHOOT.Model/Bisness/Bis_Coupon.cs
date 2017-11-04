using System;
using System.Collections.Generic;

namespace SHOOT.Model.Bisness
{
    public class Bis_Coupon : Base.BaseModel
    {
        //public string ID { get; set; }
        public string RecordID { get; set; }
        public string UserID { get; set; }
        public string Coupon { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }

        // 姓名，身份证号，手机号，性别，地址（选填），手机验证码（）

        public string InsuranceName { get; set; }
        public string InsuranceIdCard { get; set; }
        public string InsurancePhone { get; set; }
        /// <summary>
        /// 1 男 2 女
        /// </summary>
        public Nullable<int> InsuranceSex { get; set; }
        public string InsuranceAddress { get; set; }
    }
}
