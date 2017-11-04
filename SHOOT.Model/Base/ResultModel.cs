using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOOT.Common;

namespace SHOOT.Model.Base
{
    public class ResultModel<T>
    {
        /// <summary>
        /// 状态 0：失败 1：成功
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 影响行
        /// </summary>
        public uint recordCount { get; set; }

        public override string ToString()
        {
            return JsonHelper.SerializeObject(this);
        }

        public string ToString(string format)
        {
            return JsonHelper.SerializeObject(this, format);
        }
    }
    
    public class ResultModel
    {
        /// <summary>
        /// 状态 0：失败 1：成功
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 请求返回路径
        /// </summary>
        public string returnUrl { get; set; }

        public override string ToString()
        {
            return JsonHelper.SerializeObject(this);
        }

        public string ToString(string format)
        {
            return JsonHelper.SerializeObject(this, format);
        }
    }
}
