using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
            ViewBag.Universities = db.Universities.ToList();
            ViewBag.Blogs = db.Images.Where(p=> p.AboutId==null && p.UniversityId==null).ToList();
            return View();
        }
    }
}