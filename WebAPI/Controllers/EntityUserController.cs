using System;
using CoreAPI;
using System.Net;
using System.Web.Http;
using Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/entity")]
    public class EntityUserController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new EntityUserManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new EntityUserManager();
                var entity = new EntityUser
                {
                    EntityUserID = id
                };

                entity = mng.RetrieveById(entity);
                apiResp = new ApiResponse
                {
                    Data = entity
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
        public IHttpActionResult Post(EntityUser entity)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new EntityUserManager();

                var c = mng.ValidateExist(entity);

                if (c == false)
                {
                    entity.UserActiveStatus = "1";
                    mng.Create(entity);
                    apiResp.Message = "Entidad financiera creada";
                }
                else
                {
                    apiResp.Message = "Nombre de entidad ya existe";
                    apiResp.Data = "error";

                }

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
                var mng = new EntityUserManager();
                var entity = new EntityUser
                {
                    Id = id
                };

                entity = mng.RetrieveByUserLogin(entity);
                apiResp = new ApiResponse
                {
                    Data = entity
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(EntityUser entity)
        {
            try
            {
                var mng = new EntityUserManager();
                mng.Update(entity);

                apiResp = new ApiResponse
                {
                    Message = "Entidad Financiera actualizada."
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
        public IHttpActionResult ChangePassword(EntityUser entity)
        {
            try
            {
                var mng = new EntityUserManager();
                mng.Update(entity);

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
        [HttpDelete]
        public IHttpActionResult Delete(EntityUser entity)
        {
            try
            {
                var mng = new EntityUserManager();
                mng.Delete(entity);

                apiResp = new ApiResponse
                {
                    Message = "Entidad Financiera eliminada."
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
