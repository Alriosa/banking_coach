using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult vStudentRegistration()
        {
            return View();
        }
        public ActionResult vStudentRegistrationAllData()
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

        public ActionResult vStudentList()
        {
            if (Request.Cookies["user"] != null)
            {
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1)
                {
                    return View();
                }
                else {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult vStudentUpdate(string id)
        {
            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdStudent = id;
                }
                else
                {
                    ViewBag.IdStudent = "null";
                }

                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if (typeNumber == 1 || typeNumber == 2)
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
        public ActionResult vStudentAccount(string id)
        {

            if (Request.Cookies["user"] != null)
            {
                if (id != null)
                {
                    ViewBag.IdStudent = id;
                }
                else
                {
                    ViewBag.IdStudent = "null";
                }
                var type = JsonConvert.DeserializeObject(Request.Cookies["type"].Value);
                int typeNumber = Convert.ToInt32(type);
                if(typeNumber == 1)
                {
                    if(ViewBag.IdStudent == "null")
                    {
                        return RedirectToAction(actionName: "vStudentList", controllerName: "Student");
                    } 
                    else
                    {
                        return View();
                    }
                }
                else if (typeNumber == 2)
                {
                    if (ViewBag.IdStudent == "null")
                    {
                        var idToken = JsonConvert.DeserializeObject(Request.Cookies["token"].Value);

                        Console.WriteLine(idToken);

                        if (idToken.ToString() == "")
                        {
                            return RedirectToAction(actionName: "Index", controllerName: "Home");
                        }
                        else
                        {
                            ViewBag.IdStudent = idToken;
                            return View();
                        }
                    } else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }


       /* [HttpPost]
        public ActionResult uploadFileAcademic()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase fileUpload = files[0];
                    string fileName = fileUpload.FileName;

                    string path = Server.MapPath("~/Content/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    fileUpload.SaveAs(path + Path.GetFileName(fileUpload.FileName));


                }
                catch (Exception e)
                {
                    return Json(new { Value = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Value = true, Message = "Subido con exito" }, JsonRequestBehavior.AllowGet);
        }*/


    }
}