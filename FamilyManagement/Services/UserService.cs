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
                            Status = (int)u.Status,
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
            entity.Status = (UserState)status;
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

        #region 用户令牌相关

        public UserDto LoginByToken(string token)
        {
            var ut = DiUserTokenRepository.Find().FirstOrDefault(tut => tut.LoginToken == token);
            //用户令牌不存在
            if (ut == null)
                return null;
            //用户令牌已过期
            if (ut.ExpireTime < DateTime.Now)
                return null;
            var user = DiUserRepository.Find(ut.UserId);
            //用户已不存在
            if (user == null)
                throw new Warning(2002);

            //用户被冻结
            if (user.Status == UserState.Frozen)
                throw new Warning(1004);
            return user.ToDto();

        }

        /// <summary>
        /// 创建用户令牌
        /// 令牌有效期默认为7天
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expireHours">7*24=168</param>
        /// <returns></returns>
        public string GenerateUserToken(int userId, int expireHours = 168)
        {
            UserToken ut = new UserToken()
            {
                LoginToken = Guid.NewGuid().ToString().Replace("-", ""),
                ExpireTime = DateTime.Now.AddHours(expireHours),
                UserId = userId
            };

            DiUserTokenRepository.Add(ut);
            return ut.LoginToken;
        }

        /// <summary>
        /// 移除令牌
        /// </summary>
        /// <param name="token"></param>
        public void RemoveUserToken(string token) {
            var ut = DiUserTokenRepository.Find().SingleOrDefault(tut => tut.LoginToken == token);
            if (ut != null) DiUserTokenRepository.Delete(ut);
        }
        #endregion


    }
}