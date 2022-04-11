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
    public class ListCrudFactory : CrudFactory
    {
        ListMapper mapper;

        public ListCrudFactory() : base()
        {
            mapper = new ListMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstValores = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllProvincesStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstValores.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstValores;
        }

        public List<T> RetrieveAllByListId<T>(BaseEntity entity, string listId)
        {
            var lstValores = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByListStatement(entity, listId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstValores.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstValores;
        }

        public override T RetrieveByUserLogin<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
