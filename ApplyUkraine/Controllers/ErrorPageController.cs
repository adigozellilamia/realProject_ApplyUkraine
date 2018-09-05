using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplyUkraine.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
    }
}