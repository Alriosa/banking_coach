﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class EntityUserCrudFactory : CrudFactory
    {
        EntityUserMapper mapper;
        public EntityUserCrudFactory() : base()
        {
            mapper = new EntityUserMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var entityUserCrud = (EntityUser)entity;
            var sqlOperation = mapper.GetCreateStatement(entityUserCrud);

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
            var lstEntityUser = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstEntityUser.Add((T)Convert.ChangeType(c, typeof(T)));
                    
                }
            }

            return lstEntityUser;
        }

        public override void Update(BaseEntity entity)
        {
            var entityUserCrud = (EntityUser)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(entityUserCrud));
        }

        public override void Delete(BaseEntity entity)
        {
            var entityUserCrud = (EntityUser)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entityUserCrud));
        }


        public bool ValidateUserExistence(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetValidateUserNameExistenceStatement(entity));
            var dic = new Dictionary<string, object>();

            bool response = false;

            var result = lstResult.SelectMany(d => d.Values).ToList().ToArray()[0];
            if (result.Equals("1"))
            {
                response = true;
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
    }
}
