using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Model;


namespace Provider.Provider
{
    public interface IUserRepository:IBaseRepository<User>
    {
        string GetName();
    }
}
