using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class FinancialUserMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_FINANCIAL_USER_ID = "Financial_User_ID";
        private const string DB_COL_FINANCIAL_USER = "Financial_User";
        private const string DB_COL_FINANCIAL_PASSWORD = "Financial_Password";
        private const string DB_COL_FINANCIAL_STATUS = "User_Active_Status";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_EXIST = "User_Login";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_FINANCIAL_USER" };

            var financialUser = (FinancialUser)entity;
            operation.AddVarcharParam(DB_COL_FINANCIAL_USER, financialUser.FinancialLogin);
            operation.AddVarcharParam(DB_COL_FINANCIAL_PASSWORD, financialUser.FinancialPassword);
            operation.AddVarcharParam(DB_COL_FINANCIAL_STATUS, financialUser.UserActiveStatus);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_FINANCIAL_USER_BY_ID" };

            var financialUser = (FinancialUser)entity;
            operation.AddIntParam(DB_COL_FINANCIAL_USER_ID, financialUser.FinancialUserID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_FINANCIAL_USER" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_FINANCIAL_USER_STATUS" };

            var financialUser = (FinancialUser)entity;
            operation.AddIntParam(DB_COL_FINANCIAL_USER_ID, financialUser.FinancialUserID);
            operation.AddVarcharParam(DB_COL_FINANCIAL_USER, financialUser.FinancialLogin);
            operation.AddVarcharParam(DB_COL_FINANCIAL_PASSWORD, financialUser.FinancialPassword);
            operation.AddVarcharParam(DB_COL_FINANCIAL_STATUS, financialUser.UserActiveStatus);
            operation.AddVarcharParam(DB_COL_USER_TYPE, financialUser.UserType);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_FINANCIAL_USER" };

            var financialUser = (FinancialUser)entity;
            operation.AddIntParam(DB_COL_FINANCIAL_USER_ID, financialUser.FinancialUserID);
            return operation;
        }

        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var financialUser = (FinancialUser)entity;
            operation.AddVarcharParam(DB_COL_USER_EXIST, financialUser.FinancialLogin);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var financialUser = BuildObject(row);
                lstResults.Add(financialUser);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var financialUser = new FinancialUser
            {
                FinancialUserID = GetIntValue(row, DB_COL_FINANCIAL_USER_ID),
                FinancialLogin = GetStringValue(row, DB_COL_FINANCIAL_USER),
                FinancialPassword = GetStringValue(row, DB_COL_FINANCIAL_PASSWORD),
                UserType = GetStringValue(row, DB_COL_FINANCIAL_STATUS),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_TYPE)
            };

            return financialUser;
        }

    }
}
