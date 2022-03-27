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
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Email { get; set; }
        public int LaboralStatus { get; set; }
        public string WorkAddress { get; set; }
        public int LaboralExperience { get; set; }
        public string StudentUser { get; set; }
        public string StudentPassword { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }


    }
}
