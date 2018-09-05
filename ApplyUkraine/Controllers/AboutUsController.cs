using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
            try
            {
                ViewBag.aboutUs = db.Abouts.ToList().Where(p => p.SectionName.Name == "aboutUs");
                ViewBag.Universities = db.Universities.ToList();
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("index", "errorPage");
            }
            
        }
    }
}