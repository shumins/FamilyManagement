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
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<UserDto> GetUserList(Pager pager)
        {
            var query = from u in DiUserRepository.Find()
                        select new UserDto()
                        {   

                            UserName = u.UserName,
                            Sex = u.Sex,
                            Age = u.Age,
                            Phone = u.Phone,
                            CreateTime = u.CreateTime,
                            Status = u.Status,
                            ImgUrl = u.ImgUrl,
                            isadmin = u.Isadmin,
                            PassWord = u.PassWord,
                            PhotoUrl=u.PhotoUrl,
                            Id = u.Id,
                            LoginName = u.LoginName,
                            Address=u.Address,
                            Email=u.Email

                        };
            pager.TotalCount = query.Count();
          return  query.OrderByDescending(x => x.Id).Skip(pager.PageSize * (pager.Page - 1)).Take(pager.PageSize).ToList();

            // return DiUserRepository.Select<User>(pager.Page, pager.PageSize, out TotalCount, x => true, true, x => x).ToList();
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void UpdateUserState(int id,int status)
        {
         var entity=DiUserRepository.Find().FirstOrDefault(x=>x.Id==id);
             //用户名密码不存在
            if (entity == null)
            {
                throw new Warning(10001);
            }
            entity.Status=status;
            DiUserRepository.Update(entity);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool IsExistUserName(string loginName)
        {
            return DiUserRepository.Exists(x => x.LoginName == loginName);
        }
        
    }
}