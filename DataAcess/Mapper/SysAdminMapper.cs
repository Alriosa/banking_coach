using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class SysAdminMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_SYS_ADMIN_USER_ID = "Sys_Admin_User_ID";
        private const string DB_COL_ADMIN_LOGIN = "Admin_Login";
        private const string DB_COL_ADMIN_PASSWORD = "Admin_Password";
        private const string DB_COL_ADMIN_STATUS = "User_Active_Status";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_EXIST = "Login";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_PASSWORD, sysAdmin.AdminPassword);
            operation.AddCharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);
            operation.AddCharParam(DB_COL_USER_TYPE, sysAdmin.UserType);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ADMIN_USER_BY_ID" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_ADMIN_USER" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_ADMIN_USER_STATUS" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);
            operation.AddVarcharParam(DB_COL_ADMIN_PASSWORD, sysAdmin.AdminPassword);
            operation.AddCharParam(DB_COL_ADMIN_STATUS, sysAdmin.UserActiveStatus);
            operation.AddCharParam(DB_COL_USER_TYPE, sysAdmin.UserType);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_ADMIN_USER" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddIntParam(DB_COL_SYS_ADMIN_USER_ID, sysAdmin.SysAdminUserID);
            return operation;
        }

        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var sysAdmin = (SysAdmin)entity;
            operation.AddVarcharParam(DB_COL_ADMIN_LOGIN, sysAdmin.AdminLogin);

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
                UserType = GetCharValue(row, DB_COL_ADMIN_STATUS),
                UserActiveStatus= GetCharValue(row, DB_COL_USER_TYPE)
            };

            return sysAdmin;
        }
    }
}
