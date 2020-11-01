using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class tblStudent
    {
       
        public tblStudent()
        {
            tblSemesters = new HashSet<tblSemester>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

       
        public virtual ICollection<tblSemester> tblSemesters { get; set; }
    }
}