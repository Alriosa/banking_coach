using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownSecondModel : CtrlBaseModel
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string ColumnDataName { get; set; }

        public CtrlDropDownSecondModel()
        {
            ViewName = "";
        }
    }
}