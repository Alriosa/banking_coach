using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApp.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: Recruiter
        public ActionResult VRecruiterRegistration()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");


        }
        public ActionResult vRecruiterList()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public ActionResult vRecruiterUpdate(string id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdRecruiter = id;
                }
                else
                {
                    ViewBag.IdRecruiter = "null";
                }

                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 || typeNumber == 3)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");

        }

        public ActionResult vRecruiterAccount(string id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdRecruiter = id;
                }
                else
                {
                    ViewBag.IdRecruiter = "null";
                }
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 || typeNumber == 3)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult Recruitment()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 || typeNumber == 3)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult StudentsRecruited()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 || typeNumber == 3)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}