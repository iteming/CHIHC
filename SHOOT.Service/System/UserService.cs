using SHOOT.Common;
using SHOOT.Common.Modules;
using SHOOT.Model;
using SHOOT.Model.Base;
using SHOOT.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.System
{
    public class UserService : Base.BaseDao<Sys_User>
    {
        public UserService()
        {
            _TableName = "[Sys_User]";
            _KeyName = "UserID";
        }

        public Sys_User GetUserBase(string UserID)
        {
            try
            {
                var entity = base.SelectByID(UserID);
                var accountEntity = new UserAccountService().SelectByFilter(string.Format(@" UserID='{0}' ", UserID)).FirstOrDefault();
                entity.Balance = accountEntity != null ? accountEntity.Balance??0 : Convert.ToDecimal(0);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Sys_User GetUserBaseByTelePhone(string Telephone)
        {
            try
            {
                var filter = string.Format(@" Telephone='{0}' ", Telephone);
                var entity = base.SelectByFilter(filter).FirstOrDefault();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Sys_User Regist(WxUserInfo UserEntity)
        {
            try
            {
                var filter = string.Format(" WeiXin_Openid='{0}' ", UserEntity.openid);
                var entity = base.SelectByFilter(filter).FirstOrDefault();
                if (entity == null)
                {
                    entity = new Sys_User
                    {
                        UserID = Utils.CreateGUID(),
                        UserName = UserEntity.nickname,
                        WeiXin_Openid = UserEntity.openid,
                        CreateTime = DateTime.Now,
                        HeaderUrl = UserEntity.headimgurl,
                        Sex = UserEntity.sex,
                    };


                    if (base.Insert(entity))
                        new UserAccountService().CreateAccount(entity.UserID);
                    else
                        return null;
                }
                else
                {
                    entity.UserName = UserEntity.nickname;
                    entity.Sex = UserEntity.sex;
                    entity.HeaderUrl = UserEntity.headimgurl;
                    if (!base.Update(entity))
                        return null;
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ResultModel<Sys_User> UpdateUserInfo(Sys_User UserEntity)
        {
            try
            {
                var entity = base.SelectByID(UserEntity.UserID);
                if (entity != null)
                {
                    entity.UserName = UserEntity.UserName;
                    entity.TelePhone = UserEntity.TelePhone;
                    entity.IdCard = UserEntity.IdCard;

                    if (base.Update(entity))
                        return Common.MessageRes.OperateSuccess.SetResult(entity);
                }
                return Common.MessageRes.OperateFailed.SetResult<Sys_User>(null);
            }
            catch (Exception ex)
            {
                MYLog.Error("完善用户信息：" + SessionTools.UserName, ex.ToString());
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult<Sys_User>(null);
            }
        }
    }
}
