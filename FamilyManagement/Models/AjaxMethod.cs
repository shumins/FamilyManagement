using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyManagement.Models
{
    /// <summary>
    /// 仅用此特性表示该action是ajax的请求
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxMethodAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class IFrameMethodAttribute : Attribute
    {
    }
}
