using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;
using DataAccess.Mapper;

namespace DataAcess.Mapper
{
    public class SecurityMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_USER_LOGIN = "User_Login";
        private const string DB_COL_USER_PASSWORD = "User_Password";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_NAME = "Name";
        private const string DB_COL_USER_EMAIL = "Email";
        private const string DB_COL_USER_ACTIVE_STATUS = "User_Active_Status";
        private const string DB_COL_RESULT = "Result";


        public SqlOperation GetUserLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_LOGIN" };

            var security = (Security)entity;


            operation.AddVarcharParam(DB_COL_USER_LOGIN, security.UserLogin);
            operation.AddVarcharParam(DB_COL_USER_PASSWORD, security.UserPassword);
            
            return operation;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var security = new Security
            {
                UserLogin = GetStringValue(row, DB_COL_USER_LOGIN),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                Name = GetStringValue(row, DB_COL_USER_NAME),
                Email = GetStringValue(row, DB_COL_USER_EMAIL),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_TYPE),
                Result = GetStringValue(row, DB_COL_RESULT),
            };

            return security;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var sysAdmin = BuildObject(row);
                lstResults.Add(sysAdmin);
            }

            return lstResults;
        }


    }
}
