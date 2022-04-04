using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    public class RecruiterController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new RecruiterManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

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

        public IHttpActionResult Post(Recruiter recruiter)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new RecruiterManager();

                var c = mng.ValidateExist(recruiter);

                if (c == false)
                {
                    recruiter.UserActiveStatus = "1";
                    mng.Create(recruiter);
                    apiResp.Message = "Entidad financiera creada";
                }
                else
                {
                    apiResp.Message = "Nombre de usuario ya existe";
                    apiResp.Data = "error";

                }

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

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
