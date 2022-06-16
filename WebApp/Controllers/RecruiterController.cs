using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: Recruiter
        public ActionResult vRecruiterRegistration()
        {
            return View();
        }
        public ActionResult vRecruiterList()
        {
            return View();
        }
        public ActionResult vRecruiterUpdate(string id)
        {
            if (id != null)
            {
                ViewBag.IdRecruiter = id;
            }
            else
            {
                ViewBag.IdRecruiter = "null";
            }

            return View();
        }

        public ActionResult vRecruiterAccount(string id)
        {
            if (id != null)
            {
                ViewBag.IdRecruiter = id;
            }
            else
            {
                ViewBag.IdRecruiter = "null";
            }

            return View();
        }
    }
}