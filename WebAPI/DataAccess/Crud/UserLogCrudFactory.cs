using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class UserLogCrudFactory : CrudFactory
    {
        UserLogMapper mapper;

        public UserLogCrudFactory() : base()
        {
            mapper = new UserLogMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var userLog = (UserLog)entity;
            var sqlOperation = mapper.GetCreateStatement(userLog);

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
            var lstUserLog = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUserLog.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUserLog;
        }

        public override void Update(BaseEntity entity)
        {
            var userLog = (UserLog)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(userLog));
        }

        public override void Delete(BaseEntity entity)
        {
            var userLog = (UserLog)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(userLog));
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
