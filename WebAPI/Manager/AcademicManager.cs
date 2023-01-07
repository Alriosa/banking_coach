using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class AcademicManager : BaseManager
    {
        private AcademicCrudFactory crudAcademic;

        public AcademicManager()
        {
            crudAcademic = new AcademicCrudFactory();
        }

        public void Create(Academic academic)
        {
            try
            {

                // if (temp.AdminLogin.Equals("0"))
                crudAcademic.Create(academic);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<Academic> RetrieveAll()
        {
            return crudAcademic.RetrieveAll<Academic>();
        }

        public Academic RetrieveById(Academic academic)
        {
            Academic c = null;
            try
            {
                c = crudAcademic.Retrieve<Academic>(academic);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
            return c;
        }
        public List<Academic> RetrieveByStudent(Academic academic)
        {
            return crudAcademic.RetrieveAllById<Academic>(academic);
        }

        public void Update(Academic academic)
        {
            crudAcademic.Update(academic);
        }

        public void Delete(Academic academic)
        {
            crudAcademic.Delete(academic);
        }
    }
}
