using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class RecordDetailService : Base.BaseDao<Bis_RecordDetail>
    {
        public RecordDetailService()
        {
            _TableName = "[Bis_RecordDetail]";
            _KeyName = "ID";
        }

    }
}
