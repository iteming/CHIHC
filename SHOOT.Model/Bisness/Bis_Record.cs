using System;
using System.Collections.Generic;

namespace SHOOT.Model.Bisness
{
    public class Bis_Record : Base.BaseModel
    {
        public string RecordID { get; set; }
        public string AccountID { get; set; }
        public string UserID { get; set; }
        public Nullable<int> Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<DateTime> UpdateTime { get; set; }
        public Nullable<int> Status { get; set; }
        public string StatusName { get; set; }
        public string OrderNo { get; set; }
        public string OtherOrderNum { get; set; }
    }
}
