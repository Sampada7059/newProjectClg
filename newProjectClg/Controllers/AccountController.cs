using newProjectClg.Models;
using newProjectClg.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newProjectClg.Controllers
{

    public class AccountController : Controller
    {

        Clg_ManagementEntities2 db = new Clg_ManagementEntities2();
        // GET: Account
        public ActionResult Index()
        {
            List<User> students = db.Users.ToList();
            return View(students);
        }
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(StudentRegVM obj)
        {

            User u = new User();
            u.Username = obj.Username;
            u.Password = obj.Password;
            u.Status = true;
            u.User_Type = 3;

            db.Users.Add(u);
            db.SaveChanges();

            Student student = new Student();
            student.Name = obj.Name;
            student.Gender = obj.Gender;
            student.Department = obj.Department;
            student.Roll_Number = obj.Roll_Number;
            student.Section = obj.Section;
            student.Email = obj.Email;
            student.Phone_Number = obj.Phone_Number;
            student.Student_Fee = obj.Student_Fee;
            student.User_Id = u.Id;

            db.Students.Add(student);
            db.SaveChanges();

            Address address = new Address();
            address.Door_Number = obj.Door_Number;
            address.Area = obj.Area;
            address.City = obj.City;
            address.Pincode = obj.Pincode;
            address.Student_Id = student.Id;

            db.Addresses.Add(address);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}