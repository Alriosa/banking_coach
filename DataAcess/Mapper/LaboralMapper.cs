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
    public class LaboralMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_LABORAL_ID = "Laboral_ID";
        private const string DB_COL_WORK_POSTITION = "Work_Position";
        private const string DB_COL_WORKSTATION = "Worstation";
        private const string DB_COL_COMPANY = "Company";
        private const string DB_COL_RESPONSABILITIES = "Responsabilites";
        private const string DB_COL_START_DATE = "Start_Date";
        private const string DB_COL_END_DATE = "End_Date";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_STUDENT_ID = "Student_ID";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_LABORAL_STUDENT" };

            var laboral = (Laboral)entity;

            operation.AddVarcharParam(DB_COL_WORK_POSTITION, laboral.WorkPosition);
            operation.AddVarcharParam(DB_COL_WORKSTATION, laboral.Workstation);
            operation.AddVarcharParam(DB_COL_COMPANY, laboral.Company);
            operation.AddVarcharParam(DB_COL_RESPONSABILITIES, laboral.Responsabilites);
            operation.AddDateTimeParam(DB_COL_START_DATE, laboral.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, laboral.EndDate);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, laboral.EntryDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, laboral.StudentID);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_LABORAL" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_LABORAL_BY_ID" };

            var laboral = (Laboral)entity;
            operation.AddIntParam(DB_COL_LABORAL_ID, laboral.LaboralID);

            return operation;
        }

        public SqlOperation GetRetriveStatementByStudent(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_LABORAL_BY_STUDENT" };

            var laboral = (Laboral)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, laboral.StudentID);

            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_LABORAL_STUDENT" };

            var laboral = (Laboral)entity;

            operation.AddIntParam(DB_COL_LABORAL_ID, laboral.LaboralID);
            operation.AddVarcharParam(DB_COL_WORK_POSTITION, laboral.WorkPosition);
            operation.AddVarcharParam(DB_COL_WORKSTATION, laboral.Workstation);
            operation.AddVarcharParam(DB_COL_COMPANY, laboral.Company);
            operation.AddVarcharParam(DB_COL_RESPONSABILITIES, laboral.Responsabilites);
            operation.AddDateTimeParam(DB_COL_START_DATE, laboral.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, laboral.EndDate);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, laboral.EntryDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, laboral.StudentID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_LABORAL" };

            var laboral = (Laboral)entity;
            operation.AddIntParam(DB_COL_LABORAL_ID, laboral.LaboralID);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var laboral = new Laboral
            {
                LaboralID = GetIntValue(row, DB_COL_LABORAL_ID),
                WorkPosition = GetStringValue(row, DB_COL_WORK_POSTITION),
                Workstation = GetStringValue(row, DB_COL_WORKSTATION),
                Company = GetStringValue(row, DB_COL_COMPANY),
                Responsabilites = GetStringValue(row, DB_COL_RESPONSABILITIES),
                StartDate = GetDateValue(row, DB_COL_START_DATE),
                EndDate = GetDateValue(row, DB_COL_END_DATE),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
            };

            return laboral;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {

            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var laboral = BuildObject(row);
                lstResults.Add(laboral);
            }

            return lstResults;
        }

    }
}
