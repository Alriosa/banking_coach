using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Models;

namespace DataAccess.Crud
{
    public class StudentCrudFactory : CrudFactory
    {
        StudentMapper mapper;

        public StudentCrudFactory() : base()
        {
            mapper = new StudentMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var student = (Student)entity;
            var sqlOperation = mapper.GetCreateStatement(student);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstStudent = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstStudent.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstStudent;
        }


        public List<T> RetrieveAllInRecruitment<T>()
        {
            var lstStudent = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllInRecruitmentStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsInRecruitment(lstResult);
                foreach (var c in objs)
                {
                    lstStudent.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstStudent;
        }

        public List<T> RetrieveAllInRecruitmentByEntity<T>(BaseEntity entity)
        {
            var lstStudent = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllInRecruitmentByEntityStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsInRecruitment(lstResult);
                foreach (var c in objs)
                {
                    lstStudent.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstStudent;
        }

        public override void Update(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(student));
        }

        public void UpdatePassword(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetRecoverPasswordStatement(student));
        }

        public override void Delete(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(student));
        }

        public string ValidateUserExistence(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetValidateUserNameExistenceStatement(entity));
            var dic = new Dictionary<string, object>();

            var response = "0";

            var result = lstResult.SelectMany(d => d.Values).ToList().ToArray()[0];
            if (result.Equals("1"))
            {
                response = "1";
            }
            return response;
        }

        public string ValidateEmailExistence(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetValidateEmailExistenceStatement(entity));
            var dic = new Dictionary<string, object>();

            var response = "0";

            var result = lstResult.SelectMany(d => d.Values).ToList().ToArray()[0];
            if (result.Equals("1"))
            {
                response = "2";
            }
            return response;
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveUserLoginStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public T RetrieveByUserByEmail<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByEmail(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectBasic(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }


        public void RecruitStudent(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetRecruitStudentStatement(student));
        }
        public void FinishRecruitStudent(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetFinishRecruitStudentStatement(student));
        }
        public void StudentProcessTestEconomic(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateProcessTestEconomicStatement(student));
        }
        public void StudentProcessTestPsychometric(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateProcessTestPsychometricStatement(student));
        }
        public void StudentProcessInterview(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateProcessInterviewStatement(student));
        }
        public void StudentProcessHiring(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateProcessHiringStatement(student));
        }
    }
}
