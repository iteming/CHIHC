//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SHOOT.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bis_Record
    {
        public string RecordID { get; set; }
        public string AccountID { get; set; }
        public string UserID { get; set; }
        public Nullable<int> Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
