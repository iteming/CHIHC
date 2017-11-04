using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Model.Base
{
    public static class ResultMethod
    {
        /// <summary>
        /// 返回规则类（String）
        /// </summary>
        public static ResultModel SetResult(this string MsgStr, string ResultObj)
        {
            ResultModel result = new ResultModel();
            if (ResultObj == null)
                result.status = 0;
            else
                result.status = 1;
            result.msg = MsgStr;
            result.data = ResultObj;
            return result;
        }

        /// <summary>
        /// 返回规则类（String）
        /// </summary>
        public static ResultModel SetResult(this string MsgStr, string ResultObj, string returnUrl)
        {
            ResultModel result = new ResultModel();
            if (ResultObj == null && !string.IsNullOrEmpty(returnUrl)){
                result.status = 0;
                result.returnUrl = returnUrl;
            }
            else if (ResultObj == null)
                result.status = 0;
            else
                result.status = 1;
            result.msg = MsgStr;
            result.data = ResultObj;
            return result;
        }

        /// <summary>
        /// 返回规则类
        /// </summary>
        public static ResultModel<T> SetResult<T>(this string MsgStr, T ResultObj)
        {
            ResultModel<T> result = new ResultModel<T>();
            if (ResultObj == null)
                result.status = 0;
            else
                result.status = 1;
            result.msg = MsgStr;
            result.data = ResultObj;
            return result;
        }

        /// <summary>
        /// 返回规则类（带分页）
        /// </summary>
        public static ResultModel<T> SetResult<T>(this string MsgStr, T ResultObj, uint Count)
        {
            ResultModel<T> result = new ResultModel<T>();
            if (ResultObj == null)
                result.status = 0;
            else
                result.status = 1;
            result.msg = MsgStr;
            result.data = ResultObj;
            result.recordCount = Count;
            return result;
        }
    }
}
