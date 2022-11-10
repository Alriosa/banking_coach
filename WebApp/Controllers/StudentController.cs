using Entities_POJO;
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


        public ActionResult vStudentList()
        {
            return View();
        }

        public ActionResult vStudentUpdate(string id)
        {
            if (id != null)
            {
                ViewBag.IdStudent = id;
            }
            else
            {
                ViewBag.IdStudent = "null";
            }

            return View();

        }
        public ActionResult vStudentAccount(string id)
        {
            if (id != null)
            {
                ViewBag.IdStudent = id;
            }
            else
            {
                ViewBag.IdStudent = "null";
            }

            return View();
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