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
        public ActionResult vFinancialRegistration()
        {
            return View();
        }
        public ActionResult vFinancialList()
        {
            return View();
        }
        public ActionResult vFinancialUpdate()
        {
            return View();
        }
    }
}