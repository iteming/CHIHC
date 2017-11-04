using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOOT.Utils
{
    public class AttributeDefine
    {
    }

    /// <summary>
    /// 使用该特性后访问asp.net mvc不需要进行Session超时验证
    /// </summary>
    public class NoSessionAuth : Attribute
    {
        public bool NeedAuth = false;
    }
}