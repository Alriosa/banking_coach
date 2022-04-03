using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/sysadmin")]
    public class SysAdminController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SysAdminManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
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
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.Create(sysAdmin);

                apiResp = new ApiResponse();
                apiResp.Message = "El Admin fue creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.Update(sysAdmin);

                apiResp = new ApiResponse
                {
                    Message = "SysAdmin Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(SysAdmin sysAdmin)
        {
            try
            {
                var mng = new SysAdminManager();
                mng.Delete(sysAdmin);

                apiResp = new ApiResponse
                {
                    Message = "SysAdmin deleted."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("validateuser")]
        public IHttpActionResult PostValidateUser(SysAdmin sysAdmin)
        {
            try
            {

                var mng = new SysAdminManager();
                //var usuario = new Usuario
                //{
                //    Correo = correo,
                //    Identificacion = id
                //};

                sysAdmin = mng.ValidateExist(sysAdmin);
                apiResp = new ApiResponse
                {
                    Data = sysAdmin.AdminLogin //Return 0 if doesn't exists or return 1 if that user exists
                };
                if (sysAdmin.AdminLogin.Equals("0"))
                {
                    apiResp.Message = "El usuario no existe";
                }
                else
                {
                    apiResp.Message = "El usuario si existe";
                }

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
