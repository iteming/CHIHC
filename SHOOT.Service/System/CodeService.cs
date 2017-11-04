using SHOOT.Common;
using SHOOT.Common.Modules;
using SHOOT.Model.Base;
using SHOOT.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Service.System
{
    public class CodeService : Base.BaseDao<Sys_Code>
    {
        public CodeService()
        {
            _TableName = "[Sys_Code]";
            _KeyName = "ID";
        }

        public string CreateCode(string TelePhone, int CodeType)
        {
            try
            {
                var filter = string.Format(@" TelePhone='{0}' AND CreateTime>'{1}' AND CodeType={2} ", TelePhone, DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss:fff"), CodeType);
                var entity = base.SelectByFilter(filter, " CreateTime DESC ").FirstOrDefault();
                // 如果效验码存在并且未失效，则返回效验码
                if (entity != null && entity.Invalid == false)
                    return entity.Code;
                // 如果效验码存在并且已失效，则返回空，不再重复发送效验码
                else if (entity != null && entity.Invalid == true)
                    return string.Empty;

                // 如果效验码已过期，则生成新的效验码
                entity = new Sys_Code
                {
                    ID = Utils.CreateGUID(),
                    Code = Utils.GetRandomNum(6),
                    CreateTime = DateTime.Now,
                    TelePhone = TelePhone,
                    Invalid = false,
                    CodeType = CodeType
                };
                if (base.Insert(entity))
                    return entity.Code;

                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public ResultModel SetCodeInvalid(string TelePhone, string codeStr)
        {
            try
            {
                var filter = string.Format(@" TelePhone='{0}' AND Code='{1}' AND CreateTime>'{2}' AND Invalid=0 ", TelePhone, codeStr, DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss:fff"));
                var entity = base.SelectByFilter(filter, " CreateTime DESC ").FirstOrDefault();
                if (entity != null)
                {
                    // 设为失效
                    entity.Invalid = true;
                    base.Update(entity);
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");
                }
                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }

        public ResultModel ValidateCode(string TelePhone, string Code) 
        {
            try
            {
                var filter = string.Format(@" TelePhone='{0}' AND Code='{1}' AND CreateTime>'{2}' AND Invalid=1 ", TelePhone, Code, DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss:fff"));
                var entity = base.SelectByFilter(filter, " CreateTime DESC ").FirstOrDefault();
                if (entity != null)
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");

                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }

        public ResultModel ValidateCodeWithOutTime(string TelePhone, string Code, Code_Type CodeType) 
        {
            try
            {
                var filter = string.Format(@" TelePhone='{0}' AND Code='{1}' AND CodeType={2} AND Invalid=1 ",
                    TelePhone, Code, (int)CodeType);
                var entity = base.SelectByFilter(filter, " CreateTime DESC ").FirstOrDefault();
                if (entity != null)
                    return Common.MessageRes.OperateSuccess.SetResult("SUCCESS");

                return Common.MessageRes.OperateFailed.SetResult(null);
            }
            catch (Exception ex)
            {
                return (Common.MessageRes.OperateException + ex.ToString()).SetResult(null);
            }
        }
    }
}
