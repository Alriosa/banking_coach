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
    public class AcademicMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ACADEMIC_ID = "Academic_ID";
        private const string DB_COL_INSTITUTION = "Institution";
        private const string DB_COL_DEGREE_TYPE = "Degree_Type";
        private const string DB_COL_UNIVERSTITY_PREPARATION = "University_Preparation";
        private const string DB_COL_CAREER = "Career";
        private const string DB_COL_STATUS = "Status";
        private const string DB_COL_CERTIFICATE = "Certificate";
        private const string DB_COL_START_DATE = "Start_Date";
        private const string DB_COL_END_DATE = "End_Date";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_STUDENT_ID = "Student_ID";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_ACADEMIC_STUDENT" };

            var academic = (Academic)entity;

            operation.AddVarcharParam(DB_COL_INSTITUTION, academic.Institution);
            operation.AddVarcharParam(DB_COL_DEGREE_TYPE, academic.DegreeType);
            operation.AddVarcharParam(DB_COL_UNIVERSTITY_PREPARATION, academic.University_Preparation);
            operation.AddVarcharParam(DB_COL_CAREER, academic.Career);
            operation.AddVarcharParam(DB_COL_STATUS, academic.Status);
            operation.AddVarcharParam(DB_COL_CERTIFICATE, academic.Certificate);
            operation.AddDateTimeParam(DB_COL_START_DATE, academic.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, academic.EndDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, academic.StudentID);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {   var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_ACADEMIC" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ACADEMIC_BY_ID" };

            var academic = (Academic)entity;
            operation.AddIntParam(DB_COL_ACADEMIC_ID, academic.AcademicID);

            return operation;
        }

        public SqlOperation GetRetriveStatementByStudent(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_ACADEMIC_BY_STUDENT" };

            var academic = (Academic)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, academic.StudentID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_ACADEMIC_STUDENT" };

            var academic = (Academic)entity;

            operation.AddIntParam(DB_COL_ACADEMIC_ID, academic.AcademicID);
            operation.AddVarcharParam(DB_COL_INSTITUTION, academic.Institution);
            operation.AddVarcharParam(DB_COL_DEGREE_TYPE, academic.DegreeType);
            operation.AddVarcharParam(DB_COL_UNIVERSTITY_PREPARATION, academic.University_Preparation);
            operation.AddVarcharParam(DB_COL_CAREER, academic.Career);
            operation.AddVarcharParam(DB_COL_STATUS, academic.Status);
            operation.AddVarcharParam(DB_COL_CERTIFICATE, academic.Certificate);
            operation.AddDateTimeParam(DB_COL_START_DATE, academic.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, academic.EndDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, academic.StudentID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_ACADEMIC" };

            var academic = (Academic)entity;
            operation.AddIntParam(DB_COL_ACADEMIC_ID, academic.AcademicID);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var academic = new Academic
            {
                AcademicID = GetIntValue(row, DB_COL_ACADEMIC_ID),
                Institution = GetStringValue(row, DB_COL_INSTITUTION),
                DegreeType = GetStringValue(row, DB_COL_DEGREE_TYPE),
                University_Preparation = GetStringValue(row, DB_COL_UNIVERSTITY_PREPARATION),
                Career = GetStringValue(row, DB_COL_CAREER),
                Status = GetStringValue(row, DB_COL_STATUS),
                Certificate = GetStringValue(row, DB_COL_CERTIFICATE),
                StartDate = GetDateValue(row, DB_COL_START_DATE),
                EndDate = GetDateValue(row, DB_COL_END_DATE),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
            };

            return academic;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var academic = BuildObject(row);
                lstResults.Add(academic);
            }

            return lstResults;
        }

    }
}