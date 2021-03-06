﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class SemesterViewModel
    {
        [Key]
        public int SemesterId { get; set; }

        [Required]
        [StringLength(50)]
        public string SemesterName { get; set; }

        public int Duration { get; set; }

        public decimal Fee { get; set; }

        public int StudentId { get; set; }

       public string StudentName { get; set; }
    }
}