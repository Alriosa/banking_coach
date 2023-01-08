using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Models;
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


        public List<Student> RetrieveAllInRecruitment()
        {
            return crudStudent.RetrieveAllInRecruitment<Student>();
        }

        public List<Student> RetrieveAllInRecruitmentByEntity(Student student)
        {
            List<Student> c = null;
            try
            {
                c = crudStudent.RetrieveAllInRecruitmentByEntity<Student>(student);
                if (c == null)
                {
                    //    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }

        public Student RetrieveById(Student student)
        {
            Student c = null;
            try
            {
                c = crudStudent.Retrieve<Student>(student);
                if (c == null)
                {
                //    throw new BussinessException(4);
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

        public Student RetrieveByEmail(Student student)
        {
            Student c = null;
            try
            {
                c = crudStudent.RetrieveByUserByEmail<Student>(student);
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


        public void UpdatePassword(Student student)
        {
            Student s = null;
           

            try
            {
               crudStudent.UpdatePassword(student);                       
            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
         
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

        public void RecruitStudent(Student student)
        {
            crudStudent.RecruitStudent(student);
        }
        
        public void FinishRecruitStudent(Student student)
        {
            crudStudent.FinishRecruitStudent(student);
        }

        public void StudentProcessTestEconomic(Student student)
        {
            crudStudent.StudentProcessTestEconomic(student);
        }

        public void StudentProcessTestPsychometric(Student student)
        {
            crudStudent.StudentProcessTestPsychometric(student);
        }

        public void StudentProcessInterview(Student student)
        {
            crudStudent.StudentProcessInterview(student);
        }
        public void StudentProcessHiring(Student student)
        {
            crudStudent.StudentProcessHiring(student);
        }
    }
}
