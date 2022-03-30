using System;
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
        public ActionResult vRegisterStudent()
        {
            return View();
        }


        public ActionResult vListStudent()
        {
            return View();
        }

        public ActionResult vUpdateStudent()
        {
            return View();
     
        }



        public ActionResult vRegisterRecruiter()
        {
            return View();
        }


        public ActionResult vListRecruiter()
        {
            return View();
        }

        public ActionResult vUpdateRecruiter()
        {
            return View();
        }


        public ActionResult vRegisterFinancial()
        {
            return View();
        }


        public ActionResult vListFinancial()
        {
            return View();
        }

        public ActionResult vUpdateFinancial()
        {
            return View();
        }
    }
}