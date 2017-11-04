using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Model.System
{
    public class Sys_Code : Base.BaseModel
    {
        public string TelePhone { get; set; }
        public string Code { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Invalid { get; set; }
        public Nullable<int> CodeType { get; set; }
    }
}
