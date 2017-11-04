using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class GiftService : Base.BaseDao<Bis_Gift>
    {
        public GiftService()
        {
            _TableName = "[Bis_Gift]";
            _KeyName = "GiftID";
        }

        public ResultModel<List<Bis_Gift>> GetGiftsData()
        {
            try
            {
                var filter = string.Format(@" (ExpireDate IS NULL OR ExpireDate > '{0}') ", DateTime.Now.ToString("yyyy-MM-dd"));
                var resultData = base.SelectByFilter(filter);
                return Common.MessageRes.OperateSuccess.SetResult<List<Bis_Gift>>(resultData);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("获取礼包列表：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<List<Bis_Gift>>(null);
            }
        }
    }
}
