using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class FinancialUser : BaseEntity
    {
        public int Financial_User_ID { get; set; }
        public string Financial_Login { get; set; }
        public string Financial_Password { get; set; }
        public int UserType { get; set; }
        public bool UserActiveStatus { get; set; }

        public FinancialUser(int userType, bool userActiveStatus)
        {
            UserType = userType;
            UserActiveStatus = userActiveStatus;
        }
        public FinancialUser(int financialUserId, string financialUser, string financialPassword, int userType, bool userActiveStatus)
        {
            Financial_User_ID = financialUserId;
            Financial_Login = financialUser;
            Financial_Password = financialPassword;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
        }
    }
}
