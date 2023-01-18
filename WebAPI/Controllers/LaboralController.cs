using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/laboral")]
    public class LaboralController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new LaboralManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        [HttpGet]
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
        [HttpGet]
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
        [HttpPost]
        public IHttpActionResult Post(Laboral laboral)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new LaboralManager();

                
                //Check if datetime variable is having the MinValue or not
                if (laboral.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    laboral.EndDate = (DateTime)SqlDateTime.Null; ;
                }

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
        [HttpPut]
        public IHttpActionResult Put(Laboral laboral)
        {
            try
            {
                var mng = new LaboralManager();
                //Check if datetime variable is having the MinValue or not
                if (laboral.EndDate == DateTime.MinValue)
                {
                    //DateTime is null
                    laboral.EndDate = (DateTime)SqlDateTime.Null; ;
                }

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

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(Laboral laboral)
        {
            try
            {
                var mng = new LaboralManager();
                mng.Delete(laboral);

                apiResp = new ApiResponse
                {
                    Message = "Experiencia Laboral Eliminada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar la experiencia laboral";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}