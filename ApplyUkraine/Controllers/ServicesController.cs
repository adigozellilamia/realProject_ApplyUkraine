using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {

            try
            {
                ViewBag.ourServices = db.Images.ToList().Where(p => p.AboutId != null ? p.About.SectionName.Name == "ourService" : false );
                ViewBag.ourServiceGeneral = db.Abouts.First(p => p.SectionName.Name == "ourServiceGeneral");
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