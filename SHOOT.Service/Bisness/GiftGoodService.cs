using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class GiftGoodService : Base.BaseDao<Bis_GiftGood>
    {
        public GiftGoodService()
        {
            _TableName = "[Bis_GiftGood]";
            _KeyName = "ID";
        }
    }
}
