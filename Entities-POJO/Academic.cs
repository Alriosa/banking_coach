using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities_POJO
{
    public class Academic : BaseEntity
    {
        public int AcademicID { get; set; }
        public string Institution { get; set; }
        public string DegreeType { get; set; }
        public string UniversityPreparation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Career { get; set; }
        public string Status { get; set; }
        public string Certificate_Name { get; set; }
        public string Certificate_File { get; set; }
        public HttpPostedFileBase Certificate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public Academic()
        {
        }

        public Academic(int academicID, string institution, string degreeType, string universityPreparation, DateTime startDate, DateTime endDate, string career, string status, string certificate_Name, string certificate_File, DateTime entryDate, int studentID)
        {
            AcademicID = academicID;
            Institution = institution;
            DegreeType = degreeType;
            UniversityPreparation = universityPreparation;
            StartDate = startDate;
            EndDate = endDate;
            Career = career;
            Status = status;
            Certificate_Name = certificate_Name;
            Certificate_File = certificate_File;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
