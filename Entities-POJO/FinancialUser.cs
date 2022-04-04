using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class FinancialUser : BaseEntity
    {
        public int FinancialUserID { get; set; }
        public string FinancialLogin { get; set; }
        public string FinancialPassword { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }

        public FinancialUser()
        {
          
        }
        public FinancialUser(int financialUserId, string financialUser, string financialPassword, string userType, string userActiveStatus)
        {
            FinancialUserID = financialUserId;
            FinancialLogin = financialUser;
            FinancialPassword = financialPassword;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
        }
    }
}
