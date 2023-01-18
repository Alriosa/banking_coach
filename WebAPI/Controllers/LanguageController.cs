using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/language")]
    public class LanguageController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new LanguageManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new LanguageManager();
                var language = new Language
                {
                    LanguageID = id
                };

                language = mng.RetrieveById(language);
                apiResp = new ApiResponse
                {
                    Data = language
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("student/{id}")]
        [HttpGet]
        public IHttpActionResult GetLanguageStudent(int id)
        {
            try
            {
                var mng = new LanguageManager();
                var language = new Language
                {
                    StudentID = id
                };

                apiResp = new ApiResponse
                {
                    Data = mng.RetrieveAllByStudent(language)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Language language)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new LanguageManager();

                mng.Create(language);
                apiResp.Message = "Idioma creado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al registrar el idioma";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Language language)
        {
            try
            {
                var mng = new LanguageManager();
                mng.Update(language);

                apiResp = new ApiResponse
                {
                    Message = "Idioma Modificado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al modificar al idioma";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(Language language)
        {
            try
            {
                var mng = new LanguageManager();
                mng.Delete(language);

                apiResp = new ApiResponse
                {
                    Message = "Idioma Eliminado"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                bex.AppMessage.Message = "Hubo un error al eliminar al idioma";
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}