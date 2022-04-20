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
        public string Controller_Name { get; set; }
        public int View_Name { get; set; }
        public Views()
        {

        }

        public Views(int viewID, string controller_Name, int view_Name)
        {
            ViewID = viewID;
            Controller_Name = controller_Name;
            View_Name = view_Name;
        }
    }
}
