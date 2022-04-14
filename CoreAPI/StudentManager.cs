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
    public class StudentManager : BaseManager
    {
        private StudentCrudFactory crudStudent;

        public StudentManager()
        {
            crudStudent = new StudentCrudFactory();
        }

        public void Create(Student student)
        {
            try{

                // if (temp.AdminLogin.Equals("0"))
                crudStudent.Create(student);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<Student> RetrieveAll()
        {
            return crudStudent.RetrieveAll<Student>();
        }

        public Student RetrieveById(Student student)
        {
            Student c = null;
            try
            {
                c = crudStudent.Retrieve<Student>(student);
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

        public Student RetrieveByUserLogin(Student student)
        {
            Student c = null;
            try
            {
                c = crudStudent.RetrieveByUserLogin<Student>(student);
                /* if (c == null)
                 {
                     throw new BussinessException(4);
                 }*/
            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }

        public void Update(Student student)
        {
            crudStudent.Update(student);
        }

        public void Delete(Student student)
        {
            crudStudent.Delete(student);
        }

        public string ValidateExist(Student student)
        {
            var response = "0";
            try
            {
                response = crudStudent.ValidateUserExistence(student);
                if(response == "0")
                {
                    response = crudStudent.ValidateEmailExistence(student);
                }
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al validar datos", ex);
            }
            return response;
        }
    }
}
