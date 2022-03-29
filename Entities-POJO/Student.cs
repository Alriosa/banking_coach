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
        public char BankingStudent { get; set; }
        public char UserActiveStatus { get; set; }
        public DateTime EntryDate { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public char IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public char UserType { get; set; }
        public string Student_Login { get; set; }
        public string Student_Password { get; set; }
        public char LaboralStatus { get; set; }
        public string Work_Address { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public char LaboralExperience { get; set; }

        public Student()
        {
            
        }
        public Student(int studentId, char bankingStudent, char userActiveStatus, DateTime entryDate, string firstName, string secondName, string lastName, string secondLastName, char idType, string identificationNumber, DateTime birthdate, char gender, string canton, string district, char userType, string studentLogin, string studentPassword, char laboralStatus, string workAddress, string email, char laboralExperience, string primaryPhone, string secondaryPhone, string province)
        {
            StudentID = studentId;
            BankingStudent = bankingStudent;
            UserActiveStatus = userActiveStatus;
            EntryDate = entryDate;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            IdType = idType;
            IdentificationNumber = identificationNumber;
            Birthdate = birthdate;
            Gender = gender;
            Canton = canton;
            District = district;
            UserType = userType;
            Student_Login = studentLogin;
            Student_Password = studentPassword;
            LaboralStatus = laboralStatus;
            Work_Address = workAddress;
            Email = email;
            LaboralExperience = laboralExperience;
            PrimaryPhone = primaryPhone;
            SecondaryPhone = secondaryPhone;
            Province = province;
        }

       
    }
    
}
