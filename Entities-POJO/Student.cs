using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Student : BaseEntity
    {
        public int StudentID { get; set; }
        public string BankingStudent { get; set; }
        public string UserActiveStatus { get; set; }
        public string CompleteName { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string NProvince { get; set; }
        public string Canton { get; set; }
        public string NCanton { get; set; }
        public string District { get; set; }
        public string NDistrict { get; set; }
        public string LaboralStatus { get; set; }
        public string Workstation {get; set;}
        public string Experience { get; set; }
        public string LaboralExperience { get; set; }
        public string EducationStatus { get; set; }
        public string InstitutionAcademicType { get; set; }
        public string InstitutionAcademicName { get; set; }
        public string AcademicPreparation { get; set; }
        public string UniversityLevel { get; set; }
        public string UniversityDegree { get; set; }
        public string ExcelLevel { get; set; }
        public string JobAvailability { get; set; }
        public string TransportAvailability { get; set; }
        public string Vehicle { get; set; }
        public string DriverLicenses { get; set; }
        public string CoursesBankingCoach { get; set; }
        public string TeachersBankingCoach { get; set; }
        public string Language { get; set; }
        public DateTime CourseDateFinish { get; set; }
        public string CourseDay { get; set; }
        public string CourseSchedule { get; set; }
        public string CoursePlace { get; set; }
        public string BankingCoachCertificate { get; set; }
        public string Curriculum { get; set; }
        public string AgreeJobExchange { get; set; }
        public string UserType { get; set; }
        public string StudentLogin { get; set; }
        public string StudentPassword { get; set; }
        public string UserLogin { get; set; }
        public Student()
        {
            
        }

        public Student(int studentID, string bankingStudent, string userActiveStatus, string completeName, string idType, string identificationNumber, DateTime birthdate, int age, 
            string email, string phoneNumber, 
            string province, string nProvince, string canton,
            string nCanton, string district, string nDistrict,
            string laboralStatus, string workstation, string experience, 
            string laboralExperience, string educationStatus, 
            string institutionAcademicType, string institutionAcademicName, string academicPreparation, string universityLevel, 
            string universityDegree, string excelLevel, string jobAvailability, string transportAvailability, string vehicle, string driverLicenses, string coursesBankingCoach, string teachersBankingCoach, string language, DateTime courseDateFinish, string courseDay, string courseSchedule, string coursePlace, string bankingCoachCertificate, string curriculum, string agreeJobExchange, string userType, string studentLogin, 
            string studentPassword, string userLogin)
        {
            StudentID = studentID;
            BankingStudent = bankingStudent;
            UserActiveStatus = userActiveStatus;
            CompleteName = completeName;
            IdType = idType;
            IdentificationNumber = identificationNumber;
            Birthdate = birthdate;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Province = province;
            NProvince = nProvince;
            Canton = canton;
            NCanton = nCanton;
            District = district;
            NDistrict = nDistrict;
            LaboralStatus = laboralStatus;
            Workstation = workstation;
            Experience = experience;
            LaboralExperience = laboralExperience;
            EducationStatus = educationStatus;
            InstitutionAcademicType = institutionAcademicType;
            InstitutionAcademicName = institutionAcademicName;
            AcademicPreparation = academicPreparation;
            UniversityLevel = universityLevel;
            UniversityDegree = universityDegree;
            ExcelLevel = excelLevel;
            JobAvailability = jobAvailability;
            TransportAvailability = transportAvailability;
            Vehicle = vehicle;
            DriverLicenses = driverLicenses;
            CoursesBankingCoach = coursesBankingCoach;
            TeachersBankingCoach = teachersBankingCoach;
            Language = language;
            CourseDateFinish = courseDateFinish;
            CourseDay = courseDay;
            CourseSchedule = courseSchedule;
            CoursePlace = coursePlace;
            BankingCoachCertificate = bankingCoachCertificate;
            Curriculum = curriculum;
            AgreeJobExchange = agreeJobExchange;
            UserType = userType;
            StudentLogin = studentLogin;
            StudentPassword = studentPassword;
            UserLogin = userLogin;
        }
    }
    
}
