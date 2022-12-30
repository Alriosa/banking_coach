using Newtonsoft.Json;
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
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                    return View();
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public ActionResult vSysAdminList()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                    return View();
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public ActionResult vSysAdminUpdate(string id)
        {


            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdSysAdmin = id;
                }
                else
                {
                    ViewBag.IdSysAdmin = "null";
                }
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                    return View();
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home"); ;
        }
        public ActionResult vSysAdminAccount(string id)
        {


            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdSysAdmin = id;
                }
                else
                {
                    ViewBag.IdSysAdmin = "null";
                }
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
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}