using System;
using CoreAPI;
using System.Net;
using System.Web.Http;
using Models;
using Exceptions;
using System.Net.Http;
using System.Text;

namespace WebAPI.Controllers
{
    [RoutePrefix ("api/student")]
    public class StudentController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [HttpGet]
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


        [HttpGet]
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
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
            }
        }

        [HttpPost]
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
                        student.StudentPassword = GenerateRandomPassword(8);

                        mng.Create(student);

                        var mailManager = new MailManager();
                        try
                        {
                            string message = "<h1>Banking Academy: <h1/><h4> Se te ha creado una nueva cuenta en Banking Academy<h4/>";



                            var text = @"<p>¡Hola!</p><p>Estas son las credenciales que se asignaron a tu usuario:</p><p>Usuario: " + student.IdentificationNumber + "</p><p>Contraseña: " + student.StudentPassword + "</p><span>Se recomienda cambiar la contraseña para mayor seguridad</span>";
                            message = message + "\n" + text;
                            mailManager.SendMail(student.Email, "Nueva Cuenta en Banking Academy", message);
                            apiResp.Message = "Estudiante creado. Mensaje enviado a '" + student.Email + "'";
                        }
                        catch (Exception bex)
                        {
                            return InternalServerError(new Exception("Error al enviar el correo", bex));
                        }

                        break;
                }

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
            }
        }

        [HttpPost]
        [Route("allData")]
        public IHttpActionResult PostAllData(Student student)
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
                        mng.CreateAllData(student);
                        apiResp.Message = "Estudiante creado";
                        break;
                }

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
            }
        }

        [HttpPut]
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
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
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
            catch (Exception bex)
            {
              //  bex.AppMessage.Message = "Hubo un error al cambiar la contraseña del usuario";
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
            }
        }

        [HttpPut]
        [Route("changeStatus")]
        public IHttpActionResult ChangeStatus(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.ChangeStatus(student);

                apiResp = new ApiResponse
                {
                    Message = "Estudiante " + (student.UserActiveStatus.Equals("1") ? "Activado" : "Inactivado")
                };

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                return InternalServerError(bex);
            }
        }

        [HttpDelete]
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
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
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
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
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
        [Route("updateStatusRecruitment")]
        public IHttpActionResult UpdateStatusRecruitment(Student student)
        {
            try
            {
                var mng = new StudentManager();
                mng.UpdateStatusRecruitment(student);

                apiResp = new ApiResponse
                {
                    Message = "Estado de Reclutamiento actualizado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al guardar el proceso de reclutamiento";
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

        [HttpPost]
        [Route("resetPassword")]
        public IHttpActionResult ResetPassword(Student student)
        {
            try
            {
                var mng = new StudentManager();
                student.StudentPassword = GenerateRandomPassword(8);
                mng.ResetPassword(student);


                var mailManager = new MailManager();
                try
                {
                    string message = "<h1>Banking Academy: <h1/><h4> Se ha restablecido su contraseña <h4/>";

                    var text = @"<p>¡Hola!</p><p>Se ha creado una nueva contraseña para su cuenta en Banking Academy:</p><p>Nueva contraseña: " + student.StudentPassword + "</p><span>Ahora podrá usar esta contraseña para poder ingresar a la web.</span>";
                    message = message + "\n" + text;
                    mailManager.SendMail(student.Email, "Restablecimiento Contraseña", message);
                    apiResp.Message = "Contraseña Restablecida. Mensaje enviado a '" + student.Email + "'";
                }
                catch (Exception bex)
                {
                    return InternalServerError(new Exception("Error al enviar el correo", bex));
                }

                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                //  bex.AppMessage.Message = "Hubo un error al cambiar la contraseña del usuario";
                Console.WriteLine(bex);
                return ResponseMessage(
                                            Request.CreateResponse(
                                                HttpStatusCode.BadRequest,
                                                bex));
            }
        }

        private string GenerateRandomPassword(int length)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, validChars.Length);
                password.Append(validChars[randomIndex]);
            }

            return password.ToString();
        }
    }
}
