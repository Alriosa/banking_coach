using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

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
        public IHttpActionResult Post(Academic academic)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new AcademicManager();

                Random rnd = new Random();

                int rndx = rnd.Next(0, 1000);

                string extension = Path.GetExtension(academic.Certificate_Name);
                string fname = Path.GetFileName(academic.Certificate_Name);
                academic.Certificate_Name = fname;

                var folder = HttpContext.Current.Server.MapPath("~/Certificados/" + rndx);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Certificados/" + rndx), rndx + "_" + "_" + "_" + extension);
                    academic.Certificate_File = filePath;
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

                if (academic.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    academic.EndDate = (DateTime)SqlDateTime.Null; ;
                }

                mng.Update(academic);

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