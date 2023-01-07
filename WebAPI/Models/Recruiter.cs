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
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public int EntityAssociation { get; set; }
        public string EntityAssociationName { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }
        public string User_Login { get; set; }
        public int QuantityDownload { get; set; }

        public Recruiter()
        {
            
        }

        public Recruiter(int recruiterUserID, string recruiterLogin, string recruiterPassword, string name, string email, string idType, string identificationNumber, int entityAssociation, string entityAssociationName, string userType, string userActiveStatus, string user_Login)
        {
            RecruiterUserID = recruiterUserID;
            RecruiterLogin = recruiterLogin;
            RecruiterPassword = recruiterPassword;
            Name = name;
            Email = email;
            IdType = idType;
            IdentificationNumber = identificationNumber;
            EntityAssociation = entityAssociation;
            EntityAssociationName = entityAssociationName;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
            User_Login = user_Login;
        }
    }
}
