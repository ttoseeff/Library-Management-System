using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;

namespace OnlineAlumniPortalMVC.Models
{
    public class CityModel
    {
        AlumniEntities db = new AlumniEntities();
        public List<tblCity> GetAll()
        {
            return db.tblCities.ToList();
        }
    }
}