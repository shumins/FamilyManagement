using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Model;

namespace Provider.Provider {
    public class UserTokenRepository : BaseRepository<UserToken>,IUserTokenRepository {
        public UserTokenRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
       {
           UnitOfWork = unitOfWork;
       }

       protected new UnitOfWork UnitOfWork { get; private set; }
    }
}
