using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult vStudentRegistration()
        {
            return View();
        }


        public ActionResult vStudentList()
        {
            return View();
        }

        public ActionResult vStudentUpdate()
        {
            return View();

        }


    }
}