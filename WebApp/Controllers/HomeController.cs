﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vCustomers()
        {
            
            return View();
        }

        public ActionResult vEnrollment()
        {

            return View();
        }

        public ActionResult vServices()
        {

            return View();
        }

        public ActionResult vNotices()
        {

            return View();
        }
    }
}