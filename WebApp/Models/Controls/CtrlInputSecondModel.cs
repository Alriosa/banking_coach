using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls 
{
    public class CtrlInputSecondModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }

        public CtrlInputSecondModel()
        {
            ViewName = "";
        }
    }
}