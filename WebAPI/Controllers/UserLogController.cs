using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using CoreAPI;
using Entities_POJO;
using Exceptions;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/userlog")]
    public class UserLogController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new UserLogManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new UserLogManager();
                var userLog = new UserLog
                {
                    IdRecordNumber = id
                };

                userLog = mng.RetrieveById(userLog);
                apiResp = new ApiResponse
                {
                    Data = userLog
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(UserLog userLog)
        {
            try
            {
                var mng = new UserLogManager();
                mng.Update(userLog);

                apiResp = new ApiResponse
                {
                    Message = "UserLog Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(UserLog userLog)
        {
            try
            {
                var mng = new UserLogManager();
                mng.Delete(userLog);

                apiResp = new ApiResponse
                {
                    Message = "UserLog deleted."
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
