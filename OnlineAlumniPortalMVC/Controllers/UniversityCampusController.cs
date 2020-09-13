using OnlineAlumniPortalMVC.Models;
using Silkways.Models;
using Silkways.Models.SilkwaysFunction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAlumniPortalMVC.Controllers
{
    public class UniversityCampusController : Controller
    {
        //
        // GET: /UniversityCampus/
        AlumniEntities db = new AlumniEntities();
        public ActionResult AddUniversityCampus()
        {
            ViewBag.ContriesList = new CountryModel().GetAll();
            ViewBag.CitiesList = new CityModel().GetAll();
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                tblUniversityCampu EditUser = new UniversityCampusModel().GetByID(ID);
                EditUser.Photo = "/Resources/UniverstiyCampus/" + EditUser.Photo;
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddUniversityCampus(tblUniversityCampu slider, HttpPostedFileBase file, string ImageName)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    bool ISDone = false;
                    string FileName = Path.GetFileName(file.FileName);
                    slider.Photo = FileName;
                    string path = Server.MapPath("/Resources/UniverstiyCampus/" + FileName);
                    file.SaveAs(path);
                }
            }
            else if (ImageName != null)
            {
                slider.Photo = Path.GetFileName(ImageName);
            }
            else
            {
                slider.Photo = "Noimage.jpg";
            }
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                slider.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new UniversityCampusModel().Update(slider);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                slider.isActive = true;
                new UniversityCampusModel().Save(slider);
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("ManageUniversityCampuses");
        }
        public ActionResult ManageUniversityCampuses()
        {
            List<tblUniversityCampu> lst = new UniversityCampusModel().GetAll();
            return View(lst);
        }
        public void Delete(int ID)
        {
            new UniversityCampusModel().Delete(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageUniversityCampuses");
        }
	}
}