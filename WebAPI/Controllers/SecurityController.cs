using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(Security security)
        {
            try
            {
                var mng = new SecurityLoginManager();
                Security login = mng.RetrieveById(security);
                apiResp = new ApiResponse();
                if (login != null)
                {
                    switch (login.Result)
                    {
                        case "0":
                            apiResp.Message = "Usuario no existe";
                            apiResp.Data = "error";

                            break;
                        case "1":
                            apiResp.Message = "Contraseña incorrecta!";
                            apiResp.Data = "error";
                            break;
                        case "2":
                            apiResp.Message = "Usuario inactivo";
                            apiResp.Data = "error";
                            break;
                        default:
                            apiResp.Message = "Bienvenido!";
                            apiResp.Data = login;
                            break;
                    }
                } else
                {
                    apiResp.Message = "Usuario no existe";
                    apiResp.Data = "error";
                }
                
                   return Ok(apiResp);
                
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }


        [HttpPost]
        [Route("retrieveByEmail")]
        public IHttpActionResult RetrieveByEmail(Security security)
        {
            try
            {
                var mng = new SecurityLoginManager();
                Security user = mng.RetrieveByEmail(security);
                apiResp = new ApiResponse();
                switch (user.Result)
                {
                    case "0":
                        apiResp.Message = "Usuario no existe";
                        apiResp.Data = "error";

                        break;
                    case "1":
                        apiResp.Message = "Usuario inactivo";
                        apiResp.Data = "error";
                        break;
                    default:
                        apiResp.Message = "Mensaje enviado a su correo electrónico!";
                        apiResp.Data = user;
                        break;
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
