using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Models;

namespace DataAccess.Mapper
{
    public class EntityUserMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ENTITY_USER_ID = "Entity_User_ID";
        private const string DB_COL_ENTITY_NAME = "Name";
        private const string DB_COL_ENTITY_ID = "Id";
        private const string DB_COL_ENTITY_QUANTITY = "Quantity";
        private const string DB_COL_ENTITY_STATUS = "User_Active_Status";
        private const string DB_COL_USER_EXIST = "User_Login";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_ENTITY_USER" };

            var entityUser = (EntityUser)entity;
            operation.AddVarcharParam(DB_COL_ENTITY_NAME, entityUser.Name);
            operation.AddVarcharParam(DB_COL_ENTITY_ID, entityUser.Id);
            operation.AddIntParam(DB_COL_ENTITY_QUANTITY, entityUser.Quantity);
            operation.AddVarcharParam(DB_COL_ENTITY_STATUS, entityUser.UserActiveStatus);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ENTITY_USER_BY_ID" };

            var entityUser = (EntityUser)entity;
            operation.AddIntParam(DB_COL_ENTITY_USER_ID, entityUser.EntityUserID);

            return operation;
        }

        public SqlOperation GetRetriveUserLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ENTITY_USER" };

            var entityUser = (EntityUser)entity;
            //operation.AddVarcharParam(DB_COL_ENTITY_USER, entityUser.EntityLogin);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_ENTITY_USER" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_ENTITY_USER" };

            var entityUser = (EntityUser)entity;
            operation.AddVarcharParam(DB_COL_ENTITY_NAME, entityUser.Name);
            operation.AddVarcharParam(DB_COL_ENTITY_ID, entityUser.Id);
            operation.AddIntParam(DB_COL_ENTITY_QUANTITY, entityUser.Quantity);

            return operation;
        }

       

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_ENTITY_USER" };

            var entityUser = (EntityUser)entity;
            operation.AddIntParam(DB_COL_ENTITY_USER_ID, entityUser.EntityUserID);
            return operation;
        }

        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var entityUser = (EntityUser)entity;
            operation.AddVarcharParam(DB_COL_USER_EXIST, entityUser.User_Login);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var entityUser = BuildObject(row);
                lstResults.Add(entityUser);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var entityUser = new EntityUser
            {
                EntityUserID = GetIntValue(row, DB_COL_ENTITY_USER_ID),
                Name = GetStringValue(row, DB_COL_ENTITY_NAME),
                Id = GetStringValue(row, DB_COL_ENTITY_ID),
                Quantity = GetIntValue(row, DB_COL_ENTITY_QUANTITY),
                UserActiveStatus = GetStringValue(row, DB_COL_ENTITY_STATUS),
            };

            return entityUser;
        }

    }
}
