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

        public Recruiter(int recruiterUserId, string recruiterLogin, string recruiterPassword)
        {
            Recruiter_User_ID = recruiterUserId;
            Recruiter_Login = recruiterLogin;
            Recruiter_Password = recruiterPassword;
        }
    }
}
