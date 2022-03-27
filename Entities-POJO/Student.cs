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

        public Student()
        {

        }
        public Student(int studentId, bool bankingStudent, bool userActiveStatus, DateTime entryDate, string firstName, string secondName, string lastName, string secondLastName, int idType, int identificationNumber, DateTime birthdate, int gender, string canton, string district)
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
        }

        

   
    }
    
}
