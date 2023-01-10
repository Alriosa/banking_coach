using CoreAPI;
using Exceptions;
using System;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/mail")]
    public class MailController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();



        /* [HttpPost]
         [Route("")]
         public IHttpActionResult Post(Mail mail)
         {
             var  mailManager = new MailManager();
             try
             {
                 string mensajefinal = "<h1>Proyecto Techclub Tajamar(MVC NetCore Correos)<h1/><h4>" + mail.texto + " <h4/>";


                 mailManager.SendMail(mail.receptor, mail.asunto, mensajefinal);


                 return Ok("Mensaje enviado a '" + mail.receptor + "'");
             }
             catch (Exception bex)
             {
                 return InternalServerError(new Exception("Error al enviar el correo"));
             }
         }
        */

        [HttpPost]
        [Route("studentRegistered")]
        public IHttpActionResult studentRegistered(Mail mail)
        {
            var mailManager = new MailManager();
            try
            {
                string message = "<h1>Banking Coach: <h1/><h4>" + mail.Text + " <h4/>";


                var mng = new StudentManager();


                Student student = new Student();
                student.Email = mail.Email;
                student = mng.RetrieveByEmail(student);


                var text = @"<p>Estudiante registrado: " + student.FirstName + " " + student.FirstLastName + " "+ student.SecondLastName + " </p><p>Credenciales:</p><p>Usuario: " + student.IdentificationNumber + "</p><p>Contraseña: " + student.StudentPassword + "</p>";
                message = message + "\n" + text;
                mailManager.SendMail(mail.Email, mail.Subject, message);

                return Ok("Mensaje enviado a '" + mail.Email + "'");
            }
            catch (Exception bex)
            {
                return InternalServerError(new Exception("Error al enviar el correo", bex));
            }
        }


        [HttpPost]
        [Route("recoverPasswordAdmin")]
        public IHttpActionResult recoverPasswordAdmin(Mail mail)
        {
            var mailManager = new MailManager();
            try
            {
                string message = "<h1>Banking Coach: <h1/><h4>" + mail.Text + " <h4/>";

                var mng = new SysAdminManager();

                SysAdmin admin = new SysAdmin();
                admin.Email = mail.Email;
                admin.AdminPassword = CreateRandomPassword();
                mng.UpdatePassword(admin);
                var text = @"<p>Nueva contraseña: " + admin.AdminPassword + " </p>";
                message = message + "\n" + text;
                mailManager.SendMail(mail.Email, mail.Subject, message);

                return Ok("Mensaje enviado a '" + mail.Email + "'");
            }
            catch (Exception bex)
            {
                return InternalServerError(new Exception("Error al enviar el correo", bex));
            }
        }

        [HttpPost]
        [Route("recoverPasswordRecruiter")]
        public IHttpActionResult recoverPassword(Mail mail)
        {
            var mailManager = new MailManager();
            try
            {
                string message = "<h1>Banking Coach: <h1/><h4>" + mail.Text + " <h4/>";

                var mng = new RecruiterManager();

                Recruiter recruiter = new Recruiter();
                recruiter.Email = mail.Email;
                recruiter.RecruiterPassword = CreateRandomPassword();
                mng.UpdatePassword(recruiter);
                var text = @"<p>Nueva contraseña: " + recruiter.RecruiterPassword + " </p>";
                message = message + "\n" + text;
                mailManager.SendMail(mail.Email, mail.Subject, message);

                return Ok("Mensaje enviado a '" + mail.Email + "'");
            }
            catch (Exception bex)
            {
                return InternalServerError(new Exception("Error al enviar el correo", bex));
            }
        }

        [HttpPost]
        [Route("recoverPasswordStudent")]
        public IHttpActionResult recoverPasswordStudent(Mail mail)
        {
            var mailManager = new MailManager();
            try
            {
                string message = "<h1>Banking Coach: <h1/><h4>" + mail.Text + " <h4/>";

                var mng = new StudentManager();

                Student student = new Student();
                student.Email = mail.Email;
                student.StudentPassword = CreateRandomPassword();
                mng.UpdatePassword(student);
                var text = @"<p>Nueva contraseña: " + student.StudentPassword + " </p>";
                message = message + "\n" + text;
                mailManager.SendMail(mail.Email, mail.Subject, message);

                return Ok("Mensaje enviado a '" + mail.Email + "'");
            }
            catch (Exception bex)
            {
                return InternalServerError(new Exception("Error al enviar el correo", bex));
            }
        }

        private static string CreateRandomPassword(int length = 8)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}