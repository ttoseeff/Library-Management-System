using OnlineAlumniPortalMVC.Models;
using Silkways.Models;
using OnlineAlumniPortalMVC.ViewModels;
using Silkways.Models.SilkwaysFunction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAlumniPortalMVC.Controllers
{
    public class StudentsController : Controller
    {
        //
        // GET: /Sliders/
        AlumniEntities db = new AlumniEntities();
        public ActionResult AddStudent()
        {
            ViewBag.WifeList = new StudentsModel().GetAllWifeOccupation();
            ViewBag.EmployedList = new StudentsModel().GetAllEmployed();
            ViewBag.ContriesList = new CountryModel().GetAll();
            ViewBag.CitiesList = new CityModel().GetAll();
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                Student EditUser = new StudentsModel().GetByID(ID);
                EditUser.Photo = "/Resources/Sliders/" + EditUser.Photo;
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddStudent(Student slider, HttpPostedFileBase file, string ImageName)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    bool ISDone = false;
                    string FileName = Path.GetFileName(file.FileName);
                    slider.Photo = FileName;
                    string path = Server.MapPath("/Resources/Sliders/" + FileName);
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
                new StudentsModel().Update(slider);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                slider.IsActive = true;
                new StudentsModel().Save(slider);
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("ManageStudents");
        }
        public ActionResult AddFeeRecords(int StudentID)
        {
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            ViewBag.ClassesList = new StudentsModel().GetAllClasses();
			ViewBag.StudentList = new StudentsModel().GetStudentsByID(StudentID);
			ViewBag.Student = new StudentsModel().GetByID(StudentID);
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                FeeRecord EditUser = new StudentsModel().GetFeeRecord(ID);
                DateTime IssuedDate =Convert.ToDateTime(EditUser.IssueDate);
               // ViewBag.date = IssuedDate.ToString("{0:MM/dd/yyyy HH:mm}"); 
                //EditUser.Photo = "/Resources/Sliders/" + EditUser.Photo;
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddFeeRecords(FeeRecord SFR, HttpPostedFileBase file,int StudentID)
		{
			ViewBag.StudentList = new StudentsModel().GetStudentsByID(StudentID);
			ViewBag.Student = new StudentsModel().GetByID(StudentID);
			SFR.StudentID = StudentID;
			if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                SFR.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new StudentsModel().UpdateRecord(SFR);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                //SFR.IsDelete = false;
                new StudentsModel().SaveRecord(SFR);
                TempData["AlertTask"] = "Record Successfully Saved";
                
            }
            return RedirectToAction("MonthlyFee");
        }

        public ActionResult ManageStudents()
        {
            List<Student> lst = new StudentsModel().GetAll();
            return View(lst);
        }
        public void Delete(int ID)
        {
            new StudentsModel().Delete(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageStudents");
        }
        public ActionResult MonthlyFee(int StudentID)
        {
            List<FeeRecord> lst = new StudentsModel().GetFeeRecordByStudentID(StudentID);
			ViewBag.Student = new StudentsModel().GetByID(StudentID);
			return View(lst);
        }
        public void DeleteFeeRecord(int ID)
        {
            new StudentsModel().DeleteFeeRecord(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageStudents");
        }

        public ActionResult Search()
        {
            TempData["AlertTask"] = null;
            int pageno = 0;
            if (HttpContext.Request.QueryString["pageno"] != null)
            {
                pageno = Convert.ToInt32(HttpContext.Request.QueryString["pageno"]) - 1;
            }

            StudentSearchViewModel mod = new StudentSearchViewModel("", "");
            return View(mod);
        }

        [HttpPost]
        public ActionResult Search(string Name, string email)
        {
            StudentSearchViewModel mod = new StudentSearchViewModel(Name, email);
            ViewBag.Member = Name;
            ViewBag.email = email;
            return View(mod);
        }
		//public ActionResult SearchFeeRecord()
		//{
		//    TempData["AlertTask"] = null;
		//    int pageno = 0;
		//    if (HttpContext.Request.QueryString["pageno"] != null)
		//    {
		//        pageno = Convert.ToInt32(HttpContext.Request.QueryString["pageno"]) - 1;
		//    }
		//    FeeRecordSearchViewModel mod = new FeeRecordSearchViewModel("", "");
		//    return View(mod);

		//}

		//[HttpPost]
		//public ActionResult SearchFeeRecord(string Name, string email)
		//{
		//    FeeRecordSearchViewModel mod = new FeeRecordSearchViewModel(Name, email);
		//    ViewBag.Member = Name;
		//    ViewBag.email = email;
		//    return View(mod);
		//}
		public ActionResult NotSubmitFee()
		{
			DateTime CurrentDate = DateTime.Now;
			int year = CurrentDate.Year;
			int month = CurrentDate.Month;
			List<int?> FeeRecordList = db.FeeRecords.Where(x=>x.DueDate.Month==month && x.DueDate.Year==year && x.DueDate.Day>10).Select(x=>x.StudentID).ToList();
			List<Student> studentsList = db.Students.Where(x => !FeeRecordList.Contains(x.ID)).ToList();
			return View(studentsList);
		}

    }
}