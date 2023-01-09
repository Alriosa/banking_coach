using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Models;
using System.Web;
using System.IO;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/extracourse")]
    public class ExtraCourseController: ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ExtraCourseManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new ExtraCourseManager();
                var extraCourse = new ExtraCourse
                {
                    CourseID = id
                };

                extraCourse = mng.RetrieveById(extraCourse);
                apiResp = new ApiResponse
                {
                    Data = extraCourse
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        public IHttpActionResult GetExtraCourseStudent(int id)
        {
            try
            {
                var mng = new ExtraCourseManager();
                var extraCourse = new ExtraCourse
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveAllByStudent(extraCourse)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Post()
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new ExtraCourseManager();

                Random rnd = new Random();
                int rndx = rnd.Next(0, 1000);

                //Fetch the File Name.
                string fileName = HttpContext.Current.Request.Form["fileName"];
                string coursePost = HttpContext.Current.Request.Form["course"];
                var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ" };

                var c = JObject.Parse(coursePost);
                if (string.IsNullOrEmpty(c["EndDate"].ToString()))
                {
                    c["EndDate"] = DateTime.MinValue;
                }

                ExtraCourse extraCourse = JsonConvert.DeserializeObject<ExtraCourse>(c.ToString());

                if (fileName != null && fileName != "")
                {
                    //Create the Directory.
                    string api = "https://api-bcjyd.azurewebsites.net/Uploads/" + rndx + "/";
                    string path = HttpContext.Current.Server.MapPath("~/Uploads/" + rndx);
                    string filePath = "";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        filePath = Path.Combine(path, rndx + "_" + fileName);
                        extraCourse.Certificate_File = Path.Combine(api, rndx + "_" + fileName); ;
                        extraCourse.Certificate_Name = fileName;
                    }

                    //Fetch the File.
                    HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                    //Save the File.
                    postedFile.SaveAs(filePath);
                }

                if (extraCourse.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    extraCourse.EndDate = (DateTime)SqlDateTime.Null; ;
                }

                mng.Create(extraCourse);
                apiResp.Message = "Curso Extracurricular creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar el estudio académico";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(ExtraCourse extraCourse)
        {
            try
            {
                var mng = new ExtraCourseManager();

                if (extraCourse.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    extraCourse.EndDate = (DateTime)SqlDateTime.Null; ;
                }

                mng.Update(extraCourse);

                apiResp = new ApiResponse
                {
                    Message = "Curso Extracurricular Modificado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar al curso extracurricular";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(ExtraCourse extraCourse)
        {
            try
            {
                var mng = new ExtraCourseManager();
                mng.Delete(extraCourse);

                apiResp = new ApiResponse
                {
                    Message = "Curso Extracurricular Eliminado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar al estudio extracurricular";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
