﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}