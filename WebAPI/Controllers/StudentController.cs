using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new StudentManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new StudentManager();
                var student = new Student
                {
                    IdentificationNumber = id
                };

                student = mng.RetrieveById(student);
                apiResp = new ApiResponse
                {
                    Data = student
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.Update(student);

                apiResp = new ApiResponse
                {
                    Message = "Student Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.Delete(student);

                apiResp = new ApiResponse
                {
                    Message = "Student deleted."
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
