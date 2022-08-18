using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/extracourse")]
    public class ExtraCourseController: ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ExtraCourseManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new ExtraCourseManager();
                var extraCourse = new ExtraCourse
                {
                    CourseID = id
                };

                extraCourse = mng.RetrieveById(extraCourse);
                apiResp = new ApiResponse
                {
                    Data = extraCourse
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        public IHttpActionResult GetExtraCourseStudent(int id)
        {
            try
            {
                var mng = new ExtraCourseManager();
                var extraCourse = new ExtraCourse
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveAllByStudent(extraCourse)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Post(ExtraCourse extraCourse)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new ExtraCourseManager();


                mng.Create(extraCourse);
                apiResp.Message = "Curso Extracurricular creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar el estudio académico";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        public IHttpActionResult Put(ExtraCourse extraCourse)
        {
            try
            {
                var mng = new ExtraCourseManager();
                mng.Update(extraCourse);

                apiResp = new ApiResponse
                {
                    Message = "Curso Extracurricular Modificado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar al curso extracurricular";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
