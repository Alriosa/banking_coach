﻿using System;
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
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string FirstPhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string Province { get; set; }
        public string NProvince { get; set; }
        public string Canton { get; set; }
        public string NCanton { get; set; }
        public string District { get; set; }
        public string NDistrict { get; set; }
        public string LaboralStatus { get; set; }
        public string EducationStatus { get; set; }
        public string Curriculum { get; set; }
        public string AgreeJobExchange { get; set; }
        public string UserType { get; set; }
        public string StudentLogin { get; set; }
        public string StudentPassword { get; set; }
        public string UserLogin { get; set; }
        public string JobAvailability { get; set; }
        public string TransportAvailability { get; set; }
        public string Vehicle { get; set; }
        public string DriverLicenses { get; set; }
        public Student()
        {
            
        }

        public Student(int studentID, string bankingStudent, string userActiveStatus, string firstName, string firstLastName, string secondLastName, string idType, string identificationNumber, DateTime birthdate, int age, string email, string firstPhoneNumber, string secondPhoneNumber, string province, string nProvince, string canton, string nCanton, string district, string nDistrict, string laboralStatus, string educationStatus, string curriculum, string agreeJobExchange, string userType, string studentLogin, string studentPassword, string userLogin, string driverLicenses)
        {
            StudentID = studentID;
            BankingStudent = bankingStudent;
            UserActiveStatus = userActiveStatus;
            FirstName = firstName;
            FirstLastName = firstLastName;
            SecondLastName = secondLastName;
            IdType = idType;
            IdentificationNumber = identificationNumber;
            Birthdate = birthdate;
            Age = age;
            Email = email;
            FirstPhoneNumber = firstPhoneNumber;
            SecondPhoneNumber = secondPhoneNumber;
            Province = province;
            NProvince = nProvince;
            Canton = canton;
            NCanton = nCanton;
            District = district;
            NDistrict = nDistrict;
            LaboralStatus = laboralStatus;
            EducationStatus = educationStatus;
            Curriculum = curriculum;
            AgreeJobExchange = agreeJobExchange;
            UserType = userType;
            StudentLogin = studentLogin;
            StudentPassword = studentPassword;
            UserLogin = userLogin;
            DriverLicenses = driverLicenses;
        }
    }
    
}
