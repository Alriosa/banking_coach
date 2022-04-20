using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls;

namespace WebApp.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName="")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder=placeHolder,
                ColumnDataName=columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlInputSecond(this HtmlHelper html, string id, string type, bool required, string placeHolder = "", string columnDataName = "")
        {
            var ctrl = new CtrlInputSecondModel
            {
                Id = id,
                Type = type,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                Required = required
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string type, string label, string onClickFunction="", string buttonType="primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Type = type,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string label, string listId, string columnDataName)
        {
            var ctrl = new CtrlDropDownModel
            {
                Id = id,
                Label = label,
                ListId = listId,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDownSecond(this HtmlHelper html, string id, string title, string label, string name, string columnDataName)
        {
            var ctrl = new CtrlDropDownSecondModel
            {
                Id = id,
                Title = title,
                Label = label,
                Name = name,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlCheckbox(this HtmlHelper html, string id, string type, string label, string classes, string columnDataName = "")
        {
            var ctrl = new CtrlCheckboxModel
            {
                Id = id,
                Type = type,
                Label = label,
                Class = classes,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}