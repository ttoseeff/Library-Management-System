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
        // GET: /UserControllerSignIn/
        public ActionResult SignIn()
        {
            new GernalFunction().CheckUserLoggedIn();
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Student student)
        {
            AlumniEntities db = new AlumniEntities();
            var s = db.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);
            if (s != null)
            {
                new GernalFunction().SetUserCookies(s);
                return RedirectToAction("DashboardIndex");
            }
            ViewBag.LoginError = "Login or UserName is Incorrect.";
            return View();
        }
        public ActionResult Logout()
        {
            new GernalFunction().CheckUserLogin();
            if (Request.Cookies["UserCookies"] != null)
            {
                var cookie = new HttpCookie("UserCookies");
                cookie.Expires = DateTime.Now.AddDays(-30);
                HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("SignIn");
        }
    }
}