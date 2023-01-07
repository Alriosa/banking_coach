using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Permission : BaseEntity
    {
        public string IdUserType { get; set; }
        public int IdView { get; set; }

        public Permission()
        {
        }

        public Permission(string idUserType, int idView)
        {
            IdUserType = idUserType;
            IdView = idView;
        }
    }
}
