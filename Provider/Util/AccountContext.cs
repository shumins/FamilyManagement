using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Provider.Model;


namespace Provider.Util
{
    public class AccountContext:DbContext
    {
        /// <summary>
        /// Entity Framework工作单元
        /// </summary>
        public AccountContext()
            : base("connectionName")
        {
        }
        #region 实体集
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> UserRepo { get; set; }
        /// <summary>
        /// 用户登录令牌
        /// </summary>
        public DbSet<UserToken> UserTokenRepo { get; set; }
        #endregion
    }
}
