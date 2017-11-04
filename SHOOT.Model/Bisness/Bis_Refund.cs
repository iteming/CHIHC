using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Model.Bisness
{
    public class Bis_Refund : Base.BaseModel
    {
        public string RecordID { get; set; }
        public string UserID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Remark { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<int> RefundStatus { get; set; }
        public string RefundNo { get; set; }
        public string OtherRefundNum { get; set; }
    }
}
