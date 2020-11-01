using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class StudentViewModel
    {
     
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime DOB { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}