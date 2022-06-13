using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix ("api/student")]
    public class StudentController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new StudentManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new StudentManager();
                var student = new Student
                {
                    StudentID = id
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


        [HttpGet]
        [Route("getUser/{id}")]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                var mng = new StudentManager();
                var student = new Student
                {
                    StudentLogin = id
                };

                student = mng.RetrieveByUserLogin(student);
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
        public IHttpActionResult Post(Student student)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new StudentManager();

                var c = mng.ValidateExist(student);

                switch (c)
                {
                    case "1":
                        apiResp.Message = "Nombre de usuario ya existe";
                        apiResp.Data = "error";
                        break;
                      case "2":
                        apiResp.Message = "Email ya existe";
                        apiResp.Data = "error";
                        break;
                    default:
                        student.UserActiveStatus = "1";
                        mng.Create(student);
                        apiResp.Message = "Estudiante creado";
                        break;
                }

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar al usaurio";
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
                    Message = "Estudiante Modificado"
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
                    Message = "Estudiante Eliminado"
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
