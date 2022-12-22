using System;
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
        private const string DB_COL_RECRUITER_NAME = "Name";
        private const string DB_COL_RECRUITER_EMAIL = "Email";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number";
        private const string DB_COL_ENTITY_ASSOCIATION = "Entity_Association";
        private const string DB_COL_ENTITY_ASSOCIATION_NAME = "Entity_Association_Name";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_RECRUITER_STATUS = "User_Active_Status";
        private const string DB_COL_USER_EXIST = "User_Login";
        private const string DB_COL_QUANTITY_DOWNLOAD = "Quantity_Download";




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);
            operation.AddVarcharParam(DB_COL_RECRUITER_PASSWORD, recruiter.RecruiterPassword);
            operation.AddVarcharParam(DB_COL_RECRUITER_NAME, recruiter.Name);
            operation.AddVarcharParam(DB_COL_RECRUITER_EMAIL, recruiter.Email);
            operation.AddVarcharParam(DB_COL_ID_TYPE, recruiter.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, recruiter.IdentificationNumber);
            operation.AddIntParam(DB_COL_ENTITY_ASSOCIATION, recruiter.EntityAssociation);
            operation.AddVarcharParam(DB_COL_RECRUITER_STATUS, recruiter.UserActiveStatus);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_RECRUITER_USER_BY_ID" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);

            return operation;
        }

        public SqlOperation GetRetriveUserLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);

            return operation;
        }
        //Select by Email
        public SqlOperation GetRetriveStatementByEmail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_RECRUITER_BY_EMAIL" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_EMAIL, recruiter.Email);

            return operation;
        }

        public SqlOperation GetRetriveEntityIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ENTITY_BY_RECRUITER" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_RECRUITER_USER" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_LOGIN, recruiter.RecruiterLogin);
            operation.AddVarcharParam(DB_COL_RECRUITER_NAME, recruiter.Name);
            operation.AddVarcharParam(DB_COL_RECRUITER_EMAIL, recruiter.Email);
            operation.AddVarcharParam(DB_COL_ID_TYPE, recruiter.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, recruiter.IdentificationNumber);
            return operation;
        }

        public SqlOperation GetUpdatePasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_PASSWORD_TBL_RECRUITER" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);
            operation.AddVarcharParam(DB_COL_RECRUITER_PASSWORD, recruiter.RecruiterPassword);

            return operation;
        }

        public SqlOperation GetRecoverPasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RECOVER_PASSWORD_TBL_RECRUITER" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_RECRUITER_EMAIL, recruiter.Email);
            operation.AddVarcharParam(DB_COL_RECRUITER_PASSWORD, recruiter.RecruiterPassword);

            return operation;
        }

        public SqlOperation GetAddQuantityStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_ADD_QUANTITY_DOWNLOAD" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_RECRUITER_USER" };

            var recruiter = (Recruiter)entity;
            operation.AddIntParam(DB_COL_RECRUITER_USER_ID, recruiter.RecruiterUserID);
            return operation;
        }
        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var recruiter = (Recruiter)entity;
            operation.AddVarcharParam(DB_COL_USER_EXIST, recruiter.RecruiterLogin);

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
                Name = GetStringValue(row, DB_COL_RECRUITER_NAME),
                Email = GetStringValue(row, DB_COL_RECRUITER_EMAIL),
                IdType = GetStringValue(row, DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                EntityAssociation = GetIntValue(row, DB_COL_ENTITY_ASSOCIATION),
                EntityAssociationName = GetStringValue(row, DB_COL_ENTITY_ASSOCIATION_NAME),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus = GetStringValue(row, DB_COL_RECRUITER_STATUS),
                QuantityDownload = GetIntValue(row, DB_COL_QUANTITY_DOWNLOAD)
            };

            return recruiter;
        }

        public BaseEntity BuildObjectBasic(Dictionary<string, object> row)
        {
            var recruiter = new Recruiter
            {
                RecruiterUserID = GetIntValue(row, DB_COL_RECRUITER_USER_ID),
                RecruiterLogin = GetStringValue(row, DB_COL_RECRUITER_LOGIN),
                Name = GetStringValue(row, DB_COL_RECRUITER_NAME),
                Email = GetStringValue(row, DB_COL_RECRUITER_EMAIL),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus = GetStringValue(row, DB_COL_RECRUITER_STATUS),
                QuantityDownload = GetIntValue(row, DB_COL_QUANTITY_DOWNLOAD)
            };

            return recruiter;
        }
    }
}
