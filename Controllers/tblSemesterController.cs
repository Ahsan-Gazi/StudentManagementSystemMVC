using PagedList;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class tblSemesterController : Controller
    {
        missionDB db = new missionDB();
        [Authorize(Roles = "A,V")]
        // GET: tblSemester
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            List<SemesterViewModel> SmList = db.tblSemesters.Select(s => new SemesterViewModel
            {
                SemesterId = s.SemesterId,
                SemesterName = s.SemesterName,
                Duration = s.Duration,
                Fee = s.Fee,
                StudentId = s.tblStudent.StudentId,
                StudentName = s.tblStudent.StudentName
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
            var list = SmList;
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(s => s.SemesterName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(u => u.SemesterName).ToList();
                    break;
                default:
                    list = list.OrderBy(u => u.SemesterName).ToList();
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
        public ActionResult Create(SemesterViewModel Smvobj)
        {
            var result = false;
            try
            {
                tblSemester obj;
                if (Smvobj.SemesterId == 0)
                {
                    obj = new tblSemester();
                    obj.SemesterName = Smvobj.SemesterName;
                    obj.Duration = Smvobj.Duration;
                    obj.Fee = Smvobj.Fee;
                    obj.StudentId = Smvobj.StudentId;

                    //string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    //string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //vobj.ImageUrl = "~/Images/" + fileName;
                    //fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    //vobj.ImageFile.SaveAs(fileName);
                    //obj.ImageName = vobj.ImageName;
                    //obj.ImageUrl = vobj.ImageUrl;
                    db.tblSemesters.Add(obj);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    obj = db.tblSemesters.SingleOrDefault(u => u.SemesterId == Smvobj.SemesterId);
                    obj.SemesterName = Smvobj.SemesterName;
                    obj.Duration = Smvobj.Duration;
                    obj.Fee = Smvobj.Fee;
                    obj.StudentId = Smvobj.StudentId;


                    //string fileName = Path.GetFileNameWithoutExtension(vobj.ImageFile.FileName);
                    //string extension = Path.GetExtension(vobj.ImageFile.FileName);
                    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //vobj.ImageUrl = "~/Images/" + fileName;
                    //fileName = Path.Combine(Server.MapPath("~/Images/" + fileName));
                    //vobj.ImageFile.SaveAs(fileName);
                    //obj.ImageName = vobj.ImageName;
                    //obj.ImageUrl = vobj.ImageUrl;
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tblSemester obj = db.tblSemesters.SingleOrDefault(u => u.SemesterId == id);
            SemesterViewModel vobj = new SemesterViewModel();
            vobj.SemesterName = obj.SemesterName;
            vobj.Duration = obj.Duration;
            vobj.Fee = obj.Fee;
            vobj.StudentId = obj.StudentId;



            return View(vobj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblSemester obj = db.tblSemesters.SingleOrDefault(u => u.SemesterId == id);
            SemesterViewModel vobj = new SemesterViewModel();
            vobj.SemesterName = obj.SemesterName;
            vobj.Duration = obj.Duration;
            vobj.Fee = obj.Fee;
            vobj.StudentId = obj.StudentId;

            return View(vobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            tblSemester obj = db.tblSemesters.SingleOrDefault(u => u.SemesterId == id);
            if (obj != null)
            {
                db.tblSemesters.Remove(obj);
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
            tblSemester obj = db.tblSemesters.SingleOrDefault(u => u.SemesterId == id);
            SemesterViewModel vobj = new SemesterViewModel();
            vobj.SemesterName = obj.SemesterName;
            vobj.Duration = obj.Duration;
            vobj.Fee = obj.Fee;
            vobj.StudentId = obj.StudentId;


            ViewBag.Details = "Show";
            return PartialView("_SemesterDetails", vobj);
        }
    }
}