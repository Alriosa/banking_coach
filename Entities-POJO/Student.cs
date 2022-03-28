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
        public bool BankingStudent { get; set; }
        public bool UserActiveStatus { get; set; }
        public DateTime EntryDate { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public int IdType { get; set; }
        public int IdentificationNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Gender { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public int UserType { get; set; }
        public string Student_Login { get; set; }
        public string Student_Password { get; set; }
        public int LaboralStatus { get; set; }
        public string Work_Address { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondPhone { get; set; }


        public Student(int studentId, bool bankingStudent, bool userActiveStatus, DateTime entryDate, string firstName, string secondName, string lastName, string secondLastName, int idType, int identificationNumber, DateTime birthdate, int gender, string canton, string district, int userType, string studentLogin, string studentPassword, int laboralStatus, string workAddress, string email)
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
        }

        

   
    }
    
}
