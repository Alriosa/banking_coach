using DataAccess.Dao;
using DataAccess.Mapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class ExtraCourseMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_COURSE_ID = "Course_ID";
        private const string DB_COL_INSTITUTION = "Institution";
        private const string DB_COL_COURSE_NAME = "Course_Name";
        private const string DB_COL_CERTIFICATE_NAME = "Certificate_Name";
        private const string DB_COL_CERTIFICATE_FILE = "Certificate_File";
        private const string DB_COL_STATUS = "Status";
        private const string DB_COL_START_DATE = "Start_Date";
        private const string DB_COL_END_DATE = "End_Date";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_STUDENT_ID = "Student_ID";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_COURSE_STUDENT" };

            var extraCourse = (ExtraCourse)entity;

            operation.AddVarcharParam(DB_COL_INSTITUTION, extraCourse.Institution);
            operation.AddVarcharParam(DB_COL_COURSE_NAME, extraCourse.CourseName);
            operation.AddVarcharParam(DB_COL_CERTIFICATE_NAME, extraCourse.Certificate_Name);
            operation.AddVarcharParam(DB_COL_CERTIFICATE_FILE, extraCourse.Certificate_File);
            operation.AddVarcharParam(DB_COL_STATUS, extraCourse.Status);
            operation.AddDateTimeParam(DB_COL_START_DATE, extraCourse.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, extraCourse.EndDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, extraCourse.StudentID);
            return operation;
        }

       

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_COURSE" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_COURSE_BY_ID" };

            var extraCourse = (ExtraCourse)entity;
            operation.AddIntParam(DB_COL_COURSE_ID, extraCourse.CourseID);

            return operation;
        }
        public SqlOperation GetRetriveStatementByStudent(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_COURSE_BY_STUDENT" };

            var extraCourse = (ExtraCourse)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, extraCourse.StudentID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_COURSE_STUDENT" };

            var extraCourse = (ExtraCourse)entity;

            operation.AddIntParam(DB_COL_COURSE_ID, extraCourse.CourseID);
            operation.AddVarcharParam(DB_COL_INSTITUTION, extraCourse.Institution);
            operation.AddVarcharParam(DB_COL_COURSE_NAME, extraCourse.CourseName);
            operation.AddVarcharParam(DB_COL_CERTIFICATE_NAME, extraCourse.Certificate_Name);
            operation.AddVarcharParam(DB_COL_CERTIFICATE_FILE, extraCourse.Certificate_File);
            operation.AddVarcharParam(DB_COL_STATUS, extraCourse.Status);
            operation.AddDateTimeParam(DB_COL_START_DATE, extraCourse.StartDate);
            operation.AddDateTimeParam(DB_COL_END_DATE, extraCourse.EndDate);
            operation.AddIntParam(DB_COL_STUDENT_ID, extraCourse.StudentID);
            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_COURSE" };

            var extraCourse = (ExtraCourse)entity;
            operation.AddIntParam(DB_COL_COURSE_ID, extraCourse.CourseID);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var extraCourse = new ExtraCourse
            {
                CourseID = GetIntValue(row, DB_COL_COURSE_ID),
                Institution = GetStringValue(row, DB_COL_INSTITUTION),
                CourseName = GetStringValue(row, DB_COL_COURSE_NAME),
                Status = GetStringValue(row, DB_COL_STATUS),
                Certificate_Name = GetStringValue(row, DB_COL_CERTIFICATE_NAME),
                Certificate_File = GetStringValue(row, DB_COL_CERTIFICATE_FILE),
                StartDate = GetDateValue(row, DB_COL_START_DATE),
                EndDate = GetDateValue(row, DB_COL_END_DATE),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
            };

            return extraCourse;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var extraCourse = BuildObject(row);
                lstResults.Add(extraCourse);
            }

            return lstResults;
        }

    }
}
