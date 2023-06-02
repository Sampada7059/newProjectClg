using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using newProjectClg.Models;

namespace newProjectClg.Controllers
{
    public class LatestUpdatesController : Controller
    {
        Clg_ManagementEntities2 db = new Clg_ManagementEntities2();

        public DateTime? CreatedDate { get; set; }
        
        public ActionResult Update()
        {
            
            return View(db.LatestUpdates.ToList());
            
        }
        
        [HttpPost]
        public ActionResult Update(LatestUpdate l)
        {
            if (ModelState.IsValid)
            {
                l.Created_Date = DateTime.Now;
                db.LatestUpdates.Add(l);
                db.SaveChanges();
                return RedirectToAction("Update");
            }
            return View(l);
        }
    }
}
