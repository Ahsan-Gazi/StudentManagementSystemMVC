using StudentManagementSystem.Models;
using StudentManagementSystem.Models.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        missionDB db = new missionDB();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser obj)
        {
            var count = db.tblUsers.Where(u => u.UserName == obj.UserName && u.Password == obj.Password).Count();
            if (count<=0)
            {
                ViewBag.Message = "Invalid User"; 
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}