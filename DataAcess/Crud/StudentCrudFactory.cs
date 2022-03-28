using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcess.Crud
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

        public override void Update(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(student));
        }

        public override void Delete(BaseEntity entity)
        {
            var student = (Student)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(student));
        }
    }
}
