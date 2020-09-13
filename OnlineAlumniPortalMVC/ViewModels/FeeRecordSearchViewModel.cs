using OnlineAlumniPortalMVC.Models;
using Silkways.Models;
using Silkways.Models.SilkwaysFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAlumniPortalMVC.ViewModels
{
    public class FeeRecordSearchViewModel
    {
        public string SName = "";
        public string Semail = "";
        public string Sfrom = "";
        public string Sto = "";
        public int count = 0;
        public int Row = 0;
        //public FeeRecordSearchViewModel(string CompanyName, string email)
        //{
        //    SName = CompanyName;
        //    Semail = email;
        //}
        //public string pagination { get; set; }
        //List<FeeRecord> cons;
        //public List<FeeRecord> Cons
        //{
        //    get
        //    {
        //        if (cons != null)
        //        {
        //            return cons;
        //        }
        //        else
        //        {
        //            int pageno = 0;
        //            if (Row != 0)
        //            {
        //                if (HttpContext.Current.Request.QueryString["pageno"] != null)
        //                {
        //                    pageno = Convert.ToInt32(HttpContext.Current.Request.QueryString["pageno"]) - 1;
        //                }
        //            }
        //            cons = new StudentsModel().SearchFeeRecord(SName, Semail,  pageno);
        //            count = new StudentsModel().FeeRecordSearchCount(SName, Semail);
        //            pagination = GernalFunction.BuildBootstrapPagination(count, "students/search", pageno, 50);
        //            return cons;
        //        }
        //    }
        //}
    }
}