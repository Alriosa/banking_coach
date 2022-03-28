using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;

namespace CoreAPI
{
    public class FinancialUserManager : BaseManager
    {
        private FinancialUserCrudFactory financialUserCrudFactory;

        public FinancialUserManager()
        {
            financialUserCrudFactory = new FinancialUserCrudFactory();
        }


    }
}
