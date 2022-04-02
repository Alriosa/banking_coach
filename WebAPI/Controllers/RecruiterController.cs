using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
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


        [Route("")]
        public IHttpActionResult Put(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Update(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Recruiter Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(Recruiter recruiter)
        {
            try
            {
                var mng = new RecruiterManager();
                mng.Delete(recruiter);

                apiResp = new ApiResponse
                {
                    Message = "Recruiter deleted."
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
