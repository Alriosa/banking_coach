using Entities_POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private string URL_API_LISTs = "http://localhost:57056/api/permits/";


        public int OptionsCount => Options.Split(',').Length;

        public CtrlNavBarMenuModel()
        {
            Options = "";
            ViewName = "";
            //this.user_type = HttpContext.Current.Request.Cookies["type"].Value;
        }


        public string ActionLinks
        {
            get
            {
                var links = "";
                HttpCookie nameCookie = HttpContext.Current.Request.Cookies["type"];
                if (nameCookie != null)
                {
                    this.user_type = nameCookie.Value;
                    var views = GetViewsFromAPI(user_type.ToString());
                    var optionsActionName = OptionsActionName.Split(',').ToList();
                    var optionsName = Options.Split(',').ToList();
                    var lstGrupos = views.GroupBy(x => x.ControllerName).ToList();


                    var cont = 0;
                    foreach (var group in lstGrupos)
                    {
                        
                        if (group.Key != "")
                        {
                           
                            links +=
                                "<li class='nav-item dropdown'>" +
                                    "<a style='cursor:pointer;' class='nav-link' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + optionsName[cont] + "<span><i class='fa fa-angle-down '></i></span></a>" +
                                    "<ul class='dropdown-menu' aria-labelledby='navbarDropdown'>";

                            foreach (var item in group)
                            {
                                links += "<li>" +
                                "<a href=\"/" + item.ControllerName + "/" + item.ViewName + "\" class=\"dropdown-item\">" + item.ViewDescription + "</a>" +
                                "</li>";
                            }

                            links += "</ul></li>";
                        }
                        else
                        {
                            foreach (var item in group)
                            {
                                links += "<li>" +
                                "<a href=\"/" + item.ControllerName + "/" + item.ViewName + "\" class=\"dropdown-item\">" + item.ViewDescription + "</a>" +
                                "</li>";
                            }
                        }
                        cont++;
                    }
                    
                }
                else
                {
                    //None
                }

                return links;
            }
          
        }
        

        private List<ViewPermission> GetViewsFromAPI(string idUserType)
        {
            var client = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var response = client.DownloadString(URL_API_LISTs + idUserType);
            var options = JsonConvert.DeserializeObject<List<ViewPermission>>(response);
            return options;
        }


    }
 }