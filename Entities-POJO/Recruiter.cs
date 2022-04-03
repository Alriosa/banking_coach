using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Recruiter : BaseEntity
    {
        public int RecruiterUserID { get; set; }
        public string RecruiterLogin { get; set; }
        public string RecruiterPassword { get; set; }
        public char FinantialAssociation { get; set; }
        public char UserType { get; set; }
        public char RecruiterStatus { get; set; }

        public Recruiter()
        {
            
        }
        public Recruiter(int recruiterUserId, string recruiterLogin, string recruiterPassword, char finantialAssociation, char userType, char recruiterStatus)
        {
            RecruiterUserID = recruiterUserId;
            RecruiterLogin = recruiterLogin;
            RecruiterPassword = recruiterPassword;
            FinantialAssociation = finantialAssociation;
            UserType = userType;
            RecruiterStatus = recruiterStatus;
        }
    }
}
