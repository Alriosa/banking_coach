using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Views : BaseEntity
    {
        public int ViewID { get; set; }
        public string ControllerName { get; set; }
        public int ViewName { get; set; }
        public string ViewDescription { get; set; }

        public string GroupView { get; set; }

        public Views()
        {

        }

        public Views(int viewID, string controller_Name, int view_Name, string view_Description, string groupView)
        {
            ViewID = viewID;
            ControllerName = controller_Name;
            ViewName = view_Name;
            ViewDescription = view_Description;
            GroupView = groupView;
        }
    }
}
