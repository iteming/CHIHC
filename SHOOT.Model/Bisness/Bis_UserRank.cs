using System;
using System.Collections.Generic;

namespace SHOOT.Model.Bisness
{
    public class Bis_UserRank : Base.BaseModel
    {
        //public string ID { get; set; }
        public string UserID { get; set; }
        public Nullable<decimal> Score { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
    }
}
