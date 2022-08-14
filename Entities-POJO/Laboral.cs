using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Laboral : BaseEntity
    {
        public int LaboralID { get; set; }
        public string WorkPosition { get; set; }
        public string Workstation { get; set; }
        public string Company { get; set; }
        public string Responsabilites { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public Laboral()
        {
        }

        public Laboral(int laboralID, string workPosition, string workstation, string company, string responsabilites, DateTime start_Date, DateTime end_Date, DateTime entryDate, int studentID)
        {
            LaboralID = laboralID;
            WorkPosition = workPosition;
            Workstation = workstation;
            Company = company;
            Responsabilites = responsabilites;
            Start_Date = start_Date;
            End_Date = end_Date;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
