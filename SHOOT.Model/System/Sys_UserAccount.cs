using System;
using System.Collections.Generic;

namespace SHOOT.Model.System
{
    public class Sys_UserAccount : Base.BaseModel
    {
        public string AccountID { get; set; }
        public string UserID { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
