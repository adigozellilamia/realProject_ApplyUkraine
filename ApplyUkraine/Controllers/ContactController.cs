using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
            try
            {
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