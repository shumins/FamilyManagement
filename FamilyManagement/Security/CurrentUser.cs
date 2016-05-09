using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagement.Security {
     [Serializable]
    public class CurrentUser {
        /// <summary>
        /// 登录用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginName { get; set; }
    }
}