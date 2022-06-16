using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: Financial
        public ActionResult vSysAdminRegistration()
        {
            return View();
        }
        public ActionResult vSysAdminList()
        {
            return View();
        }
        public ActionResult vSysAdminUpdate(string id)
        {
            if (id != null)
            {
                ViewBag.IdSysAdmin = id;
            }
            else
            {
                ViewBag.IdSysAdmin = "null";
            }

            return View();
        }
        public ActionResult vSysAdminAccount(string id)
        {
            if (id != null)
            {
                ViewBag.IdSysAdmin = id;
            }
            else
            {
                ViewBag.IdSysAdmin = "null";
            }

            return View();
        }
    }
}