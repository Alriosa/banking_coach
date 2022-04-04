﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class RecruiterMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_RECRUITER_USER_ID = "Recruiter_User_ID";
        private const string DB_COL_RECRUITER_LOGIN = "Recruiter_Login";
        private const string DB_COL_RECRUITER_PASSWORD = "Recruiter_Password";
        private const string DB_COL_FINANTIAL_ASSOCIATION = "Finantial_Association";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_RECRUITER_STATUS = "User_Active_Status";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);
            operation.AddVarcharParam(DB_COL_RECRUITER_PASSWORD, recruiter.RecruiterPassword);
            operation.AddIntParam(DB_COL_FINANTIAL_ASSOCIATION, recruiter.FinantialAssociation);
            operation.AddVarcharParam(DB_COL_USER_TYPE, recruiter.UserType);
            operation.AddVarcharParam(DB_COL_RECRUITER_STATUS, recruiter.UserActiveStatus);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_RECRUITER_USER" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_RECRUITER_USER_STATUS" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);
            operation.AddVarcharParam(DB_COL_RECRUITER_PASSWORD, recruiter.RecruiterPassword);
            operation.AddIntParam(DB_COL_FINANTIAL_ASSOCIATION, recruiter.FinantialAssociation);
            operation.AddVarcharParam(DB_COL_USER_TYPE, recruiter.UserType);
            operation.AddVarcharParam(DB_COL_RECRUITER_STATUS, recruiter.UserActiveStatus);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var recruiter = BuildObject(row);
                lstResults.Add(recruiter);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var recruiter = new Recruiter
            {
                RecruiterUserID = GetIntValue(row, DB_COL_RECRUITER_USER_ID),
                RecruiterLogin = GetStringValue(row, DB_COL_RECRUITER_LOGIN),
                RecruiterPassword = GetStringValue(row, DB_COL_RECRUITER_PASSWORD),
                FinantialAssociation = GetIntValue(row, DB_COL_FINANTIAL_ASSOCIATION),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus = GetStringValue(row, DB_COL_RECRUITER_STATUS)
            };

            return recruiter;
        }
    }
}
