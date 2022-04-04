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
        public int FinantialAssociation { get; set; }
        public string NameFinantialAssociation { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }

        public Recruiter()
        {
            
        }
        public Recruiter(int recruiterUserId, string recruiterLogin, string recruiterPassword, int finantialAssociation,  string userType, string recruiterStatus)
        {
            RecruiterUserID = recruiterUserId;
            RecruiterLogin = recruiterLogin;
            RecruiterPassword = recruiterPassword;
            FinantialAssociation = finantialAssociation;
            UserType = userType;
            UserActiveStatus = recruiterStatus;
        }
    }
}
