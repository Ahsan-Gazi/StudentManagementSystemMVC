using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.EDMX
{
    public class missionDB:DbContext
    {
        public DbSet<tblStudent> TblStudents { get; set; }
        public DbSet<tblSemester> tblSemesters { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }
    }
}