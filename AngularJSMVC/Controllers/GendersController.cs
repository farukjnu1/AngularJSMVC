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
    public class GendersController : Controller
    {
        private AngularJSMVCContext db = new AngularJSMVCContext();

        // GET: Genders
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGenders()
        {
            return Json(db.Genders.ToList(), JsonRequestBehavior.AllowGet);
        }

        public string InsertGender(Gender gender)
        {
            if (gender != null)
            {
                db.Genders.Add(gender);
                db.SaveChanges();
                return "Gender Added Successfully";
            }
            else
            {
                return "Gender Not Inserted! Try Again";
            }
        }

        public string UpdateGender(Gender gender)
        {
            if (gender != null)
            {
                db.Entry(gender).State = EntityState.Modified;
                db.SaveChanges();
                return "Gender Updated Successfully";
            }
            else
            {
                return "Gender Not Updated! Try Again";
            }
        }

        public string DeleteGender(Gender gender)
        {
            if (gender != null)
            {
                Gender aGender = db.Genders.Find(gender.Id);
                db.Genders.Remove(aGender);
                db.SaveChanges();
                return "Gender Deleted Successfully";
            }
            else
            {
                return "Gender Not Deleted! Try Again";
            }
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
