using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class StudentMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_STUDENT_ID = "Student_ID";
        private const string DB_COL_BANKING_STUDENT = "Banking_Student";
        private const string DB_COL_USER_ACTIVE_STATUS = "User_Active_Status";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_COMPLETE_NAME = "Complete_Name";
        private const string DB_COL_ID_TYPE = "Id_Type";
        private const string DB_COL_IDENTIFICATION_NUMBER = "Identification_Number";
        private const string DB_COL_BIRTHDATE = "Birthdate";
        private const string DB_COL_AGE = "Age";
        private const string DB_COL_EMAIL = "Email";
        private const string DB_COL_PHONE_NUMBER = "Phone_Number";
        private const string DB_COL_PROVINCE = "Province";
        private const string DB_COL_CANTON = "Canton";
        private const string DB_COL_DISTRICT = "District";
        private const string DB_COL_N_PROVINCE = "N_Province";
        private const string DB_COL_N_CANTON = "N_Canton";
        private const string DB_COL_N_DISTRICT = "N_District";
        private const string DB_COL_LABORAL_STATUS = "Laboral_Status";
        private const string DB_COL_WORKSTATION = "WorkStation";
        private const string DB_COL_EXPERIENCE = "Experience";
        private const string DB_COL_LABORAL_EXPERIENCE = "Laboral_Experience";
        private const string DB_COL_EDUCATION_STATUS = "Education_Status";
        private const string DB_COL_INSTITUTION_ACADEMIC_TYPE = "Institution_Academic_Type";
        private const string DB_COL_INSTITUTION_ACADEMIC_NAME = "Institution_Academic_Name";
        private const string DB_COL_ACADEMIC_PREPARATION = "Academic_Preparation";
        private const string DB_COL_UNIVERSITY_LEVEL = "University_Level";
        private const string DB_COL_UNIVERSITY_DEGREE = "University_Degree";
        private const string DB_COL_EXCEL_LEVEL = "Excel_Level";
        private const string DB_COL_JOB_AVAILABILTY = "Job_Availability";
        private const string DB_COL_TRANSPORT_AVAILABILITY = "Transport_Availability";
        private const string DB_COL_VEHICLE = "Vehicle";
        private const string DB_COL_DRIVER_LICENSES = "Driver_Licenses";
        private const string DB_COL_COURSES_BANKING_COACH = "Courses_Banking_Coach";
        private const string DB_COL_TEACHERS_BANKING_COACH = "Teachers_Banking_Coach";
        private const string DB_COL_LANGUAGE = "Language";
        private const string DB_COL_COURSE_DATE_FINISH = "Course_Date_Finish";
        private const string DB_COL_COURSE_DAY = "Course_Day";
        private const string DB_COL_COURSE_SCHEDULE = "Course_Schedule";
        private const string DB_COL_COURSE_PLACE = "Course_Place";
        private const string DB_COL_BANKING_COACH_CERTIFICATE = "Banking_Coach_Certificate";
        private const string DB_COL_CURRICULUM = "Curriculum";
        private const string DB_COL_AGREE_JOB_EXCHANGE = "Agree_Job_Exchange";
        private const string DB_COL_STUDENT_LOGIN = "Student_User";
        private const string DB_COL_STUDENT_PASSWORD = "Student_Password";
        private const string DB_COL_USER_TYPE = "User_Type";
        private const string DB_COL_USER_EXIST = "User_Login";




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_BANKING_STUDENT,student.BankingStudent);
            operation.AddVarcharParam(DB_COL_USER_ACTIVE_STATUS,student.UserActiveStatus);
            operation.AddVarcharParam(DB_COL_COMPLETE_NAME, student.CompleteName);
            operation.AddVarcharParam(DB_COL_ID_TYPE,student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE,student.Birthdate);
            operation.AddIntParam(DB_COL_AGE,student.Age);
            operation.AddVarcharParam(DB_COL_PHONE_NUMBER,student.PhoneNumber);
            operation.AddVarcharParam(DB_COL_EMAIL,student.Email);
            operation.AddVarcharParam(DB_COL_PROVINCE, student.Province);
            operation.AddVarcharParam(DB_COL_CANTON, student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, student.District);
            operation.AddVarcharParam(DB_COL_LABORAL_STATUS,student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_WORKSTATION,student.Workstation);
            operation.AddVarcharParam(DB_COL_EXPERIENCE,student.Experience);
            operation.AddVarcharParam(DB_COL_LABORAL_EXPERIENCE, student.LaboralExperience);
            operation.AddVarcharParam(DB_COL_EDUCATION_STATUS,student.EducationStatus);
            operation.AddVarcharParam(DB_COL_INSTITUTION_ACADEMIC_TYPE,student.InstitutionAcademicType);
            operation.AddVarcharParam(DB_COL_INSTITUTION_ACADEMIC_NAME,student.InstitutionAcademicName);
            operation.AddVarcharParam(DB_COL_UNIVERSITY_LEVEL,student.UniversityLevel);
            operation.AddVarcharParam(DB_COL_UNIVERSITY_DEGREE,student.UniversityDegree);
            operation.AddVarcharParam(DB_COL_EXCEL_LEVEL,student.ExcelLevel);
            operation.AddVarcharParam(DB_COL_JOB_AVAILABILTY,student.JobAvailability);
            operation.AddVarcharParam(DB_COL_TRANSPORT_AVAILABILITY,student.TransportAvailability);
            operation.AddVarcharParam(DB_COL_VEHICLE,student.Vehicle);
            operation.AddVarcharParam(DB_COL_DRIVER_LICENSES,student.DriverLicenses);
            operation.AddVarcharParam(DB_COL_COURSES_BANKING_COACH,student.CoursesBankingCoach);
            operation.AddVarcharParam(DB_COL_TEACHERS_BANKING_COACH,student.TeachersBankingCoach);
            operation.AddVarcharParam(DB_COL_LANGUAGE,student.Language);
            operation.AddDateTimeParam(DB_COL_COURSE_DATE_FINISH,student.CourseDateFinish);
            operation.AddVarcharParam(DB_COL_COURSE_DAY,student.CourseDay);
            operation.AddVarcharParam(DB_COL_COURSE_SCHEDULE,student.CourseSchedule);
            operation.AddVarcharParam(DB_COL_COURSE_PLACE,student.CoursePlace);
            operation.AddVarcharParam(DB_COL_BANKING_COACH_CERTIFICATE,student.BankingCoachCertificate);
            operation.AddVarcharParam(DB_COL_CURRICULUM,student.Curriculum);
            operation.AddVarcharParam(DB_COL_AGREE_JOB_EXCHANGE,student.AgreeJobExchange);
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN,student.StudentLogin);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD,student.StudentPassword);
  

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
            operation.AddVarcharParam(DB_COL_STUDENT_ID, student.IdentificationNumber);

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

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddVarcharParam(DB_COL_BANKING_STUDENT, student.BankingStudent);
            operation.AddVarcharParam(DB_COL_USER_ACTIVE_STATUS, student.UserActiveStatus);
            operation.AddVarcharParam(DB_COL_COMPLETE_NAME, student.CompleteName);
            operation.AddVarcharParam(DB_COL_ID_TYPE, student.IdType);
            operation.AddVarcharParam(DB_COL_IDENTIFICATION_NUMBER, student.IdentificationNumber);
            operation.AddDateTimeParam(DB_COL_BIRTHDATE, student.Birthdate);
            operation.AddIntParam(DB_COL_AGE, student.Age);
            operation.AddVarcharParam(DB_COL_PHONE_NUMBER, student.PhoneNumber);
            operation.AddVarcharParam(DB_COL_EMAIL, student.Email);
            operation.AddVarcharParam(DB_COL_PROVINCE, student.Province);
            operation.AddVarcharParam(DB_COL_CANTON, student.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, student.District);
            operation.AddVarcharParam(DB_COL_LABORAL_STATUS, student.LaboralStatus);
            operation.AddVarcharParam(DB_COL_WORKSTATION, student.Workstation);
            operation.AddVarcharParam(DB_COL_EXPERIENCE, student.Experience);
            operation.AddVarcharParam(DB_COL_LABORAL_EXPERIENCE, student.LaboralExperience);
            operation.AddVarcharParam(DB_COL_EDUCATION_STATUS, student.EducationStatus);
            operation.AddVarcharParam(DB_COL_INSTITUTION_ACADEMIC_TYPE, student.InstitutionAcademicType);
            operation.AddVarcharParam(DB_COL_INSTITUTION_ACADEMIC_NAME, student.InstitutionAcademicName);
            operation.AddVarcharParam(DB_COL_UNIVERSITY_LEVEL, student.UniversityLevel);
            operation.AddVarcharParam(DB_COL_UNIVERSITY_DEGREE, student.UniversityDegree);
            operation.AddVarcharParam(DB_COL_EXCEL_LEVEL, student.ExcelLevel);
            operation.AddVarcharParam(DB_COL_JOB_AVAILABILTY, student.JobAvailability);
            operation.AddVarcharParam(DB_COL_TRANSPORT_AVAILABILITY, student.TransportAvailability);
            operation.AddVarcharParam(DB_COL_VEHICLE, student.Vehicle);
            operation.AddVarcharParam(DB_COL_DRIVER_LICENSES, student.DriverLicenses);
            operation.AddVarcharParam(DB_COL_COURSES_BANKING_COACH, student.CoursesBankingCoach);
            operation.AddVarcharParam(DB_COL_TEACHERS_BANKING_COACH, student.TeachersBankingCoach);
            operation.AddVarcharParam(DB_COL_LANGUAGE, student.Language);
            operation.AddDateTimeParam(DB_COL_COURSE_DATE_FINISH, student.CourseDateFinish);
            operation.AddVarcharParam(DB_COL_COURSE_DAY, student.CourseDay);
            operation.AddVarcharParam(DB_COL_COURSE_SCHEDULE, student.CourseSchedule);
            operation.AddVarcharParam(DB_COL_COURSE_PLACE, student.CoursePlace);
            operation.AddVarcharParam(DB_COL_BANKING_COACH_CERTIFICATE, student.BankingCoachCertificate);
            operation.AddVarcharParam(DB_COL_CURRICULUM, student.Curriculum);
            operation.AddVarcharParam(DB_COL_AGREE_JOB_EXCHANGE, student.AgreeJobExchange);
            operation.AddVarcharParam(DB_COL_STUDENT_LOGIN, student.StudentLogin);
            operation.AddVarcharParam(DB_COL_STUDENT_PASSWORD, student.StudentPassword);



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


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_STUDENT" };

            var student = (Student)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, student.StudentID);
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
                BankingStudent = GetStringValue(row, DB_COL_BANKING_STUDENT),
                UserActiveStatus = GetStringValue(row, DB_COL_USER_ACTIVE_STATUS),
                CompleteName = GetStringValue(row,DB_COL_COMPLETE_NAME),
                IdType = GetStringValue(row,DB_COL_ID_TYPE),
                IdentificationNumber = GetStringValue(row,DB_COL_IDENTIFICATION_NUMBER),
                Birthdate = GetDateValue(row,DB_COL_BIRTHDATE),
                Age = GetIntValue(row,DB_COL_AGE),
                Email = GetStringValue(row,DB_COL_EMAIL),
                PhoneNumber = GetStringValue(row, DB_COL_PHONE_NUMBER),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                District = GetStringValue(row, DB_COL_DISTRICT),
                NProvince = GetStringValue(row, DB_COL_N_PROVINCE),
                NCanton = GetStringValue(row, DB_COL_N_CANTON),
                NDistrict = GetStringValue(row, DB_COL_N_DISTRICT),
                LaboralStatus = GetStringValue(row,DB_COL_LABORAL_STATUS),
                Workstation = GetStringValue(row, DB_COL_WORKSTATION),
                Experience = GetStringValue(row, DB_COL_EXPERIENCE),
                LaboralExperience = GetStringValue(row, DB_COL_LABORAL_EXPERIENCE),
                EducationStatus = GetStringValue(row, DB_COL_EDUCATION_STATUS),
                InstitutionAcademicType = GetStringValue(row, DB_COL_INSTITUTION_ACADEMIC_TYPE),
                InstitutionAcademicName = GetStringValue(row, DB_COL_INSTITUTION_ACADEMIC_NAME),
                AcademicPreparation = GetStringValue(row, DB_COL_ACADEMIC_PREPARATION),
                UniversityLevel = GetStringValue(row, DB_COL_UNIVERSITY_LEVEL),
                UniversityDegree = GetStringValue(row, DB_COL_UNIVERSITY_DEGREE),
                ExcelLevel = GetStringValue(row, DB_COL_EXCEL_LEVEL),
                JobAvailability = GetStringValue(row, DB_COL_JOB_AVAILABILTY),
                TransportAvailability = GetStringValue(row, DB_COL_TRANSPORT_AVAILABILITY),
                Vehicle = GetStringValue(row, DB_COL_VEHICLE),
                DriverLicenses = GetStringValue(row, DB_COL_DRIVER_LICENSES),
                CoursesBankingCoach = GetStringValue(row, DB_COL_COURSES_BANKING_COACH),
                TeachersBankingCoach = GetStringValue(row, DB_COL_TEACHERS_BANKING_COACH),
                Language = GetStringValue(row, DB_COL_LANGUAGE),
                CourseDateFinish = GetDateValue(row, DB_COL_COURSE_DATE_FINISH),
                CourseDay = GetStringValue(row, DB_COL_COURSE_DAY),
                CourseSchedule = GetStringValue(row, DB_COL_COURSE_SCHEDULE),
                CoursePlace = GetStringValue(row, DB_COL_COURSE_PLACE),
                BankingCoachCertificate = GetStringValue(row, DB_COL_BANKING_COACH_CERTIFICATE),
                Curriculum = GetStringValue(row, DB_COL_CURRICULUM),
                AgreeJobExchange = GetStringValue(row, DB_COL_AGREE_JOB_EXCHANGE),
                UserType = GetStringValue(row, DB_COL_USER_TYPE),
                StudentLogin = GetStringValue(row, DB_COL_STUDENT_LOGIN),
                StudentPassword = GetStringValue(row, DB_COL_STUDENT_PASSWORD),
                UserLogin = GetStringValue(row, DB_COL_USER_EXIST),
            };

            return student;
        }
    }
}
