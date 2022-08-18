using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ExtraCourse : BaseEntity
    {
        public int CourseID { get; set; }
        public string Institution { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Certificate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public ExtraCourse()
        {
        }

        public ExtraCourse(int courseID, string institution, string courseName, DateTime startDate, DateTime endDate, string status, string certificate, DateTime entryDate, int studentID)
        {
            CourseID = courseID;
            Institution = institution;
            CourseName = courseName;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Certificate = certificate;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
