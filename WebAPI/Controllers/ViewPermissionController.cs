using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/permits")]
    public class ViewPermissionController : ApiController
    {

        [Route("")]
        public IHttpActionResult Get()
        {
            ApiResponse apiResp = new ApiResponse();
            var mng = new SysAdminManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new ViewPermissionManager();
                var view = new ViewPermission
                {
                    IdUserType = id
                };
                ApiResponse apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveByUser(view);
                return Ok(apiResp.Data);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al obtener las vistas";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
