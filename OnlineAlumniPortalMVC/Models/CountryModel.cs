using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;

namespace OnlineAlumniPortalMVC.Models
{
    public class CountryModel
    {
        AlumniEntities db = new AlumniEntities();
        public List<tblCountry> GetAll()
        {
            return db.tblCountries.ToList();
        }
    }
}