using DataAccess.Crud;
using DataAccess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Crud
{
    public class LaboralCrudFactory : CrudFactory
    {
        LaboralMapper mapper;

        public LaboralCrudFactory() : base()
        {
            mapper = new LaboralMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var laboral = (Laboral)entity;
            var sqlOperation = mapper.GetCreateStatement(laboral);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var laboral = (Laboral)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(laboral));
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
            var lstLaboral = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLaboral.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLaboral;
        }

        public override List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            var lstLaboral = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByStudent(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLaboral.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLaboral;
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var laboral = (Laboral)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(laboral));
        }
    }
}
