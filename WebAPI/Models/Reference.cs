using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Reference: BaseEntity
    {
        public int ReferenceID { get; set; }
        public string ReferrerName { get; set; }
        public string Workstation { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }
    }
}
