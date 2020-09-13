using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAlumniPortalMVC.Models;
using Silkways.Models.SilkwaysFunction;

namespace OnlineAlumniPortalMVC.Controllers.User
{
    public partial class FrontPanelController : Controller
    {
        //
        // GET: /User/
        public  ActionResult DashboardIndex()
        {
            AlumniEntities db = new AlumniEntities();
            new GernalFunction().CheckUserLogin();
            string Email = HttpContext.Request.Cookies["UserCookies"]["Email"];
            string Password = HttpContext.Request.Cookies["UserCookies"]["Password"];
            var s = db.Students.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            return View(s);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
	}
}