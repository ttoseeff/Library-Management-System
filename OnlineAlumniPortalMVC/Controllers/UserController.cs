using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silkways.Models;
using Silkways.Models.SilkwaysFunction;
using System.IO;
using OnlineAlumniPortalMVC.Models;

namespace Silkways.Controllers
{
    public class UserController : Controller
    {
        public ActionResult DashboardIndex()
        {
            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Validation = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User loginCheck = new UserModel().GetUserByEmailandPassword(username, password);
            if (loginCheck != null)
            {
                if (loginCheck.IsActive == true)
                {
                    new GernalFunction().SetCookie(loginCheck);
                    return RedirectToAction("DashboardIndex","User");
                }
                else
                {
                    ViewBag.Validation = "Deactive";
                    return View();
                }
            }
            ViewBag.Validation = "False";
            return View();
        }

        public ActionResult AddUser()
        {
            new GernalFunction().CheckAdminLogin();

            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int UserID = Convert.ToInt32(Request.QueryString["ID"]);
                User EditUser = new UserModel().GetUserByID(UserID);
                EditUser.Image = "/Resources/AdminPictures/" + EditUser.Image;
                ViewBag.Active = EditUser.IsActive;
                ViewBag.Admin = EditUser.IsAdmin;
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddUser(User users, string Active)
        {
            new GernalFunction().CheckAdminLogin();

            if (users.Image != null)
            {
                if (!users.Image.Contains("Resources/AdminPictures"))
                {
                    string FileName = "";
                    string HostedFilePath = "";
                    users.Image = GernalFunction.ImageCroping(users.Image, "/Resources/AdminPictures/", false,out HostedFilePath,out FileName);
                }
                else
                {
                    users.Image = Path.GetFileName(users.Image);
                }
            }
            else
            {
                users.Image = "NoImage.jpg";
            }

            if (Active == "on")
            {
                users.IsActive = true;
            }
            else
            {
                users.IsActive = false;
            }
           
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                users.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new UserModel().Update(users);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                #region Username and Email Exists
                bool Email = new UserModel().EmailExist(users.Email);
                ViewBag.Exists = "";
                if (Email == true)
                {
                    bool username = new UserModel().UsernameExist(users.UserName);
                    if (username == false)
                    {
                        ViewBag.Exists = "Username";
                    }
                }
                else
                {
                    ViewBag.Exists = "Email";
                }

                if (ViewBag.Exists != "")
                {
                    return View();
                }
                #endregion
                users.IsAdmin = false;
                new UserModel().Save(users);
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("ManageUsers");

        }

        public ActionResult ManageUsers()
        {

            new GernalFunction().CheckAdminLogin();

            List<User> lst = new UserModel().GetAllUser();
            return View(lst);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string old, string newpass, string confrim)
        {
            if (old != null && old != "" && newpass != null && newpass != "" && confrim != null && confrim != "")
            {
                if (newpass == confrim)
                {
                    HttpCookie cookie = HttpContext.Request.Cookies["AdminCookies"];
                    int ID = Convert.ToInt32(cookie.Values["ID"]);
                    User usr = new UserModel().GetUserByID(ID);
                    if (usr.Password == old)
                    {
                        usr.Password = newpass;
                        var user = new User()
                        {
                            ID = ID,
                            Password = newpass
                        };
                        using (var dbpass = new AlumniEntities())
                        {
                            try
                            {
                                dbpass.Users.Attach(user);
                                dbpass.Entry(user).Property(x => x.Password).IsModified = true;
                                dbpass.SaveChanges();
                                TempData["AlertTask"] = "Password Successfully Update";
                                return RedirectToAction("DashboardIndex", "user");
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "oldpass";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "PasswordsNotMatch";
                }
            }
            else
            {

                ViewBag.ErrorMsg = "CannotEmpty";
            }


            return View();
        }

        public void Delete(int UserID)
        {
            new UserModel().DeleteUser(UserID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageUsers");
        }

        public ActionResult LockScreen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LockScreen(string password, int hdn_ID)
        {
           User item = new UserModel().GetUserByID(hdn_ID);
            if(item.Password == password)
            {
                new GernalFunction().SetCookie(item);
                return RedirectToAction("DashboardIndex");
            }
            else
            {
                ViewBag.Pass = "Incorrect Password";
                return View();
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {  
            
            #region Email Exists
            User mem = new UserModel().GetUserByEmail(Email);
            ViewBag.Message = "";
            if (mem != null)
            {
                
                try
                {
                    //EmailFunctions.EmailSender.EmailSend(Subject, Emailfrom, Title, Email, Body);
                    ViewBag.Message = "Your Password is sent to you on your registered email address!";
                }
                catch (Exception ex)
                {
                    
                }

            }
            else
            {
                ViewBag.Message = "This Email Address is not registered!";
            }
                #endregion

            return View();
        }

       
        //[HttpPost]
        //public ActionResult Details(string order)
        //{
        //    return View();
        //}
        
        //public JsonResult ChangeOrderStatus(int OrderID, byte StatusID)
        //{
        //    //Order order = new OrderModel().GetOrderByID(OrderID);
        //    new OrderModel().UpdateOrder(OrderID,StatusID);
        //    return Json("success", JsonRequestBehavior.AllowGet);
            
        //}
    }
}