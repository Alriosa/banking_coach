using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult ReportHistoryRecruitment()
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
    }
}