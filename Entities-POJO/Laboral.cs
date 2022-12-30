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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public Laboral()
        {
        }

        public Laboral(int laboralID, string workPosition, string workstation, string company, string responsabilites, DateTime startDate, DateTime endDate, DateTime entryDate, int studentID)
        {
            LaboralID = laboralID;
            WorkPosition = workPosition;
            Workstation = workstation;
            Company = company;
            Responsabilites = responsabilites;
            StartDate = startDate;
            EndDate = endDate;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
