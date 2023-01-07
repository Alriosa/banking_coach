using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class UserLog : BaseEntity
    {
        public int IdRecordNumber {get;set;}
        public string EventLogged { get; set; }
        public DateTime DateLogged { get; set; }

        public UserLog()
        {
            
        }

        public UserLog(int idRecordNumber, string eventLogged, DateTime dateLogged)
        {
            IdRecordNumber = idRecordNumber;
            EventLogged = eventLogged;
            DateLogged = dateLogged;
        }
    }
}
