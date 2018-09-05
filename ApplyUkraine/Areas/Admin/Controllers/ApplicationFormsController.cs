using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Areas.Admin.Controllers
{
    public class ApplicationFormsController : Controller
    {
        private ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        // GET: Admin/ApplicationForms
        public ActionResult Index()
        {
            return View(db.ApplicationForms.ToList());
        }

        // GET: Admin/ApplicationForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
            ViewBag.uni = db.CoursToUniversities.First(p => p.Id == applicationForm.CoursToUniversityId);
            if (applicationForm == null)
            {
                return HttpNotFound();
            }
            return View(applicationForm);
        }
        [ValidateInput(false)]
        public ActionResult Download(string filename)
        {
            
                string fullpath = Path.Combine(Server.MapPath("~/Uploads/"), filename);
                return File(fullpath, "application/msword");
            
        }

       
    }
}
