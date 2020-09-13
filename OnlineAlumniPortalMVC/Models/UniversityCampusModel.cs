using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;

namespace OnlineAlumniPortalMVC.Models
{
    public class UniversityCampusModel
    {
        AlumniEntities db = new AlumniEntities();
        public List<tblUniversityCampu> GetAll()
        {
            return db.tblUniversityCampus.ToList();
        }
        public void Save(tblUniversityCampu stu)
        {
            db.tblUniversityCampus.Add(stu);
            db.SaveChanges();
        }
      
        public void Update(tblUniversityCampu slider)
        {
            db.tblUniversityCampus.Attach(slider);
            var Update = db.Entry(slider);
            Update.Property(x => x.Title).IsModified = true;
            Update.Property(x => x.isActive).IsModified = true;
            Update.Property(x => x.Photo).IsModified = true;
            db.SaveChanges();
        }

        public tblUniversityCampu GetByID(int ID)
        {
            return db.tblUniversityCampus.Where(x => x.ID == ID).FirstOrDefault();
        }

        

        public void Delete(int ID)
        {
            var item = db.tblUniversityCampus.Where(x => x.ID == ID).FirstOrDefault();
            db.tblUniversityCampus.Remove(item);
            db.SaveChanges();
        }
    }
}