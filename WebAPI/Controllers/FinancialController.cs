using System;
using CoreAPI;
using Entities_POJO;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/financial")]
    public class FinancialController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new FinancialUserManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new FinancialUserManager();
                var financial = new FinancialUser
                {
                    FinancialUserID = id
                };

                financial = mng.RetrieveById(financial);
                apiResp = new ApiResponse
                {
                    Data = financial
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Post(FinancialUser financial)
        {
            try
            {
                apiResp = new ApiResponse();

                var mng = new FinancialUserManager();

                var c = mng.ValidateExist(financial);

                if (c == false)
                {
                    financial.UserActiveStatus = "1";
                    mng.Create(financial);
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

        [HttpGet]
        [Route("getUser/{id}")]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                var mng = new FinancialUserManager();
                var financial = new FinancialUser
                {
                    FinancialLogin = id
                };

                financial = mng.RetrieveByUserLogin(financial);
                apiResp = new ApiResponse
                {
                    Data = financial
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Put(FinancialUser financial)
        {
            try
            {
                var mng = new FinancialUserManager();
                mng.Update(financial);

                apiResp = new ApiResponse
                {
                    Message = "Financial Modified."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("")]
        public IHttpActionResult Delete(FinancialUser financial)
        {
            try
            {
                var mng = new FinancialUserManager();
                mng.Delete(financial);

                apiResp = new ApiResponse
                {
                    Message = "Financial deleted."
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
