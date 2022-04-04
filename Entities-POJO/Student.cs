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
        public DateTime EntryDate { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string IdType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string UserType { get; set; }
        public string Student_Login { get; set; }
        public string Student_Password { get; set; }
        public string LaboralStatus { get; set; }
        public string Work_Address { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string LaboralExperience { get; set; }

        public Student()
        {
            
        }
        public Student(int studentId, string bankingStudent, string userActiveStatus, DateTime entryDate, string firstName, string secondName, string lastName, string secondLastName, string idType, string identificationNumber, DateTime birthdate, string gender, string canton, string district, string userType, string studentLogin, string studentPassword, string laboralStatus, string workAddress, string email, string laboralExperience, string primaryPhone, string secondaryPhone, string province)
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
