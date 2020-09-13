using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAlumniPortalMVC.Models;

namespace OnlineAlumniPortalMVC.Controllers.User
{
    public partial class FrontPanelController : Controller
    {
        //
        // GET: /FrontPanelControllerEvent/
        AlumniEntities db = new AlumniEntities();
        public ActionResult EventIndex()
        {
            var events = db.Events.Where(x => x.IsActive == true).ToList();
            return View(events);
        }
        public ActionResult EventDetail(int ID)
        {
            var events = db.Events.Where(x => x.IsActive == true && x.ID==ID).FirstOrDefault();
            return View(events);
        }
	}
}