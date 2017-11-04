using SHOOT.Model.Base;
using SHOOT.Model.Bisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.Bisness
{
    public class GoodService : Base.BaseDao<Bis_Goods>
    {
        public GoodService()
        {
            _TableName = "[Bis_Goods]";
            _KeyName = "GoodID";
        }

        public ResultModel<List<Bis_Goods>> GetGoodData(Bis_Gift GiftEntity)
        {
            try
            {
                List<Bis_Goods> resultData = null;
                if (string.IsNullOrEmpty(GiftEntity.GiftID))
                {
                    resultData = base.SelectAll();
                }
                else 
                {
                    var GGFilter = string.Format(@" GiftID='{0}' ", GiftEntity.GiftID);
                    var GGResult = new GiftGoodService().SelectByFilter(GGFilter);
                    var GGIDList = GGResult.GroupBy(G=>G.GoodID).Select(A=>A.Key).ToArray();
                    var GGIDS = string.Join("','", GGIDList);

                    var Filter = string.Format(@" GoodID IN ('{0}') ", GGIDS);
                    resultData = base.SelectByFilter(Filter);
                }

                if (resultData != null)
                {
                    // 枪支数量
                    var gunCount = resultData.Where(A=>A.Type == (int)Common.Good_Type.Gun).Count();
                    foreach (var item in resultData)
                    {
                        // 该选项是否可选
                        if ((item.Type == (int)Common.Good_Type.Gun && gunCount > GiftEntity.Type1Count) ||
                            item.Type == (int)Common.Good_Type.Distance)
                            item.CanCheck = true;
                        else
                        {
                            item.CanCheck = false;
                            item.IsChecked = true;
                        }
                    }
                }
                return Common.MessageRes.OperateSuccess.SetResult<List<Bis_Goods>>(resultData);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("获取礼包下的商品列表：" + Common.SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<List<Bis_Goods>>(null);
            }
        }
    }
}
