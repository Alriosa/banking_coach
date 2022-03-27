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
    }
}
