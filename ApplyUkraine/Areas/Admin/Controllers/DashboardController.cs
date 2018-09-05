using ApplyUkraine.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplyUkraine.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [auth]
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}