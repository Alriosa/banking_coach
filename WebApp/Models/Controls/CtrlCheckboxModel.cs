using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCheckboxModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; } 
        public string ColumnDataName { get; set; }

        public string Class { get; set; }

        public CtrlCheckboxModel()
        {
            ViewName = "";
        }
    }
}