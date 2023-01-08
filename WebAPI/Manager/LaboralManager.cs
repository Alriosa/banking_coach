using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DataAcess.Crud;
using Models;
using Exceptions;

namespace CoreAPI
{
    public class LaboralManager : BaseManager
    {
        private LaboralCrudFactory crudLaboral;

        public LaboralManager()
        {
            crudLaboral = new LaboralCrudFactory();
        }

        public void Create(Laboral laboral)
        {
            try
            {

                // if (temp.AdminLogin.Equals("0"))
                crudLaboral.Create(laboral);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<Laboral> RetrieveAll()
        {
            return crudLaboral.RetrieveAll<Laboral>();
        }

        public Laboral RetrieveById(Laboral laboral)
        {
            Laboral c = null;
            try
            {
                c = crudLaboral.Retrieve<Laboral>(laboral);
               /* if (c == null)
                {
                    throw new BussinessException(4);
                }*/
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
            return c;
        }

        public List<Laboral> RetrieveByStudent(Laboral laboral)
        {
            return crudLaboral.RetrieveAllById<Laboral>(laboral);
        }

        public void Update(Laboral laboral)
        {
            crudLaboral.Update(laboral);
        }

        public void Delete(Laboral laboral)
        {
            crudLaboral.Delete(laboral);
        }

        
    }
}
