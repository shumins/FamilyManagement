using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Model;

namespace Provider.Provider
{
    /**
     *  Author  : Arealty
     *  Function: 用户仓储
     *  Date    : 2013-04-09    
     *  Source  : http://www.cnblogs.com/shumin/
     * */
   public class UserRepository : BaseRepository<User>,IUserRepository
    {
       public UserRepository(UnitOfWork unitOfWork) 
           : base(unitOfWork)
       {
           UnitOfWork = unitOfWork;
       }

       protected new UnitOfWork UnitOfWork { get; private set; }

       public string GetName()
       {
           return "我是舒闵";
       }
   }
}
