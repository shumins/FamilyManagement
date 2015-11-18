
using FamilyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyManagement.Services;
using FamilyManagement.Dtos;


namespace FamilyManagement.Controllers
{
    public class AdminUserServiceController : BaseApiController
    {
        // GET: AdminUserService
        [HttpPost]
        public BaseResponse Login(string loginName, string password)
        {
           
            var user = DiUserService.Login(loginName, password);
            return new SuccessResponse();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse GetUserList(int pageSize, int page = 1)
        {
            var pager = new Pager(page, pageSize);
            var userList = DiUserService.GetUserList(pager);
            var rep = new SuccessListResponse<List<UserDto>>(userList, pager);
            return rep;
        }
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse UpdateUserState(int id, int status)
        {
            DiUserService.UpdateUserState(id, status);
            return new SuccessResponse();
        }

         [HttpPost]
        public string  IsExistUserName()
        {

            return "y";
        }
       


    }
}