using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/recruiter")]
    public class RecruiterController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new RecruiterManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new RecruiterManager();
                var recruiter = new Recruiter
                {
                    RecruiterUserID = id
                };

                recruiter = mng.RetrieveById(recruiter);
                apiResp = new ApiResponse
                {
                    Data = recruiter
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                var mng = new RecruiterManager();
                var recruiter = new Recruiter
                {
                    RecruiterLogin = id
                };

                recruiter = mng.RetrieveByUserLogin(recruiter);
                apiResp = new ApiResponse
                {
                    Data = recruiter
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Post(Recruiter recruiter)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new RecruiterManager();

                var c = mng.ValidateExist(recruiter);

                if (c == false)
                {
                    recruiter.UserActiveStatus = "1";
                    mng.Create(recruiter);
                    apiResp.Message = "Reclutador creado";
                }
                else
                {
                    apiResp.Message = "Nombre de usuario ya existe";
                    apiResp.Data = "error";

                }

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Put(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Update(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Recruiter Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("changePassword")]
        public IHttpActionResult ChangePassword(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.UpdatePassword(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Contraseña Modificada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar la contraseña del usuario";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Delete(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Recruiter deleted."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
