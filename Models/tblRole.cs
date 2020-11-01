using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class tblRole
    {
        public tblRole()
        {

        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Write A for Admin and V for Viewer")]
        [StringLength(50)]
        public string RoleName { get; set; }

        public int UserId { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}