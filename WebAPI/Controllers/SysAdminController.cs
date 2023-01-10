using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/sysadmin")]
    public class SysAdminController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("")]
        public IHttpActionResult Get()
        {
           

            try
            {
                apiResp = new ApiResponse();
                var mng = new SysAdminManager();
                apiResp.Data = mng.RetrieveAll();
                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new SysAdminManager();
                var sysAdmin = new SysAdmin
                {
                    SysAdminUserID = id
                };

                sysAdmin = mng.RetrieveById(sysAdmin);
                apiResp = new ApiResponse
                {
                    Data = sysAdmin
                };
                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                var mng = new SysAdminManager();
                var sysAdmin = new SysAdmin
                {
                    AdminLogin = id
                };

                sysAdmin = mng.RetrieveByUserLogin(sysAdmin);
                apiResp = new ApiResponse
                {
                    Data = sysAdmin
                };
                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [Route("")]
        public IHttpActionResult Post(SysAdmin sysAdmin)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new SysAdminManager();

                var c = mng.ValidateExist(sysAdmin);

                if (c == false)
                {
                    sysAdmin.UserActiveStatus = "1";
                    mng.Create(sysAdmin);
                    apiResp.Message = "Administrador creado";
                }
                else
                {
                    apiResp.Message = "Identificación ya existe";
                    apiResp.Data = "error";

                }

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [Route("")]
        public IHttpActionResult Put(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.Update(sysAdmin);

                apiResp = new ApiResponse
                {
                    Message = "Administrador Modificado"
                };

                return Ok(apiResp);
            }
          catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [HttpPut]
        [Route("changePassword")]
        public IHttpActionResult ChangePassword(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.UpdatePassword(sysAdmin);

                apiResp = new ApiResponse
                {
                    Message = "Contraseña Modificada"
                };

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                //bex.Message = "Hubo un error al cambiar la contraseña del usuario";
                return InternalServerError(new Exception("Hubo un error al cambiar la contraseña del usuario", bex));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.Delete(sysAdmin);

                apiResp = new ApiResponse
                {
                    Message = "Administrador Eliminado"
                };

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

       
    }
}
