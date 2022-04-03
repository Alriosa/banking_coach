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
    public class SysAdminCrudFactory : CrudFactory
    {
        SysAdminMapper mapper;

        public SysAdminCrudFactory() : base()
        { 
            mapper = new SysAdminMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var sysAdmin = (SysAdmin)entity;
            var sqlOperation = mapper.GetCreateStatement(sysAdmin);

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
            var lstSysAdmin = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstSysAdmin.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstSysAdmin;
        }

        public override void Update(BaseEntity entity)
        {
            var sysAdmin = (SysAdmin)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(sysAdmin));
        }

        public override void Delete(BaseEntity entity)
        {
            var sysAdmin = (SysAdmin)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(sysAdmin));
        }


        public T ValidateUserExistence<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetValidateUserNameExistenceStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
    }
}
