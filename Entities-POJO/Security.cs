using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Security : BaseEntity
    {
       
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string UserActiveStatus { get; set; }
        public string Result { get; set; }


        

        public Security()
        {
        }

        public Security(string userLogin, string userPassword, string userType)
        {
            UserLogin = userLogin;
            UserPassword = userPassword;
            UserType = userType;
        }
    }
}
