using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularJSMVC.Data;
using AngularJSMVC.Models;

namespace AngularJSMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private AngularJSMVCContext db = new AngularJSMVCContext();

        // GET: Employees
        public ActionResult Index()
        {
            //var employees = db.Employees.Include(e => e.Gender);
            //return View(employees.ToList());
            return View();
        }

        public JsonResult GetEmployees()
        {
            return Json(db.Employees.Include(e => e.Gender).ToList(), JsonRequestBehavior.AllowGet);
        }

        public string InsertEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return "Employee Added Successfully";
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }

        public string UpdateEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return "Employee Updated Successfully";
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }

        public string DeleteEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                Employee anEmployee = db.Employees.Find(employee.Id);
                db.Employees.Remove(anEmployee);
                db.SaveChanges();
                return "Gender Deleted Successfully";
            }
            else
            {
                return "Gender Not Deleted! Try Again";
            }
        }

        public JsonResult GetGenders()
        {
            return Json(db.Genders.ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
