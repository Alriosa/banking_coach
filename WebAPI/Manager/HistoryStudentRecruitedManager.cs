using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Models;
using Exceptions;
using WebAPI.Models;

namespace CoreAPI
{
    public class HistoryStudentRecruitedManager : BaseManager
    {
        private HistoryStudentRecruitedCrudFactory crudFactory;

        public HistoryStudentRecruitedManager()
        {
            crudFactory = new HistoryStudentRecruitedCrudFactory();
        }

        public HistoryStudentRecruited Create(HistoryStudentRecruited historyStudent)
        {
            try{
                return crudFactory.Create<HistoryStudentRecruited>(historyStudent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar datos", ex);
            }
        }

        public List<Student> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Student>();
        }

        public void Update(HistoryStudentRecruited historyStudent)
        {
            crudFactory.Update(historyStudent);
        }
        
        public void Finish(HistoryStudentRecruited historyStudent)
        {
            crudFactory.Finish(historyStudent);
        }


        public void Delete(HistoryStudentRecruited historyStudent)
        {
            crudFactory.Delete(historyStudent);
        }
    }
}
