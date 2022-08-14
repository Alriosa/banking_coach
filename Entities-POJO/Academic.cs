using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Academic : BaseEntity
    {
        public int AcademicID { get; set; }
        public string Institution { get; set; }
        public string DegreeType { get; set; }
        public string University_Preparation { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Career { get; set; }
        public string Status { get; set; }
        public string Certificate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public Academic()
        {
        }

        public Academic(int academicID, string institution, string degreeType, string university_Preparation, DateTime start_Date, DateTime end_Date, string career, string status, string certificate, DateTime entryDate, int studentID)
        {
            AcademicID = academicID;
            Institution = institution;
            DegreeType = degreeType;
            University_Preparation = university_Preparation;
            Start_Date = start_Date;
            End_Date = end_Date;
            Career = career;
            Status = status;
            Certificate = certificate;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
