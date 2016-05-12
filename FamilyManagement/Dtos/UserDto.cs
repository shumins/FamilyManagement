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

           [DataMember]
          public string PassWord { get; set; }

           [DataMember]
          public string UserName { get; set; }

           [DataMember]
          public int Age { get; set; }
           [DataMember]
          public int Sex { get; set; }
           [DataMember]
          public string Phone { get; set; }
           [DataMember]
          public DateTime CreateTime { get; set; }
           [DataMember]
          public string PhotoUrl { get; set; }
           [DataMember]
          public bool isadmin { get; set; }
           [DataMember]

          public int Status { get; set; }
           [DataMember]

          public string ImgUrl { get; set; }

           [DataMember]
           public string Address { get; set; }

           [DataMember]
           public string Email { get; set; }

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
                  Status=(UserState)dto.Status,
                  ImgUrl=dto.ImgUrl,
                  Address=dto.Address,
                  Email=dto.Email

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
                  Status=(int)entity.Status,
                  ImgUrl=entity.ImgUrl,
                  Address=entity.Address,
                  Email=entity.Email

              };
          }
      }

   
}