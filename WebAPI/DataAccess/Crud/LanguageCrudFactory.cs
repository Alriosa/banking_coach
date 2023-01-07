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
    public class LanguageCrudFactory : CrudFactory
    {
        LanguageMapper mapper;

        public LanguageCrudFactory() : base()
        {
            mapper = new LanguageMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var language = (Language)entity;
            var sqlOperation = mapper.GetCreateStatement(language);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var language = (Language)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(language));
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
            var lstLanguage = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLanguage.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLanguage;
        }

        public override List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            var lstLanguage = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByStudent(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLanguage.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLanguage;
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var language = (Language)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(language));
        }
    }
}
