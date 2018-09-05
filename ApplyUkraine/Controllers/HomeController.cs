using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;
using Microsoft.Ajax.Utilities;

namespace ApplyUkraine.Controllers
{
    public class HomeController : Controller
    {

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
            if (Session["loginnedUser"] != null)
            {
                ViewBag.user = (User)Session["loginnedUser"];
            }
          
            try
            {
      
                ViewBag.homeCarousel = db.Images.Where(p => p.AboutId!=null?p.About.SectionName.Name == "homeHeaderCarousel":false).ToList();              
                ViewBag.homeUniCarousel = db.Images.Where(p => p.AboutId != null ? p.About.SectionName.Name == "homeUniCarousel":false).ToList();
                ViewBag.homeUniLetter = db.Abouts.First(p => p.SectionName.Name == "homeInLetter");
                ViewBag.homeStudyUkraine = db.Abouts.First(p => p.SectionName.Name == "homeStudyUkraine");
                ViewBag.homeUniversity = db.Images.Where(p => p.AboutId != null ? p.About.SectionName.Name == "homeUniversity":false).ToList();
                ViewBag.homeEducation = db.Abouts.Where(p => p.SectionName.Name == "homeEducation").ToList();
                ViewBag.homeInvitation = db.Images.Where(p => p.AboutId != null ? p.About.SectionName.Name == "homeInvitation":false).ToList();
                ViewBag.homeGraduet = db.Abouts.ToList().Where(p => p.SectionName.Name == "homeGraduet");

                ViewBag.Universities = db.Universities.ToList();

                return View();
            }
            catch (InvalidOperationException e)
            {
                return RedirectToAction("index", "errorPage");
            }
           
            
        }
        

    }
}