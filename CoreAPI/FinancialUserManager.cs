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
            try
            {

                // if (temp.FinancialLogin.Equals("0"))
                financialUserCrudFactory.Create(financialUser);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
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

        public FinancialUser RetrieveByUserLogin(FinancialUser financial)
        {
            FinancialUser c = null;
            try
            {
                c = financialUserCrudFactory.RetrieveByUserLogin<FinancialUser>(financial);
                /* if (c == null)
                 {
                     throw new BussinessException(4);
                 }*/
            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }
        public void Update(FinancialUser financialUser)
        {
            financialUserCrudFactory.Update(financialUser);
        }

        public void UpdatePassword(FinancialUser financialUser)
        {
            FinancialUser s = null;


            try
            {
                financialUserCrudFactory.UpdatePassword(financialUser);


            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
        }

        public void Delete(FinancialUser financialUser)
        {
            financialUserCrudFactory.Delete(financialUser);
        }

        public bool ValidateExist(FinancialUser financial)
        {
            bool repeated = false;
            try
            {
                repeated = financialUserCrudFactory.ValidateUserExistence(financial);
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
            }
            return repeated;
        }
    }
}
