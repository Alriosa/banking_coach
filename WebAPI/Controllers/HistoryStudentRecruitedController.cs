using System;
using CoreAPI;
using System.Net;
using System.Web.Http;
using Models;
using Exceptions;
using System.Net.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix ("api/history/recruited/student")]
    public class HistoryStudentRecruitedController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new HistoryStudentRecruitedManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(HistoryStudentRecruited historyStudent)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new HistoryStudentRecruitedManager();
                apiResp.Data = mng.Create(historyStudent);
                apiResp.Message = "Historial Creado";
                return Ok(apiResp);
            }
            catch (Exception bex)
            {
                Console.WriteLine(bex);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest,bex));
            }
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(HistoryStudentRecruited historyStudent)
        {
            try
            {
                var mng = new HistoryStudentRecruitedManager();
                mng.Update(historyStudent);

                apiResp = new ApiResponse
                {
                    Message = "Historial Modificado"
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
    }
}
