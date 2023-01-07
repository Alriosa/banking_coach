using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class StudentRecruited
    {
        public int StudentID { get; set; }
        public int EntityId { get; set; }
        public Boolean StateRecruitment { get; set; }
        public Boolean StateEconomic { get; set; }
        public Boolean StatePsichometric { get; set; }
        public Boolean StateInterview { get; set; }
        public Boolean StateHired { get; set; }
    }
}
