using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Model.Bisness
{
    public class Dto_Rank
    {
        /// <summary>
        /// 名次
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public decimal Score { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public Nullable<DateTime> CreateTime { get; set; }
        public bool Focus { get; set; }
    }
}
