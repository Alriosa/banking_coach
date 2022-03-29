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
    public class RecruiterManager : BaseManager
    {
        private RecruiterCrudFactory crudRecruiter;

        public RecruiterManager()
        {
            crudRecruiter = new RecruiterCrudFactory();
        }

        public void Create(Recruiter recruiter)
        {
            var c = crudRecruiter.Retrieve<Recruiter>(recruiter);
            //try
            //{
              

            //    if (c != null)
            //    {
            //        //Recruiter already exist
            //        throw new BussinessException(3);
            //    }

            //    if (recruiter.Age >= 18)
            //        crudRecruiter.Create(recruiter);
            //    else
            //        throw new BussinessException(2);
            //}
            //catch (Exception ex)
            //{
            //    ExceptionManager.GetInstance().Process(ex);
            //}
        }

        public List<Recruiter> RetrieveAll()
        {
            return crudRecruiter.RetrieveAll<Recruiter>();
        }

        public Recruiter RetrieveById(Recruiter recruiter)
        {
            Recruiter c = null;
            try
            {
                c = crudRecruiter.Retrieve<Recruiter>(recruiter);
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

        public void Update(Recruiter recruiter)
        {
            crudRecruiter.Update(recruiter);
        }

        public void Delete(Recruiter recruiter)
        {
            crudRecruiter.Delete(recruiter);
        }
    }
}
