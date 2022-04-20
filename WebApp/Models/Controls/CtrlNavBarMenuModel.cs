using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlNavBarMenuModel : CtrlBaseModel
    {
        public string Options { get; set; }
        public string OptionsActionName { get; set; }
        private SysAdmin A { get; set; }
        private Student S { get; set; }
        private FinancialUser F { get; set; }
        private Recruiter R { get; set; }

        private string user_type { get; set; }

        private string URL_API_LISTs = "http://localhost:57056/api/vista/";


        public int OptionsCount => Options.Split(',').Length;

        public CtrlNavBarMenuModel()
        {
            Options = "";
            ViewName = "";
        }


        public string prueba
        {
            get
            {
                var htmlOptions = "";
                Console.WriteLine(HttpContext.Current.Request.Cookies["user_type"]);
                return htmlOptions;
            }
          
        }
        /*public string ActionLinks
        {
            get
            {
                this.user_type = HttpContext.Current.Request.Cookies["user_type"].Value;

                switch (user_type)
                {
                    case "1":
                        //this.A = (SysAdmin)HttpContext.Current.Request.Cookies["user"];
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }

            }
        }*/




    }
 }