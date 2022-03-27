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
        public string Financial_User { get; set; }
        public string Financial_Password { get; set; }

        public FinancialUser()
        {
            
        }
        public FinancialUser(int financialUserId, string financialUser, string financialPassword)
        {
            Financial_User_ID = financialUserId;
            Financial_User = financialUser;
            Financial_Password = financialPassword;
        }
    }
}
