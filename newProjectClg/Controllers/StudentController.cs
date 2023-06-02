using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newProjectClg.Controllers
{
    public class StudentController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
    }
}