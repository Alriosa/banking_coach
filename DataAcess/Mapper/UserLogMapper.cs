using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class UserLogMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_RECORD_NUMBER = "Id_Record_Number";
        private const string DB_COL_EVENT_LOGGED = "Event_Logged";
        private const string DB_COL_DATE_LOGGED = "Date_Logged";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_USER_LOG" };

            var userLog = (UserLog)entity;
            operation.AddIntParam(DB_COL_ID_RECORD_NUMBER, userLog.IdRecordNumber);
            operation.AddVarcharParam(DB_COL_EVENT_LOGGED, userLog.EventLogged);
            operation.AddDateTimeParam(DB_COL_DATE_LOGGED, userLog.DateLogged);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_USER_LOG_BY_ID" };

            var userLog = (UserLog)entity;
            operation.AddIntParam(DB_COL_ID_RECORD_NUMBER, userLog.IdRecordNumber);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_USER_LOG" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUSTOMER_PR" };

            var userLog = (UserLog)entity;
            operation.AddIntParam(DB_COL_ID_RECORD_NUMBER, userLog.IdRecordNumber);
            operation.AddVarcharParam(DB_COL_EVENT_LOGGED, userLog.EventLogged);
            operation.AddDateTimeParam(DB_COL_DATE_LOGGED, userLog.DateLogged);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUSTOMER_PR" };

            var userLog = (UserLog)entity;
            operation.AddIntParam(DB_COL_ID_RECORD_NUMBER, userLog.IdRecordNumber);
            return operation;
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

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new UserLog
            {
                IdRecordNumber = GetIntValue(row, DB_COL_ID_RECORD_NUMBER),
                EventLogged = GetStringValue(row, DB_COL_EVENT_LOGGED),
                DateLogged = GetDateValue(row, DB_COL_DATE_LOGGED)
            };

            return customer;
        }

    }
}
