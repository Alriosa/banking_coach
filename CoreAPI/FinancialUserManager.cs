using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class FinancialUserManager : BaseManager
    {
        private FinancialUserCrudFactory financialUserCrudFactory;

        public FinancialUserManager()
        {
            financialUserCrudFactory = new FinancialUserCrudFactory();
        }

        public void Create(FinancialUser financialUser)
        {
            var c = financialUserCrudFactory.Retrieve<FinancialUser>(financialUser);
            //try
            //{
                

            //    //    if (c != null)
            //    //    {
            //    //        //FinancialUser already exist
            //    //        throw new BussinessException(3);
            //    //    }

            //    //    if (financialUser.Age >= 18)
            //    //        financialUserCrudFactory.Create(financialUser);
            //    //    else
            //    //        throw new BussinessException(2);
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    ExceptionManager.GetInstance().Process(ex);
            //    //}
            //}
        }

        public List<FinancialUser> RetrieveAll()
        {
            return financialUserCrudFactory.RetrieveAll<FinancialUser>();
        }

        public FinancialUser RetrieveById(FinancialUser financialUser)
        {
            FinancialUser c = null;
            try
            {
                c = financialUserCrudFactory.Retrieve<FinancialUser>(financialUser);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(FinancialUser financialUser)
        {
            financialUserCrudFactory.Update(financialUser);
        }

        public void Delete(FinancialUser financialUser)
        {
            financialUserCrudFactory.Delete(financialUser);
        }
    }
}
