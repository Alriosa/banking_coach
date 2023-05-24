using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class HistoryStudentRecruited : BaseEntity
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public string EntityId { get; set; }
        public string EntityUser { get; set; }
        public string RecruiterUser { get; set; }
        public string RecruiterName { get; set; }
        public string StatusEconomic { get; set; }
        public string StatusPsychometric { get; set; }
        public string StatusInterview { get; set; }
        public string StatusHired { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public string FinishDate { get; set; }
        public string Observations { get; set; }
    }
}