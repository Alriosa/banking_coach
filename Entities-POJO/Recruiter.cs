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
        public string FinantialAssociationName { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }
        public string User_Login { get; set; }

        public Recruiter()
        {
            
        }
        public Recruiter(int recruiterUserId, string recruiterLogin, string recruiterPassword, int finantialAssociation, string finantialAssociationName,  string userType, string recruiterStatus)
        {
            RecruiterUserID = recruiterUserId;
            RecruiterLogin = recruiterLogin;
            RecruiterPassword = recruiterPassword;
            FinantialAssociation = finantialAssociation;
            FinantialAssociationName = finantialAssociationName;
            UserType = userType;
            UserActiveStatus = recruiterStatus;
        }
    }
}
