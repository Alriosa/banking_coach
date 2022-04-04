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
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }
        public string User_Login { get; set; }

        public SysAdmin()
        {
            
        }
        public SysAdmin(int sysAdminUserId, string adminLogin, string adminPassword, string userActiveStatus, string userType)
        {
            SysAdminUserID = sysAdminUserId;
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
            UserActiveStatus = userActiveStatus;
            UserType = userType;
        }


    }
}
