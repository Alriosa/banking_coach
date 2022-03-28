﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcess.Crud
{

    public class RecruiterCrudFactory : CrudFactory
        {
            RecruiterMapper mapper;

            public RecruiterCrudFactory() : base()
            {
                mapper = new RecruiterMapper();
                dao = SqlDao.GetInstance();
            }

            public override void Create(BaseEntity entity)
            {
                var recruiter = (Recruiter)entity;
                var sqlOperation = mapper.GetCreateStatement(recruiter);

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
                var lstRecruiter = new List<T>();

                var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
                var dic = new Dictionary<string, object>();
                if (lstResult.Count > 0)
                {
                    var objs = mapper.BuildObjects(lstResult);
                    foreach (var c in objs)
                    {
                        lstRecruiter.Add((T)Convert.ChangeType(c, typeof(T)));
                    }
                }

                return lstRecruiter;
            }

            public override void Update(BaseEntity entity)
            {
                var recruiter = (Recruiter)entity;
                dao.ExecuteProcedure(mapper.GetUpdateStatement(recruiter));
            }

            public override void Delete(BaseEntity entity)
            {
                var recruiter = (Recruiter)entity;
                dao.ExecuteProcedure(mapper.GetDeleteStatement(recruiter));
            }
        }
    }
