using StudentManagementSystem.Models;
using StudentManagementSystem.Models.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
        
    {
        missionDB db = new missionDB();
        // GET: Register
        public ActionResult Index()
        {
            //ViewBag.RoleName = new SelectList(db.tblRoles, "Id", "RoleName");
            List<tblUser> userList = db.tblUsers.ToList();
            return View(userList);
        }
        [HttpGet]
        public ActionResult RegisterUser()
        {
            //ViewBag.RoleName = new SelectList(db.tblRoles, "Id", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserRoleViewModel obj)
        {
            tblUser u = new tblUser();
            u.UserName = obj.UserName;
            u.Password = obj.Password;
            db.tblUsers.Add(u);
            db.SaveChanges();

            tblRole r = new tblRole();
            r.RoleName = obj.RoleName;
            r.UserId = u.UserId;
            db.tblRoles.Add(r);
            db.SaveChanges();
            //ViewBag.RoleName = new SelectList(db.tblRoles, "Id", "RoleName");
            return RedirectToAction("Login", "Account");
           
           
        }
    }
}