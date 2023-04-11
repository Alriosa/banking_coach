using DataAccess.Dao;
using Models;
using System.Collections.Generic;
using WebAPI.Models;

namespace DataAccess.Mapper
{
    public class HistoryStudentRecruitedMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "Id";
        private const string DB_COL_STUDENT_ID = "Student_ID";
        private const string DB_COL_FIRST_NAME = "First_Name";
        private const string DB_COL_FIRST_LAST_NAME = "First_Last_Name";
        private const string DB_COL_SECOND_LAST_NAME = "Second_Last_Name";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number";
        private const string DB_COL_ENTITY_ID = "Entity_Id";
        private const string DB_COL_ENTITY_USER = "Entity_User";
        private const string DB_COL_RECRUITER_USER = "Recruiter_User";
        private const string DB_COL_RECRUITER_NAME = "Recruiter_Name";
        private const string DB_COL_STATUS_ECONOMIC = "Status_Economic";
        private const string DB_COL_STATUS_PSYCHOMETRIC = "Status_Psychometric";
        private const string DB_COL_STATUS_INTERVIEW = "Status_Interview";
        private const string DB_COL_STATUS_HIRED = "Status_Hired";
        private const string DB_COL_CREATE_DATE = "Create_Date";
        private const string DB_COL_UPDATE_DATE = "Update_Date";
        private const string DB_COL_FINISH_DATE = "Finish_Date";




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_HISTORY_STUDENT_RECRUITED" };

            var historyStudent = (HistoryStudentRecruited)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, historyStudent.StudentID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, historyStudent.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, historyStudent.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, historyStudent.SecondLastName);
            operation.AddVarcharParam(DB_COL_ID_TYPE, historyStudent.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, historyStudent.IdentificationNumber);
            operation.AddVarcharParam(DB_COL_ENTITY_ID, historyStudent.EntityId);
            operation.AddVarcharParam(DB_COL_ENTITY_USER, historyStudent.EntityUser);
            operation.AddVarcharParam(DB_COL_RECRUITER_USER, historyStudent.RecruiterUser);
            operation.AddVarcharParam(DB_COL_RECRUITER_NAME, historyStudent.RecruiterName);
            operation.AddVarcharParam(DB_COL_STATUS_ECONOMIC, historyStudent.StatusEconomic);
            operation.AddVarcharParam(DB_COL_STATUS_PSYCHOMETRIC, historyStudent.StatusPsychometric);
            operation.AddVarcharParam(DB_COL_STATUS_INTERVIEW, historyStudent.StatusInterview);
            operation.AddVarcharParam(DB_COL_STATUS_HIRED, historyStudent.StatusHired);
            operation.AddVarcharParam(DB_COL_CREATE_DATE, historyStudent.CreateDate);
            operation.AddVarcharParam(DB_COL_UPDATE_DATE, historyStudent.UpdateDate);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_HISTORY_STUDENTS_RECRUITED" };
            return operation;
        }
       
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_HISTORY_STUDENT_RECRUITED" };

            var historyStudent = (HistoryStudentRecruited)entity;
            operation.AddIntParam(DB_COL_ID, historyStudent.Id);
            operation.AddIntParam(DB_COL_STUDENT_ID, historyStudent.StudentID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, historyStudent.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, historyStudent.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, historyStudent.SecondLastName);
            operation.AddVarcharParam(DB_COL_ID_TYPE, historyStudent.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, historyStudent.IdentificationNumber);
            operation.AddVarcharParam(DB_COL_ENTITY_ID, historyStudent.EntityId);
            operation.AddVarcharParam(DB_COL_ENTITY_USER, historyStudent.EntityUser);
            operation.AddVarcharParam(DB_COL_RECRUITER_USER, historyStudent.RecruiterUser);
            operation.AddVarcharParam(DB_COL_RECRUITER_NAME, historyStudent.RecruiterName);
            operation.AddVarcharParam(DB_COL_STATUS_ECONOMIC, historyStudent.StatusEconomic);
            operation.AddVarcharParam(DB_COL_STATUS_PSYCHOMETRIC, historyStudent.StatusPsychometric);
            operation.AddVarcharParam(DB_COL_STATUS_INTERVIEW, historyStudent.StatusInterview);
            operation.AddVarcharParam(DB_COL_STATUS_HIRED, historyStudent.StatusHired);
            operation.AddVarcharParam(DB_COL_CREATE_DATE, historyStudent.CreateDate);
            operation.AddVarcharParam(DB_COL_UPDATE_DATE, historyStudent.UpdateDate);
            operation.AddVarcharParam(DB_COL_FINISH_DATE, historyStudent.FinishDate);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var student = BuildObject(row);
                lstResults.Add(student);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var historyStudent = new HistoryStudentRecruited
            {
                Id = GetIntValue(row, DB_COL_ID),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                FirstLastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                IdType = GetStringValue(row, DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                EntityId = GetStringValue(row, DB_COL_ENTITY_ID),
                EntityUser = GetStringValue(row, DB_COL_ENTITY_USER),
                RecruiterUser = GetStringValue(row, DB_COL_ENTITY_USER),
                RecruiterName = GetStringValue(row, DB_COL_ENTITY_USER),
                StatusEconomic = GetStringValue(row, DB_COL_STATUS_ECONOMIC),
                StatusPsychometric = GetStringValue(row, DB_COL_STATUS_PSYCHOMETRIC),
                StatusInterview = GetStringValue(row, DB_COL_STATUS_INTERVIEW),
                StatusHired = GetStringValue(row, DB_COL_STATUS_HIRED),
                CreateDate = GetStringValue(row, DB_COL_CREATE_DATE),
                UpdateDate = GetStringValue(row, DB_COL_UPDATE_DATE),
                FinishDate = GetStringValue(row, DB_COL_FINISH_DATE),
            };

            return historyStudent;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
