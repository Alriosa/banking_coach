using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Models;

namespace DataAccess.Mapper
{
    public class SysAdminMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_SYS_ADMIN_USER_ID = "Sys_Admin_User_ID";
        private const string DB_COL_ADMIN_LOGIN = "Admin_Login";
        private const string DB_COL_ADMIN_PASSWORD = "Admin_Password";
        private const string DB_COL_ADMIN_NAME = "Name";
        private const string DB_COL_ADMIN_EMAIL = "Email";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number"; 
        private const string DB_COL_ADMIN_STATUS = "User_Active_Status";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_EXIST = "User_Login";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_PASSWORD, sysAdmin.AdminPassword);
            operation.AddVarcharParam(DB_COL_ADMIN_NAME, sysAdmin.Name);
            operation.AddVarcharParam(DB_COL_ADMIN_EMAIL, sysAdmin.Email);
            operation.AddVarcharParam(DB_COL_ID_TYPE, sysAdmin.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, sysAdmin.IdentificationNumber);
            operation.AddVarcharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ADMIN_USER_BY_ID" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);

            return operation;
        }

        public SqlOperation GetRetriveUserLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_ADMIN_USER" };
            return operation;
        }

        //Select by Email
        public SqlOperation GetRetriveStatementByEmail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ADMIN_USER_BY_EMAIL" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_EMAIL, sysAdmin.Email);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_NAME, sysAdmin.Name);
            operation.AddVarcharParam(DB_COL_ADMIN_EMAIL, sysAdmin.Email);
            operation.AddVarcharParam(DB_COL_ID_TYPE, sysAdmin.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, sysAdmin.IdentificationNumber);
            return operation;
        }

        public SqlOperation GetUpdatePasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_PASSWORD_TBL_SYS_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_PASSWORD, sysAdmin.AdminPassword);

            return operation;
        }

        public SqlOperation GetRecoverPasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RECOVER_PASSWORD_TBL_ADMIN" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_EMAIL, sysAdmin.Email);
            operation.AddVarcharParam(DB_COL_ADMIN_PASSWORD, sysAdmin.AdminPassword);

            return operation;
        }
        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_ADMIN_USER_STATUS" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            return operation;
        }

        public SqlOperation GetSoftDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CHANGE_STATUS_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            operation.AddVarcharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);
            return operation;
        }


        public SqlOperation GetChangeStatusStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CHANGE_STATUS_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            operation.AddVarcharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);
            return operation;
        }



        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_USER_EXIST, sysAdmin.AdminLogin);

            return operation;
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

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var sysAdmin = new SysAdmin
            {
                SysAdminUserID = GetIntValue(row, DB_COL_SYS_ADMIN_USER_ID),
                AdminLogin = GetStringValue(row, DB_COL_ADMIN_LOGIN),
                AdminPassword = GetStringValue(row, DB_COL_ADMIN_PASSWORD),
                Name = GetStringValue(row, DB_COL_ADMIN_NAME),
                Email = GetStringValue(row, DB_COL_ADMIN_EMAIL),
                IdType = GetStringValue(row, DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus= GetStringValue(row, DB_COL_ADMIN_STATUS)
            };

            return sysAdmin;
        }

        public BaseEntity BuildObjectBasic(Dictionary<string, object> row)
        {
            var sysAdmin = new SysAdmin
            {
                SysAdminUserID = GetIntValue(row, DB_COL_SYS_ADMIN_USER_ID),
                AdminLogin = GetStringValue(row, DB_COL_ADMIN_LOGIN),
                Name = GetStringValue(row, DB_COL_ADMIN_NAME),
                Email = GetStringValue(row, DB_COL_ADMIN_EMAIL),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus = GetStringValue(row, DB_COL_ADMIN_STATUS)
            };

            return sysAdmin;
        }

        public BaseEntity BuildObjectLogin(Dictionary<string, object> row)
        {
            var sysAdmin = new SysAdmin
            {
                SysAdminUserID = GetIntValue(row, DB_COL_SYS_ADMIN_USER_ID),
                AdminLogin = GetStringValue(row, DB_COL_ADMIN_LOGIN),
                User_Login = GetStringValue(row, DB_COL_USER_EXIST),
                Name = GetStringValue(row, DB_COL_ADMIN_NAME),
                Email = GetStringValue(row, DB_COL_ADMIN_EMAIL),
                IdType = GetStringValue(row, DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                UserActiveStatus = GetStringValue(row, DB_COL_ADMIN_STATUS)
            };

            return sysAdmin;
        }
    }
}
