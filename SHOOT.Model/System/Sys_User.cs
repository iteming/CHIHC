using System;
using System.Collections.Generic;

namespace SHOOT.Model.System
{
    public class Sys_User : Base.BaseModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string IdCard { get; set; }
        public string TelePhone { get; set; }
        public string Password { get; set; }
        public string WeiXin_Openid { get; set; }
        public string QQ_Openid { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<bool> IsSuper { get; set; }
        public string HeaderUrl { get; set; }
        /// <summary>
        /// 1 ÄÐ 2 Å®
        /// </summary>
        public Nullable<int> Sex { get; set; }
        public decimal Balance { get; set; }
    }
}
