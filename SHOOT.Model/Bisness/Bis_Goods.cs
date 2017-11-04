using System;
using System.Collections.Generic;

namespace SHOOT.Model.Bisness
{
    public class Bis_Goods : Base.BaseModel
    {
        public string GoodID { get; set; }
        public string GoodName { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public string ImgPath { get; set; }
        /// <summary>
        /// �Ƿ�ѡ��
        /// </summary>
        public bool IsChecked { get; set; }
        /// <summary>
        /// �Ƿ���Ա�ѡ��
        /// </summary>
        public bool CanCheck { get; set; }
    }
}
