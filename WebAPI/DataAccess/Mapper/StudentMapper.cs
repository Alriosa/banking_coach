using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Models;

namespace DataAccess.Mapper
{
    public class StudentMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_STUDENT_ID = "Student_ID";
        private const string DB_COL_USER_BANKING_STUDENT = "Banking_Student";
        private const string DB_COL_USER_ACTIVE_STATUS = "User_Active_Status";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_FIRST_NAME = "First_Name";
        private const string DB_COL_FIRST_LAST_NAME = "First_Last_Name";
        private const string DB_COL_SECOND_LAST_NAME = "Second_Last_Name";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number";
        private const string DB_COL_COUNTRY = "Country";
        private const string DB_COL_BIRTHDATE = "Birthdate";
        private const string DB_COL_AGE = "Age";
        private const string DB_COL_SEX = "Sex";
        private const string DB_COL_EMAIL = "Email";
        private const string DB_COL_FIRST_PHONE_NUMBER = "Primary_Phone_Number";
        private const string DB_COL_SECOND_PHONE_NUMBER = "Second_Phone_Number";
        private const string DB_COL_PROVINCE = "Province";
        private const string DB_COL_CANTON = "Canton";
        private const string DB_COL_DISTRICT = "District";
        private const string DB_COL_N_PROVINCE = "N_Province";
        private const string DB_COL_N_CANTON = "N_Canton";
        private const string DB_COL_N_DISTRICT = "N_District";
        private const string DB_COL_LABORAL_STATUS = "Laboral_Status";
        private const string DB_COL_JOB_AVAILABILTY = "Job_Availability";
        private const string DB_COL_TRANSPORT_AVAILABILITY = "Transport_Availability";
        private const string DB_COL_VEHICLE = "Vehicle";
        private const string DB_COL_TYPE_VEHICLE = "Type_Vehicle";
        private const string DB_COL_DRIVER_LICENSES = "Driver_Licenses";
        private const string DB_COL_CURRICULUM = "Curriculum";
        private const string DB_COL_AGREE_JOB_EXCHANGE = "Agree_Job_Exchange";
        private const string DB_COL_STUDENT_LOGIN = "Student_User";
        private const string DB_COL_STUDENT_PASSWORD = "Student_Password";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_EXIST = "User_Login";
        private const string DB_COL_STATUS_RECRUITMENT = "Status_Recruitment";
        private const string DB_COL_ENTITY_ID = "Entity_Id";
        private const string DB_COL_ENTITY_NAME = "Entity_Name";
        private const string DB_COL_STATUS_ECONOMIC_TEST = "Status_Economic_Test";
        private const string DB_COL_STATUS_PSYCHOMETRIC_TEST = "Status_Psychometric_Test";
        private const string DB_COL_STATUS_INTERVIEW = "Status_Interview";
        private const string DB_COL_STATUS_HIRED = "Status_Hired";




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_USER_BANKING_STUDENT, student.BankingStudent);
            operation.AddVarcharParam(DB_COL_USER_ACTIVE_STATUS, student.UserActiveStatus);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, student.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, student.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, student.SecondLastName);
            operation.AddVarcharParam(DB_COL_ID_TYPE, student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddVarcharParam(DB_COL_COUNTRY, student.Country);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE, student.Birthdate);
            operation.AddIntParam(DB_COL_AGE, student.Age);
            operation.AddVarcharParam(DB_COL_SEX, student.Sex);
            operation.AddVarcharParam(DB_COL_FIRST_PHONE_NUMBER, student.FirstPhoneNumber);
            operation.AddVarcharParam(DB_COL_SECOND_PHONE_NUMBER, student.SecondPhoneNumber);
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);
            operation.AddVarcharParam(DB_COL_PROVINCE, student.Province);
            operation.AddVarcharParam(DB_COL_CANTON, student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, student.District);
            operation.AddVarcharParam(DB_COL_LABORAL_STATUS, student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_JOB_AVAILABILTY, student.JobAvailability);
            operation.AddVarcharParam(DB_COL_TRANSPORT_AVAILABILITY, student.TransportAvailability);
            operation.AddVarcharParam(DB_COL_VEHICLE, student.Vehicle);
            operation.AddVarcharParam(DB_COL_TYPE_VEHICLE, student.Type_Vehicle);
            operation.AddVarcharParam(DB_COL_DRIVER_LICENSES, student.DriverLicenses);
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN, student.StudentLogin);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD, student.StudentPassword);


            return operation;
        }

        //Select by Identification
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_STUDENT_BY_ID" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);

            return operation;
        }

        //Select by Email
        public SqlOperation GetRetriveStatementByEmail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_STUDENT_BY_EMAIL" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);

            return operation;
        }

        public SqlOperation GetRetriveUserLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_STUDENT_BY_USER" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN, student.StudentLogin);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_STUDENT" };
            return operation;
        }
        public SqlOperation GetRetriveAllInRecruitmentStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_STUDENT_IN_RECRUITMENT" };
            return operation;
        }
        public SqlOperation GetRetriveAllInRecruitmentByEntityStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_STUDENT_IN_RECRUITMENT_BY_ENTITY" };
            var student = (Student)entity;
            operation.AddIntParam(DB_COL_ENTITY_ID, student.EntityId);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddVarcharParam(DB_COL_USER_BANKING_STUDENT, student.BankingStudent);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, student.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, student.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, student.SecondLastName);
            operation.AddVarcharParam(DB_COL_ID_TYPE, student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddVarcharParam(DB_COL_COUNTRY, student.Country);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE, student.Birthdate);
            operation.AddIntParam(DB_COL_AGE, student.Age);
            operation.AddVarcharParam(DB_COL_SEX, student.Sex);
            operation.AddVarcharParam(DB_COL_FIRST_PHONE_NUMBER, student.FirstPhoneNumber);
            operation.AddVarcharParam(DB_COL_SECOND_PHONE_NUMBER, student.SecondPhoneNumber);
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);
            operation.AddVarcharParam(DB_COL_PROVINCE, student.Province);
            operation.AddVarcharParam(DB_COL_CANTON, student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, student.District);
            operation.AddVarcharParam(DB_COL_LABORAL_STATUS, student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_DRIVER_LICENSES, student.DriverLicenses);
            operation.AddVarcharParam(DB_COL_JOB_AVAILABILTY, student.JobAvailability);
            operation.AddVarcharParam(DB_COL_TRANSPORT_AVAILABILITY, student.TransportAvailability);
            operation.AddVarcharParam(DB_COL_VEHICLE, student.Vehicle);
            operation.AddVarcharParam(DB_COL_TYPE_VEHICLE, student.Type_Vehicle);
            return operation;
        }

        public SqlOperation GetUpdatePasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_PASSWORD_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN, student.StudentLogin);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD, student.StudentPassword);

            return operation;
        }

        public SqlOperation GetRecoverPasswordStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RECOVER_PASSWORD_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD, student.StudentPassword);

            return operation;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CHANGE_STATUS_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddVarcharParam(DB_COL_USER_ACTIVE_STATUS, student.UserActiveStatus);
            return operation;
        }
        public SqlOperation GetChangeStatusStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CHANGE_STATUS_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddVarcharParam(DB_COL_USER_ACTIVE_STATUS, student.UserActiveStatus);
            return operation;
        }


        public SqlOperation GetValidateUserNameExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_USERNAME" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_USER_EXIST, student.StudentLogin);

            return operation;
        }

        public SqlOperation GetValidateEmailExistenceStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_VERIFY_EMAIL" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);

            return operation;
        }

        public SqlOperation GetRecruitStudentStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RECRUIT_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddIntParam(DB_COL_ENTITY_ID, student.EntityId);
            return operation;
        }
        public SqlOperation GetFinishRecruitStudentStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_FINISH_RECRUIT_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            return operation;
        }

        public SqlOperation GetUpdateProcessTestEconomicStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_STUDENT_PROCESS_TEST_ECONOMIC" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddIntParam(DB_COL_STATUS_ECONOMIC_TEST, student.StatusEconomicTest);
            return operation;
        }

        public SqlOperation GetUpdateProcessTestPsychometricStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_STUDENT_PROCESS_TEST_PSYCHOMETRIC" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddIntParam(DB_COL_STATUS_PSYCHOMETRIC_TEST, student.StatusPsychometricTest);
            return operation;
        }

        public SqlOperation GetUpdateProcessInterviewStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_STUDENT_PROCESS_INTERVIEW" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddIntParam(DB_COL_STATUS_INTERVIEW, student.StatusInterview);
            return operation;
        }
        public SqlOperation GetUpdateProcessHiringStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_STUDENT_PROCESS_HIRING" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
            operation.AddIntParam(DB_COL_STATUS_HIRED, student.StatusHired);
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


        public List<BaseEntity> BuildObjectsInRecruitment(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var student = BuildObjectInRecruitment(row);
                lstResults.Add(student);
            }

            return lstResults;
        }



        public BaseEntity BuildObjectBasic(Dictionary<string, object> row)
        {
            var student = new Student
            {
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
                BankingStudent = GetStringValue(row, DB_COL_USER_BANKING_STUDENT),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_ACTIVE_STATUS),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                FirstLastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                Email = GetStringValue(row, DB_COL_EMAIL),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                StudentLogin = GetStringValue(row, DB_COL_STUDENT_LOGIN),
            };

            return student;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var student = new Student
            {
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
                BankingStudent = GetStringValue(row, DB_COL_USER_BANKING_STUDENT),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_ACTIVE_STATUS),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                FirstLastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                IdType = GetStringValue(row,DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                Country = GetStringValue(row, DB_COL_COUNTRY),
                Birthdate = GetDateValue(row,DB_COL_BIRTHDATE),
                Age = GetIntValue(row,DB_COL_AGE),
                Sex = GetStringValue(row, DB_COL_SEX),
                Email = GetStringValue(row,DB_COL_EMAIL),
                FirstPhoneNumber = GetStringValue(row, DB_COL_FIRST_PHONE_NUMBER),
                SecondPhoneNumber = GetStringValue(row, DB_COL_SECOND_PHONE_NUMBER),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                District = GetStringValue(row, DB_COL_DISTRICT),
                NProvince = GetStringValue(row, DB_COL_N_PROVINCE),
                NCanton = GetStringValue(row, DB_COL_N_CANTON),
                NDistrict = GetStringValue(row, DB_COL_N_DISTRICT),
                LaboralStatus = GetStringValue(row,DB_COL_LABORAL_STATUS),
                JobAvailability = GetStringValue(row, DB_COL_JOB_AVAILABILTY),
                TransportAvailability = GetStringValue(row, DB_COL_TRANSPORT_AVAILABILITY),
                Vehicle = GetStringValue(row, DB_COL_VEHICLE),
                Type_Vehicle = GetStringValue(row, DB_COL_TYPE_VEHICLE),
                DriverLicenses = GetStringValue(row, DB_COL_DRIVER_LICENSES),
                Curriculum = GetStringValue(row, DB_COL_CURRICULUM),
                AgreeJobExchange = GetStringValue(row, DB_COL_AGREE_JOB_EXCHANGE),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                StudentLogin = GetStringValue(row, DB_COL_STUDENT_LOGIN),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StatusRecruitment = GetIntValue(row, DB_COL_STATUS_RECRUITMENT),
                EntityId = GetIntValue(row, DB_COL_ENTITY_ID),
                EntityName = GetStringValue(row, DB_COL_ENTITY_NAME),
                StatusEconomicTest = GetIntValue(row, DB_COL_STATUS_ECONOMIC_TEST),
                StatusPsychometricTest = GetIntValue(row, DB_COL_STATUS_PSYCHOMETRIC_TEST),
                StatusInterview = GetIntValue(row, DB_COL_STATUS_INTERVIEW),
                StatusHired = GetIntValue(row, DB_COL_STATUS_HIRED),
                //UserLogin = GetStringValue(row, DB_COL_USER_EXIST),
            };

            return student;
        }


        public BaseEntity BuildObjectInRecruitment(Dictionary<string, object> row)
        {
            var student = new Student
            {
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
                BankingStudent = GetStringValue(row, DB_COL_USER_BANKING_STUDENT),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_ACTIVE_STATUS),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                FirstLastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                IdType = GetStringValue(row, DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row, DB_COL_IDENTIFICATION_NUMBER),
                Country = GetStringValue(row, DB_COL_COUNTRY),
                Email = GetStringValue(row, DB_COL_EMAIL),
                SecondPhoneNumber = GetStringValue(row, DB_COL_SECOND_PHONE_NUMBER),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                District = GetStringValue(row, DB_COL_DISTRICT),
                NProvince = GetStringValue(row, DB_COL_N_PROVINCE),
                NCanton = GetStringValue(row, DB_COL_N_CANTON),
                NDistrict = GetStringValue(row, DB_COL_N_DISTRICT),
                DriverLicenses = GetStringValue(row, DB_COL_DRIVER_LICENSES),
                StatusRecruitment = GetIntValue(row, DB_COL_STATUS_RECRUITMENT),
                EntityId = GetIntValue(row, DB_COL_ENTITY_ID),
                EntityName = GetStringValue(row, DB_COL_ENTITY_NAME),
                StatusEconomicTest = GetIntValue(row, DB_COL_STATUS_ECONOMIC_TEST),
                StatusPsychometricTest = GetIntValue(row, DB_COL_STATUS_PSYCHOMETRIC_TEST),
                StatusInterview = GetIntValue(row, DB_COL_STATUS_INTERVIEW),
                StatusHired = GetIntValue(row, DB_COL_STATUS_HIRED),
            };

            return student;
        }

    }
}
