using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EntityUser : BaseEntity
    {
        public int EntityUserID { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string UserActiveStatus { get; set; }
        public string User_Login { get; set; }

        public EntityUser()
        {
          
        }

        public EntityUser(int entityUserID, string name, string id, int quantity, string userActiveStatus, string user_Login)
        {
            EntityUserID = entityUserID;
            Name = name;
            Id = id;
            Quantity = quantity;
            UserActiveStatus = userActiveStatus;
            User_Login = user_Login;
        }
    }
}
