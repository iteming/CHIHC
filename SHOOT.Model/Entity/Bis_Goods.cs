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
    
    public partial class Bis_Goods
    {
        public string GoodID { get; set; }
        public string GoodName { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string ImgPath { get; set; }
    }
}
