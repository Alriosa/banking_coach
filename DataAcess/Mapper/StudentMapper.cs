using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class StudentMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_STUDENT_ID = "Student_ID";
        private const string DB_COL_BANKING_STUDENT = "Banking_Student";
        private const string DB_COL_USER_ACTIVE_STATUS = "User_Active_Status";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_FIRST_NAME = "First_Name";
        private const string DB_COL_SECOND_NAME = "Second_Name";
        private const string DB_COL_LAST_NAME = "Last_Name";
        private const string DB_COL_SECOND_LAST_NAME = "Second_Last_Name";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number";
        private const string DB_COL_BIRTHDATE = "Birthdate";
        private const string DB_COL_GENDER = "Gender";
        private const string DB_COL_PRIMARY_PHONE = "Primary_Phone";
        private const string DB_COL_SECOND_PHONE = "Secondary_Phone";
        private const string DB_COL_EMAIL = "Email";
        private const string DB_COL_LABORAL_STATUS = "Laboral_Status";

        private const string DB_COL_WORK_ADDRESS = "Work_Address";
        private const string DB_COL_LABORAL_EXPERIENCE = "Laboral_Experience";
        private const string DB_COL_STUDENT_LOGIN = "Student_User";
        private const string DB_COL_STUDENT_PASSWORD = "Student_Password";
        private const string DB_COL_PROVINCE = "Province";
        private const string DB_COL_CANTON = "Canton";
        private const string DB_COL_DISTRICT = "District";
        private const string DB_COL_USER_TYPE = "User_Type";
        

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddCharParam(DB_COL_BANKING_STUDENT,student.BankingStudent);
            operation.AddCharParam(DB_COL_USER_ACTIVE_STATUS,student.UserActiveStatus);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, student.EntryDate);
            operation.AddVarcharParam(DB_COL_FIRST_NAME,student.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, student.SecondName);
            operation.AddVarcharParam(DB_COL_LAST_NAME, student.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, student.SecondLastName);
            operation.AddCharParam(DB_COL_ID_TYPE,student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE,student.Birthdate);
            operation.AddCharParam(DB_COL_GENDER,student.Gender);
            operation.AddVarcharParam(DB_COL_PRIMARY_PHONE,student.PrimaryPhone);
            operation.AddVarcharParam(DB_COL_SECOND_PHONE,student.SecondaryPhone);
            operation.AddVarcharParam(DB_COL_EMAIL,student.Email);
            operation.AddCharParam(DB_COL_LABORAL_STATUS,student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_WORK_ADDRESS,student.Work_Address);
            operation.AddCharParam(DB_COL_LABORAL_EXPERIENCE,student.LaboralExperience);
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN,student.Student_Login);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD,student.Student_Password);
            operation.AddVarcharParam(DB_COL_PROVINCE,student.Province);
            operation.AddVarcharParam(DB_COL_CANTON,student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT,student.District);
            operation.AddCharParam(DB_COL_USER_TYPE,student.UserType);

            return operation;
        }

        //Select by Identification
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_STUDENT_BY_IDENTIFICATION" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_STUDENT_ID, student.IdentificationNumber);

            return operation;
        }

        //Select by Email
        public SqlOperation GetRetriveStatementByEmail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_STUDENT_BY_EMAIL" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_STUDENT_ID, student.IdentificationNumber);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_STUDENT" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddCharParam(DB_COL_BANKING_STUDENT, student.BankingStudent);
            operation.AddCharParam(DB_COL_USER_ACTIVE_STATUS, student.UserActiveStatus);
            operation.AddDateTimeParam(DB_COL_ENTRY_DATE, student.EntryDate);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, student.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, student.SecondName);
            operation.AddVarcharParam(DB_COL_LAST_NAME, student.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, student.SecondLastName);
            operation.AddCharParam(DB_COL_ID_TYPE, student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE, student.Birthdate);
            operation.AddCharParam(DB_COL_GENDER, student.Gender);
            operation.AddVarcharParam(DB_COL_PRIMARY_PHONE, student.PrimaryPhone);
            operation.AddVarcharParam(DB_COL_SECOND_PHONE, student.SecondaryPhone);
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);
            operation.AddCharParam(DB_COL_LABORAL_STATUS, student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_WORK_ADDRESS, student.Work_Address);
            operation.AddCharParam(DB_COL_LABORAL_EXPERIENCE, student.LaboralExperience);
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN, student.Student_Login);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD, student.Student_Password);
            operation.AddVarcharParam(DB_COL_PROVINCE, student.Province);
            operation.AddVarcharParam(DB_COL_CANTON, student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, student.District);
            operation.AddCharParam(DB_COL_USER_TYPE, student.UserType);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUSTOMER_PR" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
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
            var student = new Student
            {
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
                BankingStudent = GetCharValue(row, DB_COL_BANKING_STUDENT),
                UserActiveStatus = GetCharValue(row, DB_COL_USER_ACTIVE_STATUS),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                SecondName = GetStringValue(row, DB_COL_SECOND_NAME),
                LastName = GetStringValue(row, DB_COL_LAST_NAME),
                SecondLastName = GetStringValue(row,DB_COL_SECOND_LAST_NAME),
                IdType = GetCharValue(row,DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row,DB_COL_IDENTIFICATION_NUMBER),
                Birthdate = GetDateValue(row,DB_COL_BIRTHDATE),
                Gender = GetCharValue(row,DB_COL_GENDER),
                Canton = GetStringValue(row,DB_COL_CANTON),
                District = GetStringValue(row,DB_COL_DISTRICT),
                UserType =
                Student_Login =
                Student_Password =
                LaboralStatus =
                Work_Address =
                Email =
                LaboralExperience =
                PrimaryPhone =
                SecondaryPhone =
                Province =
            };

            return student;
        }
    }
}
