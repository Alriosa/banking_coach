using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
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
    }
}