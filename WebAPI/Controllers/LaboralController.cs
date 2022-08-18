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
    [RoutePrefix("api/laboral")]
    public class LaboralController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new LaboralManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new LaboralManager();
                var laboral = new Laboral
                {
                    LaboralID = id
                };

                laboral = mng.RetrieveById(laboral);
                apiResp = new ApiResponse
                {
                    Data = laboral
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        public IHttpActionResult GetLaboraltudent(int id)
        {
            try
            {
                var mng = new LaboralManager();
                var laboral = new Laboral
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveByStudent(laboral)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Post(Laboral laboral)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new LaboralManager();


                mng.Create(laboral);
                apiResp.Message = "Experiencia Laboral creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar la experiencia laboral";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(Laboral laboral)
        {
            try
            {
                var mng = new LaboralManager();
                mng.Update(laboral);

                apiResp = new ApiResponse
                {
                    Message = "Experiencia Laboral Modificada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar la experiencia laboral";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}