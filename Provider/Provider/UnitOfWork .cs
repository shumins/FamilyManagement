using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Util;
using System.Data;
using System.Data.Entity;
using Provider.Model;


namespace Provider.Provider
{
    public class UnitOfWork : DbContext,IUnitOfWork
    {

       //private AccountContext Content;
       //public UnitOfWork(AccountContext content)
       //{
       //    this.Content = content;
       //}
        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="connectionName">连接字符串的名称</param>
      /// <summary>
        /// Entity Framework工作单元
        /// </summary>
       public UnitOfWork()
            : base("connectionName")
        {
        }
        #region 实体集
        public DbSet<User> UserRepo { get; set; }
        /// <summary>
        /// 用户登录令牌
        /// </summary>
        public DbSet<UserToken> UserTokenRepo { get; set; }
        #endregion


        /// <summary>
        /// 启动标识
        /// </summary>
       public bool IsStart
       {
           get;
           set;
       }



       /// <summary>
       /// 启动
       /// </summary>
       public void Start()
       {
           IsStart = true;
       }

       /// <summary>
       /// 提交更新
       /// </summary>
       public void Save()
       {

           try
           {
               SaveChanges();
           }
           finally
           {
               IsStart = false;
           }
       }


       /// <summary>
       /// 通过启动标识执行提交，如果已启动，则不提交
       /// </summary>
       public void SaveByStart()
       {
           if (IsStart)
               return;
           Save();
       }
    }
}
