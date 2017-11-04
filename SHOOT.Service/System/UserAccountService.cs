using SHOOT.Common.Modules;
using SHOOT.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.System
{
    public class UserAccountService : Base.BaseDao<Sys_UserAccount>
    {
        public UserAccountService()
        {
            _TableName = "[Sys_UserAccount]";
            _KeyName = "AccountID";
        }

        public bool CreateAccount(string UserID)
        {
            try
            {
                var entity = new Sys_UserAccount
                {
                    UserID = UserID,
                    AccountID = Utils.CreateGUID(),
                    Balance = 0,
                };
                return base.Insert(entity);
            }
            catch (Exception ex)
            {
                Common.MYLog.Error("创建用户财务账户：" + Common.SessionTools.UserName, ex.ToString());
                return false;
            }
        }
    }
}
