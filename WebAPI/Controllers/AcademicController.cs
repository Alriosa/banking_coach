using CoreAPI;
using Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
//using System.Text.Json;
using System.Web;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/academic")]
    public class AcademicController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new AcademicManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new AcademicManager();
                var academic = new Academic
                {
                    AcademicID = id
                };

                academic = mng.RetrieveById(academic);


                apiResp = new ApiResponse
                {
                    Data = academic
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        public IHttpActionResult GetAcademicStudent(int id)
        {
            try
            {
                var mng = new AcademicManager();
                var academic = new Academic
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveByStudent(academic)
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
                var mng = new AcademicManager();

                Random rnd = new Random();
                int rndx = rnd.Next(0, 1000);

                //Fetch the File Name.
                string fileName = HttpContext.Current.Request.Form["fileName"];
                string academicPost = HttpContext.Current.Request.Form["academic"];
                var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ" };

                var a = JObject.Parse(academicPost);
                if (string.IsNullOrEmpty(a["EndDate"].ToString()))
                {
                    a["EndDate"] = DateTime.MinValue;
                }

                Academic academic = JsonConvert.DeserializeObject<Academic>(a.ToString());

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
                        academic.Certificate_File = Path.Combine(api, rndx + "_" + fileName); ;
                        academic.Certificate_Name = fileName;
                    }

                    //Fetch the File.
                    HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                    //Save the File.
                    postedFile.SaveAs(filePath);
                }

                if (academic.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    academic.EndDate = (DateTime)SqlDateTime.Null; ;
                }
                mng.Create(academic);
                apiResp.Message = "Estudio académico creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar el estudio académico";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(Academic academic)
        {
            try
            {
                var mng = new AcademicManager();
                string academicPost = HttpContext.Current.Request.Form["academic"];
                var a = JObject.Parse(academicPost);

                Academic academicData = JsonConvert.DeserializeObject<Academic>(a.ToString());

                var academicFounded = mng.RetrieveById(academicData);
                if(academicFounded.Certificate_Name == null)
                {
                     Random rnd = new Random();
                int rndx = rnd.Next(0, 1000);

                //Fetch the File Name.
                string fileName = HttpContext.Current.Request.Form["fileName"];
                var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ" };

                if (string.IsNullOrEmpty(a["EndDate"].ToString()))
                {
                    a["EndDate"] = DateTime.MinValue;
                }


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
                            academicData.Certificate_File = Path.Combine(api, rndx + "_" + fileName); ;
                            academicData.Certificate_Name = fileName;
                    }

                    //Fetch the File.
                    HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                    //Save the File.
                    postedFile.SaveAs(filePath);
                }
                }

                if (academicData.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    academicData.EndDate = (DateTime)SqlDateTime.Null; ;
                }

                mng.Update(academicData);

                apiResp = new ApiResponse
                {
                    Message = "Estudio académico Modificado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar al estudio académico";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(Academic academic)
        {
            try
            {
                var mng = new AcademicManager();
                mng.Delete(academic);

                apiResp = new ApiResponse
                {
                    Message = "Estudio académico Eliminado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar al estudio académico";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}