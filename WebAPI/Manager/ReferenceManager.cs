using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class ReferenceManager : BaseManager
    {
        private ReferenceCrudFactory crudReference;

        public ReferenceManager()
        {
            crudReference = new ReferenceCrudFactory();
        }

        public void Create(Reference reference)
        {
            try
            {

                // if (temp.AdminLogin.Equals("0"))
                crudReference.Create(reference);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<Reference> RetrieveAll()
        {
            return crudReference.RetrieveAll<Reference>();
        }

        public Reference RetrieveById(Reference reference)
        {
            Reference c = null;
            try
            {
                c = crudReference.Retrieve<Reference>(reference);
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

        public List<Reference> RetrieveAllByStudent(Reference reference)
        {
            return crudReference.RetrieveAllById<Reference>(reference);
        }

        public void Update(Reference reference)
        {
            crudReference.Update(reference);
        }

        public void Delete(Reference reference)
        {
            crudReference.Delete(reference);
        }
    }
}
