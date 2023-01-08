using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/reference")]
    public class ReferenceController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ReferenceManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new ReferenceManager();
                var reference = new Reference
                {
                    
                    ReferenceID = id
                };

                reference = mng.RetrieveById(reference);
                apiResp = new ApiResponse
                {
                    Data = reference
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        public IHttpActionResult GetReferenceStudent(int id)
        {
            try
            {
                var mng = new ReferenceManager();
                var reference = new Reference
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveAllByStudent(reference)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Post(Reference reference)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new ReferenceManager();


                mng.Create(reference);
                apiResp.Message = "Referencia creada";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar la referencia del estudiante";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(Reference reference)
        {
            try
            {
                var mng = new ReferenceManager();
                mng.Update(reference);

                apiResp = new ApiResponse
                {
                    Message = "Referencia Modificada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar la referencia del estudiante";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(Reference reference)
        {
            try
            {
                var mng = new ReferenceManager();
                mng.Delete(reference);

                apiResp = new ApiResponse
                {
                    Message = "Referencia Eliminada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar la referencia del estudiante";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}