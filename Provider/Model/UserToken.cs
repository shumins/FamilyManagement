using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Model {
    /// <summary>
    /// 用户自动登录的表
    /// 作用方式：登陆时接收到自动登录请求，后台增加一个token跟用户绑定，发送token至浏览器保存，下次直接使用token就可以登录
    /// </summary>
    [Table("UserToken")]
   public class UserToken {
        public int Id { get; set; }
        /// <summary>
        /// 登录令牌
        /// 数据库设置唯一
        /// </summary>
        public string LoginToken { get; set; }

        /// <summary>
        /// 令牌失效时间
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 对应用户编号
        /// </summary>
        public long UserId { get; set; }
    }
}
