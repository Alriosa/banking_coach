using System;
using CoreAPI;
using System.Net;
using System.Web.Http;
using Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/recruiter")]
    public class RecruiterController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new RecruiterManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        [HttpGet]
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

        [HttpGet]
        [Route("getEntity/{id}")]
        public IHttpActionResult getEntity(string id)
        {
            try
            {
                var mng = new RecruiterManager();
                var recruiter = new Recruiter
                {
                    RecruiterLogin = id
                };

                recruiter = mng.RetrieveEntityId(recruiter);
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
        [HttpPost]
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
                    apiResp.Message = "Identificación ya existe";
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
        [HttpPut]
        public IHttpActionResult Put(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Update(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Reclutador actualizado."
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


        [HttpPut]
        [Route("addQuantity")]
        public IHttpActionResult AddQuantity(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();

                var c = mng.RetrieveById(recruiter);

                if(c != null)
                {
                    if(c.QuantityDownload <= 20)
                    {
                        mng.AddQuantityDownload(recruiter);

                        apiResp = new ApiResponse
                        {
                            Data = "success",
                            Message = "Descarga realizada"
                        };
                    } else
                    {
                        apiResp = new ApiResponse
                        {
                            Message = "Ha sobrepasado el límite de descargas permitidas al mes",
                            Data = "error"

                        };
                    }
                } 
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al descargar el currículum";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("changeStatus")]
        public IHttpActionResult ChangeStatus(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.ChangeStatus(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Reclutador " + ((recruiter.UserActiveStatus.Equals('1')) ? "Activado" : "Inactivado")
                };

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Delete(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Reclutador eliminado."
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
