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
                apiResp.Message = "Estudiante Reclutado satisfactoriamente";
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
                    Message = "Estado de Reclutamiento actualizado"
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
        [Route("finish")]
        public IHttpActionResult FinishHistory(HistoryStudentRecruited historyStudent)
        {
            try
            {
                var mng = new HistoryStudentRecruitedManager();
                mng.Finish(historyStudent);

                apiResp = new ApiResponse
                {
                    Message = "Estudiante se eliminó de la lista de reclutados de la entidad bancaria"
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
