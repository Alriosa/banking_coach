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
        public string ControllerName { get; set; }
        public string ViewName { get; set; }

        public string ViewDescription { get; set; }

        public ViewPermission()
        {
        }
        public ViewPermission(string idUserType, string controllerName, string viewName)
        {
            IdUserType = idUserType;
            ControllerName = controllerName;
            ViewName = viewName;
        }
    }
}
