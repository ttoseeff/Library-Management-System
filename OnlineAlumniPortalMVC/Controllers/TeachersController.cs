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
    public class TeachersController : Controller
    {
        //
        // GET: /Teachers/
        AlumniEntities db = new AlumniEntities();
        public ActionResult AddTeacher()
        {
           
           
            ViewBag.ContriesList = new CountryModel().GetAll();
            ViewBag.CitiesList = new CityModel().GetAll();
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            ViewBag.DesignationsList = new TeachersModel().GetAllDesignation();
           
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                Teacher EditUser = new TeachersModel().GetByID(ID);                
                return View(EditUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTeacher(Teacher tchr)
        {
           
            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                tchr.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new TeachersModel().Update(tchr);                
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                new TeachersModel().save(tchr);               
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("ManageTeachers");
        }
        public ActionResult ManageTeachers()
        {
            List<Teacher> lst = new TeachersModel().GetAll();          
            return View(lst);
        }
        public void Delete(int ID)
        {
            new TeachersModel().Delete(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageTeachers");
        }
        public ActionResult AddSalaryRecord()
        {
          
            ViewBag.UniversityCampusList = new UniversityCampusModel().GetAll();
            ViewBag.DesignationsList = new TeachersModel().GetAllDesignation();

            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                SalaryRecord edit = new TeachersModel().GetRByID(ID);
                return View(edit);
                
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSalaryRecord(SalaryRecord Sr)
        {

            if (Convert.ToInt32(Request.QueryString["ID"]) != 0 && Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                Sr.ID = Convert.ToInt32(Request.QueryString["ID"]);
                new TeachersModel().UpdateR(Sr);
                TempData["AlertTask"] = "Record Successfully Update";
            }
            else
            {
                new TeachersModel().SaveSR(Sr);
                TempData["AlertTask"] = "Record Successfully Saved";
            }
            return RedirectToAction("Manage Monthly Salary");
           
        }
        public JsonResult InsertSalary(List<SalaryRecord> salaryrecords)
        {
            using (AlumniEntities entities = new AlumniEntities())
            {
                //Truncate Table to delete all old records.
                entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [SalaryRecord]");

                //Check for NULL.
                if (salaryrecords == null)
                {
                    salaryrecords = new List<SalaryRecord>();

                }

                //Loop and insert records.
                foreach (SalaryRecord SalaryRecord in salaryrecords)
                {
                    entities.SalaryRecords.Add(SalaryRecord);

                }
                int insertedRecords = entities.SaveChanges();
                return Json(insertedRecords);
            }
        }
        public ActionResult ManageMonthlySalary()
        {
            List<SalaryRecord> list = new TeachersModel().GetAllRecord();
            return View(list);
           
        }
        public void DeleteR(int ID)
        {
            new TeachersModel().DeleteR(ID);
            TempData["AlertTask"] = "Record Successfully Deleted";
            Response.Redirect("ManageMonthlySalary");
        }
        public ActionResult Search()
        {
            TempData["AlertTask"] = null;
            int pageno = 0;
            if (HttpContext.Request.QueryString["pageno"] != null)
            {
                pageno = Convert.ToInt32(HttpContext.Request.QueryString["pageno"]) - 1;
            }
            TeacherSearchViewModel mod = new TeacherSearchViewModel("", "");          
            return View(mod);
        }

        [HttpPost]
        public ActionResult Search(string Name, string designation)
        {
            TeacherSearchViewModel mod = new TeacherSearchViewModel( Name,designation);     
            
            ViewBag.Member = Name;
            ViewBag.designation = designation;
            return View(mod);
        }
	}
}