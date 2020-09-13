using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;
using System.Data.Entity.Validation;


namespace OnlineAlumniPortalMVC.Models
{
    public class EventsModel
    {
        AlumniEntities db = new AlumniEntities();
        public void Save(Event stu)
        {
            try
            {

                db.Events.Add(stu);
                db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {

            }
        }

        public void Update(Event slider)
        {
            db.Events.Attach(slider);
            var Update = db.Entry(slider);
            Update.Property(x => x.DateofEvent).IsModified = true;
            Update.Property(x => x.Event1).IsModified = true;
            Update.Property(x => x.PlaceofEvent).IsModified = true;
            Update.Property(x => x.IsActive).IsModified = true;
            Update.Property(x => x.CreatedDate).IsModified = true;
            Update.Property(x => x.Photo).IsModified = true;
            Update.Property(x => x.Description).IsModified = true;
            db.SaveChanges();
        }

        public Event GetByID(int ID)
        {
            return db.Events.Where(x => x.ID == ID).FirstOrDefault();
        }

        public List<Event> GetAll()
        {
            return db.Events.OrderByDescending(x => x.ID).ToList();
        }

        public void Delete(int ID)
        {
            var item = db.Events.Where(x => x.ID == ID).FirstOrDefault();
            db.Events.Remove(item);
            db.SaveChanges();
        }
    }
}