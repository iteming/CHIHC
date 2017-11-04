using System;
using System.Collections.Generic;

namespace SHOOT.Model.Bisness
{
    public class Bis_Gift : Base.BaseModel
    {
        public string GiftID { get; set; }
        public string GiftName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public string ImgPath { get; set; }
        public Nullable<int> Type1Count { get; set; }
    }
}
