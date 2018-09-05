using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;
using System.Web.Helpers;

namespace ApplyUkraine.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();
        public ActionResult Index()
        {

            return View();


        }
        [HttpPost]

        
        public ActionResult Login(AdminDashboard admin)
        {
            AdminDashboard loginned = db.AdminDashboards.FirstOrDefault(u => u.Email == admin.Email);
            if (loginned != null)
            {
                if (Crypto.VerifyHashedPassword(loginned.Password, admin.Password))
                {
                    Session["loginned"] = true;
                    Session["usrid"] = loginned.Id;
                    return RedirectToAction("index", "users");
                }
            }
            Session["LoginInvalid"] = true;
            return RedirectToAction("index");
        }
        public ActionResult Logout()
        {
          
            Session["loginned"] = null; 
            return RedirectToAction("index");
        }
    }
}