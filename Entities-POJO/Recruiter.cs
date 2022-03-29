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
        public int UserType { get; set; }
        public char UserActiveStatus { get; set; }

        public Recruiter()
        {
            
        }
        public Recruiter(int recruiterUserId, string recruiterLogin, string recruiterPassword, int finantialAssociation, int userType, char userActiveStatus)
        {
            RecruiterUserID = recruiterUserId;
            RecruiterLogin = recruiterLogin;
            RecruiterPassword = recruiterPassword;
            FinantialAssociation = finantialAssociation;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
        }
    }
}
