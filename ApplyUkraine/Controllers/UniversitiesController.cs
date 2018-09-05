using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;


namespace ApplyUkraine.Controllers
{
    public class UniversitiesController : Controller
    {
        // GET: Universities

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();
        string sectionName;
        //int identity;
        public ActionResult Index(int id)
        {
           
            try
            {

                ViewBag.Universities = db.Universities.ToList();
                ViewBag.University = db.Universities.First(p => p.Id == id);
                ViewBag.Description = db.Descriptions.First(p => p.UniversityId == id);
                ViewBag.Course = db.CoursToUniversities.Where(p => p.UniversityId!=null? p.UniversityId== id:false);
                ViewBag.UniversityAbouts = db.Images.ToList().Where(p => p.UniversityId == id && p.About.SectionName.Name == p.University.Name);
             
                return View();


            }
            catch(InvalidOperationException e)
            {
                return RedirectToAction("index", "errorPage");
            }

        }
    }
}