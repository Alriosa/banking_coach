using DataAcess.Crud;
using Models;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ExtraCourseManager : BaseManager
    {
        private ExtraCourseCrudFactory crudExtraCourse;

        public ExtraCourseManager()
        {
            crudExtraCourse = new ExtraCourseCrudFactory();
        }

        public void Create(ExtraCourse extraCourse)
        {
            try
            {

                // if (temp.AdminLogin.Equals("0"))
                crudExtraCourse.Create(extraCourse);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<ExtraCourse> RetrieveAll()
        {
            return crudExtraCourse.RetrieveAll<ExtraCourse>();
        }

        public ExtraCourse RetrieveById(ExtraCourse extraCourse)
        {
            ExtraCourse c = null;
            try
            {
                c = crudExtraCourse.Retrieve<ExtraCourse>(extraCourse);
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

        public List<ExtraCourse> RetrieveAllByStudent(ExtraCourse extraCourse)
        {
            return crudExtraCourse.RetrieveAllById<ExtraCourse>(extraCourse);
        }

        public void Update(ExtraCourse extraCourse)
        {
            crudExtraCourse.Update(extraCourse);
        }

        public void Delete(ExtraCourse extraCourse)
        {
            crudExtraCourse.Delete(extraCourse);
        }
    }
}
