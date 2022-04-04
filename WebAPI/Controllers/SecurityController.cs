using Entities_POJO;
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
       /* [HttpPost]
        [Route("login/{user_login}/")]
        public IHttpActionResult Login(Security security)
        {
            try
            {
                var mng = new SecurityManager();
                Usuario usuarioValidado = mng(usuario);
                apiResp = new ApiResponse();
                if (usuarioValidado != null)
                {
                    apiResp.Message = "Bienvenido!";
                    apiResp.Data = usuarioValidado;
                    return Ok(apiResp);
                }
                else
                {
                    apiResp.Message = "No se pudo validar las credenciales ingresadas, favor verifique los datos.";
                    return BadRequest(apiResp.Message);
                }
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }*/
    }
}
