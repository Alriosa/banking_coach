using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Recruiter : BaseEntity
    {
        public int Recruiter_User_ID { get; set; }
        public string Recruiter_Login { get; set; }
        public string Recruiter_Password { get; set; }
    }
}
