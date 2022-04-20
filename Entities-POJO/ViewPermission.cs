using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ViewPermission : BaseEntity
    {
        public string IdUserType { get; set; }
        public string Controller_Name { get; set; }
        public string View_Name { get; set; }

        public ViewPermission()
        {
        }
        public ViewPermission(string id_User_Type, string controller_Name, string view_Name)
        {
            IdUserType = id_User_Type;
            Controller_Name = controller_Name;
            View_Name = view_Name;
        }
    }
}
