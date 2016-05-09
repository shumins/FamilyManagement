
using FamilyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using FamilyManagement.Security;
using FamilyManagement.Services;
using FamilyManagement.Dtos;


namespace FamilyManagement.Controllers
{
    public class Ex
    {
        public string info { get; set; }
        public string status { get; set; }
    }

    public class AdminUserServiceController : BaseApiController
    {  

        
        // GET: AdminUserService
        [HttpPost]
        public BaseResponse Login(string loginName, string password)
        {
           
            var user = DiUserService.Login(loginName, password);
            Context.SetUser(new CurrentUser
            {
                UserId = user.Id,
                LoginName = user.LoginName
            });
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
        public HttpResponseMessage IsExistUserName()
         {
             //webapi跟传统request的区别
             HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
             HttpRequestBase request = context.Request;//定义传统request对象
             string name = request["param"];
             var falg= DiUserService.IsExistUserName(name);
             if (falg)
             {
                 Ex i = new Ex {info = "账号已存在！", status = "n"};
                 JavaScriptSerializer serializer = new JavaScriptSerializer();
                 string str = serializer.Serialize(i);
                 HttpResponseMessage result = new HttpResponseMessage
                 {
                     Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json")
                 };
                 return result;
             }
             else
             {
                 Ex i = new Ex { info = "验证通过！", status = "y" };
                 JavaScriptSerializer serializer = new JavaScriptSerializer();
                 string str = serializer.Serialize(i);
                 HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                 return result;
             }


         }
       


    }
}