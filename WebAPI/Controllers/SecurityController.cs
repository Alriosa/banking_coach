using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using WebAPI.Models;

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
                   return Ok(apiResp);
                
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
