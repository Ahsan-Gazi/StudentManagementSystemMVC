using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class tblUser
    {
   
        public tblUser()
        {
            tblRoles = new HashSet<tblRole>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
       
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required(ErrorMessage ="ConfirmPassword is requred")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }



        public virtual ICollection<tblRole> tblRoles { get; set; }
    }
}