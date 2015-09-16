using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

using FamilyManagement.Services;

namespace FamilyManagement.Models
{
    public enum HttpResponseState
    {
        Error = 0,
        Success = 1
    }

    /// <summary>
    /// 前后端通信实体基类
    /// </summary>

    [DataContract]
    public abstract class BaseResponse
    {
        public static readonly int SuccessCode = 10000;

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public int State { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        [DataMember]
        public int Code { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class SuccessResponse<T> : BaseResponse
    {

        /// <summary>
        /// 返回类型
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public Pager Paper { get; set; }

        public SuccessResponse(HttpResponseState state, int code, string message, T data)
        {
            State = (int)state;
            Code = code;
            Message = message;
            Data = data;
        }

        public SuccessResponse(T data)
            : this(HttpResponseState.Success, SuccessCode, WarningMessage.MessageDic[SuccessCode], data)
        {

        }
    }

    public class SuccessResponse : SuccessResponse<object>
    {
        public SuccessResponse(HttpResponseState state, int code, string message, object data)
            : base(state, code, message, data)
        {

        }

        public SuccessResponse(object data)
            : base(data)
        {

        }

        public SuccessResponse()
            : base(null)
        {

        }
    }

    /// <summary>
    /// 成功列表对象
    /// </summary>
    public class SuccessListResponse<T> : BaseResponse
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        [DataMember]
        public T List { get; set; }

        [DataMember]
        public Pager Pager { get; set; }

        public SuccessListResponse(HttpResponseState state, int code, string message, T list, Pager pager)
        {
            State = (int)state;
            Code = code;
            Message = message;
            List = list;
            Pager = pager;
        }

        public SuccessListResponse(T list, Pager pager)
            : this(HttpResponseState.Success, SuccessCode, WarningMessage.MessageDic[SuccessCode], list, pager)
        {

        }
    }


    [KnownType(typeof(ErrorResponse))]
    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse(int code, string message)
        {
            State = (int)HttpResponseState.Error;
            Code = code;
            Message = message;
        }

        public ErrorResponse(Warning warning)
            : this(warning.Code, warning.Message)
        {

        }
    }
}