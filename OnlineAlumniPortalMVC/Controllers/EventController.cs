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
    public class EventController : Controller
    {
        //
        // GET: /Event/
        AlumniEntities db = new AlumniEntities();
        public ActionResult AddEvent()
        {
            ViewBag.ContriesList = new CountryModel().GetAll();
            ViewBag.CitiesList = new CityModel().GetAll();
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                Event EditUser = new EventsModel().GetByID(ID);
                EditUser.Photo = "/Resources/Event/" + EditUser.Photo;
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddEvent(Event slider, HttpPostedFileBase file, string ImageName)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    bool ISDone = false;
                    string FileName = Path.GetFileName(file.FileName);
                    slider.Photo = FileName;
                    string path = Server.MapPath("/Resources/Event/" + FileName);
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
            slider.CreatedDate = DateTime.Now;
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                slider.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new EventsModel().Update(slider);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                slider.IsActive = true;
                new EventsModel().Save(slider);
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("ManageEvents");
        }
        public ActionResult ManageEvents()
        {
            List<Event> lst = new EventsModel().GetAll();
            return View(lst);
        }
        public void Delete(int ID)
        {
            new EventsModel().Delete(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageEvents");
        }
	}
}