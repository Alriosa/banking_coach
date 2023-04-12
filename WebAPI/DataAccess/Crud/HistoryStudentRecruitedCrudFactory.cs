using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Models;
using WebAPI.Models;

namespace DataAccess.Crud
{
    public class HistoryStudentRecruitedCrudFactory : CrudFactory
    {
        HistoryStudentRecruitedMapper mapper;

        public HistoryStudentRecruitedCrudFactory() : base()
        {
            mapper = new HistoryStudentRecruitedMapper();
            dao = SqlDao.GetInstance();
        }

        public T Create<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCreateStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
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
            var history = (HistoryStudentRecruited)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(history));
        }
        public void Finish(BaseEntity entity)
        {
            var history = (HistoryStudentRecruited)entity;
            dao.ExecuteProcedure(mapper.GetFinishStatement(history));
        }
        public override void Delete(BaseEntity entity)
        {
            var history = (HistoryStudentRecruited)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(history));
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
