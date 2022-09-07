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
    public class ReferenceMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_REFERENCE_ID = "Reference_ID";
        private const string DB_COL_REFERRER_NAME = "Referrer_Name";
        private const string DB_COL_WORKSTATION = "Worstation";
        private const string DB_COL_COMPANY = "Company";
        private const string DB_COL_PHONE = "Phone";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_STUDENT_ID = "Student_ID";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_REFERENCE" };

            var reference = (Reference)entity;

            operation.AddVarcharParam(DB_COL_REFERRER_NAME, reference.ReferrerName);
            operation.AddVarcharParam(DB_COL_WORKSTATION, reference.Workstation);
            operation.AddVarcharParam(DB_COL_COMPANY, reference.Company);
            operation.AddVarcharParam(DB_COL_PHONE, reference.Phone);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, reference.EntryDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, reference.StudentID);
            return operation;
        }
     

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_REFERENCE" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_REFERENCE_BY_ID" };

            var reference = (Reference)entity;
            operation.AddIntParam(DB_COL_REFERENCE_ID, reference.ReferenceID);

            return operation;
        }

        public SqlOperation GetRetriveStatementByStudent(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_REFERENCE_BY_STUDENT" };

            var reference = (Reference)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, reference.StudentID);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_REFERENCE" };

            var reference = (Reference)entity;

            operation.AddIntParam(DB_COL_REFERENCE_ID, reference.ReferenceID);
            operation.AddVarcharParam(DB_COL_REFERRER_NAME, reference.ReferrerName);
            operation.AddVarcharParam(DB_COL_WORKSTATION, reference.Workstation);
            operation.AddVarcharParam(DB_COL_COMPANY, reference.Company);
            operation.AddVarcharParam(DB_COL_PHONE, reference.Phone);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, reference.EntryDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, reference.StudentID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_REFERENCE" };

            var reference = (Reference)entity;
            operation.AddIntParam(DB_COL_REFERENCE_ID, reference.ReferenceID);

            return operation;
        }
        
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var reference = new Reference
            {
                ReferenceID = GetIntValue(row, DB_COL_REFERENCE_ID),
                ReferrerName = GetStringValue(row, DB_COL_REFERRER_NAME),
                Workstation = GetStringValue(row, DB_COL_WORKSTATION),
                Company = GetStringValue(row, DB_COL_COMPANY),
                Phone = GetStringValue(row, DB_COL_PHONE),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
            };

            return reference;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var reference = BuildObject(row);
                lstResults.Add(reference);
            }

            return lstResults;
        }

    }
}
