using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ExtraCourse : BaseEntity
    {
        public int AcademicID { get; set; }
        public string Institution { get; set; }
        public string CourseName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public string Certificate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public ExtraCourse()
        {
        }

        public ExtraCourse(int academicID, string institution, string courseName, DateTime start_Date, DateTime end_Date, string status, string certificate, DateTime entryDate, int studentID)
        {
            AcademicID = academicID;
            Institution = institution;
            CourseName = courseName;
            Start_Date = start_Date;
            End_Date = end_Date;
            Status = status;
            Certificate = certificate;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
