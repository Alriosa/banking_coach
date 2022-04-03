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
        public char UserType { get; set; }
        public char UserActiveStatus { get; set; }

        public FinancialUser()
        {
          
        }
        public FinancialUser(int financialUserId, string financialUser, string financialPassword, char userType, char userActiveStatus)
        {
            FinancialUserID = financialUserId;
            FinancialLogin = financialUser;
            FinancialPassword = financialPassword;
            UserType = userType;
            UserActiveStatus = userActiveStatus;
        }
    }
}
