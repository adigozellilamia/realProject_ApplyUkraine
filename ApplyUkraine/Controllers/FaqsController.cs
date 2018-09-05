using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class FaqsController : Controller
    {
        // GET: Faqs

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
            try
            {
                ViewBag.faqsLeft = db.Abouts.ToList().Where(p => p.SectionName.Name == "faqsLeft");
                ViewBag.faqsRight = db.Abouts.ToList().Where(p => p.SectionName.Name == "faqsRight");
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