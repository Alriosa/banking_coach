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

        [HttpGet]
        [Route("allInRecruitment")]
        public IHttpActionResult GetAllInRecruitment()
        {
            apiResp = new ApiResponse();
            var mng = new StudentManager();
            apiResp.Data = mng.RetrieveAllInRecruitment();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("allInRecruitment/{id}")]
        public IHttpActionResult GetAllInRecruitmentByEntity(int id)
        {
            apiResp = new ApiResponse();
            var mng = new StudentManager();
            var student = new Student
            {
                EntityId = id
            };
            apiResp.Data = mng.RetrieveAllInRecruitmentByEntity(student);

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
                student.StudentPassword = null;
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
                        apiResp.Message = "Identificación ya existe";
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
                bex.AppMessage.Message = "Hubo un error al registrar al usuario";
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
                bex.AppMessage.Message = "Hubo un error al modificar al usuario";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("changePassword")]
        public IHttpActionResult ChangePassword(Student student)
        {
            try
            {
                var mng = new StudentManager();
                 mng.UpdatePassword(student);

                apiResp = new ApiResponse
                {
                    Message = "Contraseña Modificada"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar la contraseña del usuario";
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

        [HttpPut]
        [Route("recruitStudent")]
        public IHttpActionResult RecruitStudent(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.RecruitStudent(student);

                apiResp = new ApiResponse
                {
                    Message = "Estado de proceso de reclutamiento de estudiante modificado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al reclutar al estudiante";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [HttpPut]
        [Route("finishRecruitStudent")]
        public IHttpActionResult finishRecruitStudent(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.FinishRecruitStudent(student);

                apiResp = new ApiResponse
                {
                    Message = "Estudiante se eliminó de la lista de reclutados de la entidad bancaria"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar al estudiante de la lista de reclutamiento";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("updateTestEconomic")]
        public IHttpActionResult StudentProcessTestEconomic(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.StudentProcessTestEconomic(student);

                apiResp = new ApiResponse
                {
                    Message = "Proceso de Pruebas Económicas actualizado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar el estado de las pruebas económicas";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("updateTestPsychometric")]
        public IHttpActionResult StudentProcessTestPsychometric(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.StudentProcessTestPsychometric(student);

                apiResp = new ApiResponse
                {
                    Message = "Proceso de Pruebas Psicométricas actualizado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar el estado de las pruebas psicométricas";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("updateProcessInterview")]
        public IHttpActionResult StudentProcessInterview(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.StudentProcessInterview(student);

                apiResp = new ApiResponse
                {
                    Message = "Proceso de Entrevista actualizado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar el estado de la entrevista";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("updateStatusHiring")]
        public IHttpActionResult StudentStatusHiring(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.StudentProcessHiring(student);

                apiResp = new ApiResponse
                {
                    Message = "Estado de contratración actualizado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al cambiar el estado de contratación";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
