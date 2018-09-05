using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Controllers
{
    public class BlogApplyController : Controller
    {
        // GET: BlogApply

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index( int id)
        {
            ViewBag.Blogs = db.Images.Where(p => p.AboutId == null && p.UniversityId == null).ToList();
            ViewBag.Blog = db.Images.First(p => p.AboutId == null && p.UniversityId == null && p.BlogId == id);
            ViewBag.Universities = db.Universities.ToList();
            return View();
            //try
            //{
               
            //}
            //catch (InvalidOperationException e)
            //{
            //    return RedirectToAction("index", "errorPage");
            //}
            
        }
    }
}