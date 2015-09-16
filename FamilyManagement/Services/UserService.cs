using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Provider.Model;
using FamilyManagement.Dtos;
using Provider.Provider;
using FamilyManagement.Models;

namespace FamilyManagement.Services
{
    public class UserService:BaseService
    {
        public void CreateUser(User user)
        {
            DiUserRepository.Add(user);
        }

        public UserDto Login(string loginName, string password)
        {
           //UserRepository u = new UserRepository();
            //var user = u.Select(x => x.LoginName == loginName && x.PassWord == password).FirstOrDefault();
            var user = DiUserRepository.Select(x => x.LoginName == loginName && x.PassWord == password).FirstOrDefault();
              //用户名密码不存在
            if (user == null)
            {
                throw new Warning(1003);

            }
            //比较登录名是否相同,不相同则出错
            if (user.LoginName != loginName)
            {
                throw new Warning(1003);
            }
            return user.ToDto();

        }

        public List<UserDto> GetUserList(Pager pager)
        {
            var query = from u in DiUserRepository.Find()
                        select new UserDto()
                        {   
                            Id=u.Id,
                            LoginName = u.LoginName
                        };
          return  query.OrderByDescending(x => x.Id).Skip(pager.PageSize * (pager.Page - 1)).Take(pager.PageSize).ToList();

            // return DiUserRepository.Select<User>(pager.Page, pager.PageSize, out TotalCount, x => true, true, x => x).ToList();
        }
    }
}