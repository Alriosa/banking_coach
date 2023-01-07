using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SysAdmin : BaseEntity
    {
        public int SysAdminUserID { get; set; }
        public string AdminLogin { get; set; }
        public string AdminPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }
        public string User_Login { get; set; }

        public SysAdmin()
        {
            
        }

        public SysAdmin(int sysAdminUserID, string adminLogin, string adminPassword, string name, string email, string idType, string identificationNumber, string userType, string userActiveStatus, string user_Login)
        {
            SysAdminUserID = sysAdminUserID;
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
            Name = name;
            Email = email;
            IdType = idType;
            IdentificationNumber = identificationNumber;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
            User_Login = user_Login;
        }
    }
}
