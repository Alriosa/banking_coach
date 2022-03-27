using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class UserLog : BaseEntity
    {
        public int Id_Record_Number {get;set;}
        public string Event_Logged { get; set; }
        public DateTime Date_Logged { get; set; }

        public UserLog()
        {
            
        }

        public UserLog(int idRecordNumber, string eventLogged, DateTime dateLogged)
        {
            Id_Record_Number = idRecordNumber;
            Event_Logged = eventLogged;
            Date_Logged = dateLogged;
        }
    }
}
