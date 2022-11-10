using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class EntityUserController : Controller
    {
        // GET: Entity
        public ActionResult vEntityRegistration()
        {
            return View();
        }
        public ActionResult vEntityList()
        {
            return View();
        }
        public ActionResult vEntityUpdate(string id)
        {
            if (id != null)
            {
                ViewBag.IdEntity = id;
            }
            else
            {
                ViewBag.IdEntity = "null";
            }

            return View();
        }


        public ActionResult vEntityAccount(string id)
        {
            if (id != null)
            {
                ViewBag.IdEntity = id;
            }
            else
            {
                ViewBag.IdEntity = "null";
            }

            return View();
        }
    }
}