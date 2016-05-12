using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Provider.Model
{
    public enum SexType
    {
        Male = 0,
        Female = 1,
    }

    public enum UserState
    {
        //冻结
        Frozen = 0,
        //正常
        Normal = 1,
       
    }


    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }

        public string PassWord { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }
        public int Sex { get; set; }

        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public string PhotoUrl { get; set; }
        public bool Isadmin { get; set; }

        public UserState Status { get; set; }

        public string ImgUrl { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
