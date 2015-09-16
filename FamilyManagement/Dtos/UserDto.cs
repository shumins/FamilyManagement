using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Provider.Model;
namespace FamilyManagement.Dtos
{
      [DataContract]
      [KnownType(typeof(UserDto))]

    public class UserDto:DtoBase
    {
          [DataMember]
         
          public string LoginName { get; set; }

          public string PassWord { get; set; }

          public string UserName { get; set; }

          public int Age { get; set; }
          public int Sex { get; set; }

          public string Phone { get; set; }
          public DateTime CreateTime { get; set; }
          public string PhotoUrl { get; set; }
          public bool isadmin { get; set; }

          public int Status { get; set; }

          public string ImgUrl { get; set; }
    }
      public static class UserDtoExtension
      {
          /// <summary>
          /// 转换为实体
          /// </summary>
          /// <param name="dto">数据传输对象</param>
          /// <returns></returns>
          public static User ToEntity(this UserDto dto)
          {
              return new User
              {
                  Id = dto.Id,
                  Sex = dto.Sex,
                  Age = dto.Age,
                  CreateTime = dto.CreateTime,
                  LoginName = dto.LoginName,
                  PassWord = dto.PassWord,
                  Phone = dto.Phone,
                  UserName = dto.UserName,
                  PhotoUrl = dto.PhotoUrl,
                  Isadmin = dto.isadmin,
                  Status=dto.Status,
                  ImgUrl=dto.ImgUrl
              };
          }


          /// <summary>
          /// 转换为数据传输对象
          /// </summary>
          /// <param name="entity">实体</param>
          public static UserDto ToDto(this User entity)
          {
              return new UserDto
              {
                  Id = entity.Id,
                  LoginName = entity.LoginName,
                  PassWord = entity.PassWord,
                  Age = entity.Age,
                  Sex = entity.Sex,
                  CreateTime = entity.CreateTime,
                  Phone = entity.Phone,
                  PhotoUrl = entity.Phone,
                  UserName = entity.UserName,
                  isadmin = entity.Isadmin,
                  Status=entity.Status,
                  ImgUrl=entity.ImgUrl

              };
          }
      }
}