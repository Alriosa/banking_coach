using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SysAdmin : BaseEntity
    {
        public int Sys_Admin_User { get; set; }
        public string Admin_Login { get; set; }
        public string Admin_Password { get; set; }
        public int UserType { get; set; }
        public bool UserActiveStatus { get; set; }

        public SysAdmin(int sysAdminUser, string adminLogin, string adminPassword, bool userActiveStatus, int userType)
        {
            Sys_Admin_User = sysAdminUser;
            Admin_Login = adminLogin;
            Admin_Password = adminPassword;
            UserActiveStatus = userActiveStatus;
            UserType = userType;
        }


    }
}
