using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class ViewPermissionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_USER_TYPE = "Id_User_Type";
        private const string DB_COL_CONTROLLER_NAME = "Controller_Name";
        private const string DB_COL_VIEW_NAME = "View_Name";
        private const string DB_COL_VIEW_DESCRIPTION = "View_Description";
        private const string DB_COL_GROUP_VIEW = "Group_View";

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
            var operation = new SqlOperation { ProcedureName = "RET_VIEW_BY_USER" };

            var viewPermission = (ViewPermission)entity;
            operation.AddVarcharParam(DB_COL_ID_USER_TYPE, viewPermission.IdUserType);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var viewPermission = new ViewPermission
            {
                IdUserType = GetStringValue(row, DB_COL_ID_USER_TYPE),
                ControllerName = GetStringValue(row, DB_COL_CONTROLLER_NAME),
                ViewName = GetStringValue(row, DB_COL_VIEW_NAME),
                ViewDescription = GetStringValue(row, DB_COL_VIEW_DESCRIPTION),
                GroupView = GetStringValue(row, DB_COL_GROUP_VIEW)
            };

            return viewPermission;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }
    }
}
