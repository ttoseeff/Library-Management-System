using OnlineAlumniPortalMVC.Models;
using Silkways.Models;
using Silkways.Models.SilkwaysFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAlumniPortalMVC.ViewModels
{
    public class TeacherSearchViewModel
    {
        public string SName = "";
        public string Sdesignation = "";
        public string Sfrom = "";
        public string Sto = "";
        public int counts = 0;
        public int Row = 0;
        public TeacherSearchViewModel(string CompanyName, string designation)
        {
            SName = CompanyName;
            Sdesignation = designation;
        }


        public string pagination { get; set; }
        List<Teacher> conts;
        public List<Teacher> Conts
        {
            get
            {
                if (conts != null)
                {
                    return conts;
                }
                else
                {
                    int pageno = 0;
                    if (Row != 0)
                    {
                        if (HttpContext.Current.Request.QueryString["pageno"] != null)
                        {
                            pageno = Convert.ToInt32(HttpContext.Current.Request.QueryString["pageno"]) - 1;
                        }
                    }
                    conts = new TeachersModel().Search(SName, Sdesignation,  pageno);
                    counts = new TeachersModel().SearchCount(SName, Sdesignation);
                    pagination = GernalFunction.BuildBootstrapPagination(counts, "teachers/search", pageno, 50);
                    return conts;
                }
            }
        }
    }
}