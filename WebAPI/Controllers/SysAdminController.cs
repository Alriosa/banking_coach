using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/sysadmin")]
    public class SysAdminController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SysAdminManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
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
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
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
                    Message = "SysAdmin Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
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
                    Message = "SysAdmin deleted."
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
