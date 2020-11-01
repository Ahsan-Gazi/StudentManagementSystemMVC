using PagedList;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.EDMX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class tblStudentController : Controller
    {
        missionDB db = new missionDB();
        [Authorize(Roles = "A,V")]
        // GET: tblStudent
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            List<StudentViewModel> userList = db.TblStudents.Select(u => new StudentViewModel
            {
                StudentId = u.StudentId,
                StudentName = u.StudentName,
                Email = u.Email,
                DOB = u.DOB,
                ImageName = u.ImageName,
                ImageUrl = u.ImageUrl
            }).ToList();
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;

            var list = userList;
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(u => u.StudentName.ToUpper().
                Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(u => u.StudentName).ToList();
                    break;
                default:
                    list = list.OrderBy(u => u.StudentName).ToList();
                    break;
            }
            int PageSize = 3;
            int PageNumber = (page ?? 1);

            return View(list.ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentViewModel vobj)
        {
            var result = false;
            try
            {
                tblStudent obj;
                if (vobj.StudentId == 0)
                {
                    obj = new tblStudent();
                    obj.StudentName = vobj.StudentName;
                    obj.Email = vobj.Email;
                    obj.DOB = vobj.DOB;
                    string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    vobj.ImageUrl = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    vobj.ImageFile.SaveAs(fileName);
                    obj.ImageName = vobj.ImageName;
                    obj.ImageUrl = vobj.ImageUrl;
                    db.TblStudents.Add(obj);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    obj = db.TblStudents.SingleOrDefault(u => u.StudentId == vobj.StudentId);
                    obj.StudentName = vobj.StudentName;
                    obj.Email = vobj.Email;
                    obj.DOB = vobj.DOB;
                    string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    vobj.ImageUrl = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    vobj.ImageFile.SaveAs(fileName);
                    obj.ImageName = vobj.ImageName;
                    obj.ImageUrl = vobj.ImageUrl;
                    db.SaveChanges();
                    result = true;

                }
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tblStudent obj = db.TblStudents.SingleOrDefault(u => u.StudentId == id);
            StudentViewModel vobj = new StudentViewModel();
            vobj.StudentName = obj.StudentName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            vobj.StudentId = obj.StudentId;
          
            return View(vobj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblStudent obj = db.TblStudents.SingleOrDefault(u => u.StudentId == id);
            StudentViewModel vobj = new StudentViewModel();
            vobj.StudentName = obj.StudentName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            vobj.StudentId = obj.StudentId;
            return View(vobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            tblStudent obj = db.TblStudents.SingleOrDefault(u => u.StudentId == id);
            if (obj != null)
            {
                db.TblStudents.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }
        public PartialViewResult Details(int id)
        {
            tblStudent obj = db.TblStudents.SingleOrDefault(u => u.StudentId == id);
            StudentViewModel vobj = new StudentViewModel();
            vobj.StudentName = obj.StudentName;
            vobj.Email = obj.Email;
            vobj.DOB = obj.DOB;
            vobj.ImageName = obj.ImageName;
            vobj.ImageUrl = obj.ImageUrl;
            vobj.StudentId = obj.StudentId;
            ViewBag.Details = "Show";
            return PartialView("_UserDetails", vobj);
        }
    }
}