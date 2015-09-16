using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagement.Services
{
    public class WarningMessage
    {
        private static Dictionary<int, string> _messageDic;
        public static Dictionary<int, string> MessageDic
        {
            get
            {
                if (_messageDic == null)
                {
                    _messageDic = new Dictionary<int, string>
                    {
                        {0, "非法操作"},                        
                        {498, "用户凭证已过期"},
                        {499, "权限不足"},

                        //1000 用户
                        {1000, "用户名不能为空"},
                        {1001, "密码不能为空"},
                        {1002, "用户名已存在"},
                        {1003, "用户名或密码不正确"},
                        {1004, "您的账户已被管理员冻结"},
                        {1005, "原密码不正确"},

                         //2000 用户令牌
                        {2000, "用户令牌不存在"},
                        {2001, "用户令牌已过期"},
                        {2002, "用户已不存在"},
                        
                         //3000 套餐
                        {3001, "套餐不存在"},
                        {3002, "用户不能升级到该套餐"},

                         //4000 测试
                        {4000, "测试不存在"},
                        {4001, "测试尚未存在"},
                        
                         //5000 后台管理账户
                        {5000, "管理员账号密码不正确"},

                         //6000 题目
                        {6000, "题目不存在"},

                        //10000 通用操作
                        {10000, "操作成功"},
                        {10001, "操作失败"},

                    };
                }

                return _messageDic;
            }
        }
    }

    /// <summary>
    /// 应用程序异常
    /// </summary>
    public class Warning : Exception
    {
        #region 构造方法
        /// <summary>
        /// 默认警告 非法操作.对象为Null 等
        /// </summary>
        public Warning()
        {
            int code = 0;
            Code = code;
            Message = WarningMessage.MessageDic[code];
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="code">错误消息</param>
        public Warning(int code)
        {
            Code = code;
            Message = WarningMessage.MessageDic[code];
        }

        public new string Message { get; private set; }

        public int Code { get; set; }

        #endregion
    }
}