using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Financial
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