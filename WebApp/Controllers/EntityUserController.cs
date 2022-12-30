using Newtonsoft.Json;
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
        public ActionResult vEntityList()
        {
            if (Request.Cookies["user"] != null)
            {

                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 )
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
        public ActionResult vEntityUpdate(string id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdEntity = id;
                }
                else
                {
                    ViewBag.IdEntity = "null";
                }
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


        public ActionResult vEntityAccount(string id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdEntity = id;
                }
                else
                {
                    ViewBag.IdEntity = "null";
                }

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
    }
}