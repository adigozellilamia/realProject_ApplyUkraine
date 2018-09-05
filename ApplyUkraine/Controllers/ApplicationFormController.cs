    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;
using System.IO;

namespace ApplyUkraine.Controllers
{
    public class ApplicationFormController : Controller
    {
        // GET: ApplicationForm

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        public ActionResult Index()
        {
           
            if (HttpContext.Session["loginned"] != null)
            {
               
                    //try
                    //{
                    
                        ViewBag.Universities = db.Universities.ToList();

                        ViewBag.User = (User)Session["loginnedUser"];
                    int userId = ViewBag.User.Id;
                    ViewBag.forms = db.UsersForms.Where(u => u.UserId == userId).ToList();
                    List<UsersForm> myForms=db.UsersForms.Where(u => u.UserId == userId).ToList();
                //int appId = ViewBag.forms[0].AppFormId;
                    ViewBag.degree = db.Degrees.ToList();
                    if(myForms.Count >0)
                    {
                    var appId = myForms[myForms.Count - 1].AppFormId;
                    ViewBag.AppForm = db.ApplicationForms.Find(appId);

                    var CoursToUniId = myForms[myForms.Count - 1].ApplicationForm.CoursToUniversityId;
                    ViewBag.University = db.Universities.Find(db.CoursToUniversities.Find(CoursToUniId).UniversityId);
                    ViewBag.Course = db.Courses.Find(db.CoursToUniversities.Find(CoursToUniId).CoursId);
                    Cours myCourse = db.Courses.Find(db.CoursToUniversities.Find(CoursToUniId).CoursId);
                    ViewBag.Faculty = db.Faculties.Find(myCourse.FacultyId);
                }
                else
                    {
                    ViewBag.AppForm = null;
                    ViewBag.University = null;
                    ViewBag.Course = null;
                    ViewBag.Faculty = null;
                    }
                   
                  
                    if (ViewBag.User.IsConfirm != true)
                    {
                        return RedirectToAction("index", "account");
                    }
                    return View();
                    
                    //}
                    //catch (Exception e)
                    //{
                    //    return RedirectToAction("index", "errorPage");
                    //}
        
            }else
            {
                return RedirectToAction("login", "login");
            }


        }
        public ActionResult AddForm(ApplicationForm appForm, string checkbox1, string checkbox2, string checkbox3,string Language,int Degree,int id , CoursToUniversity crsToUni,HttpPostedFileBase passportFile,HttpPostedFileBase certificateFile)
        {
            string passportfilename = DateTime.Now.ToString("ddmmyyyyhhmmssffff") + passportFile.FileName;
            string passportpath = Path.Combine(Server.MapPath("~/Uploads/"), passportfilename);
            //certificate
            string certificatefilename = DateTime.Now.ToString("ddmmyyyyhhmmssffff") + certificateFile.FileName;
            string certificatepath = Path.Combine(Server.MapPath("~/Uploads/"), certificatefilename);
            string extensionFirst= Path.GetExtension(passportfilename);
            string extensionSecond = Path.GetExtension(certificatefilename);
            if (passportFile == null&& certificateFile==null)
            {
                Session["selectError"] = "your must select your file";
                return RedirectToAction("index");
            }
            if (((extensionFirst != ".pdf") && (extensionFirst != ".doc") && (extensionFirst != ".docx") && (extensionFirst != ".xls")) && ((extensionSecond != ".pdf") &&(extensionSecond != ".doc") &&(extensionSecond != ".docx") && (extensionSecond != ".xls")))
            {
                Session["typeerror"] = "your file must be jpg,png or gif";
                return RedirectToAction("index");
            }
            if (((certificateFile.ContentLength / 1024) > 5024)&& ((passportFile.ContentLength / 1024) > 5024))
            {
                Session["sizeerror"] = "your file size must be max 10mb";
                return RedirectToAction("index");
            }
            //passport
      
            

            passportFile.SaveAs(passportpath);
            certificateFile.SaveAs(certificatepath);

            //string CountryCitizen, string CountryLiving,string
            ApplicationForm applicationForm = new ApplicationForm();
            CoursToUniversity Element = db.CoursToUniversities.First(p => p.UniversityId == crsToUni.UniversityId && p.CoursId == crsToUni.CoursId);
            User currentUser = db.Users.First(p => p.Id == id);
            if (currentUser.IsConfirm != true)
            {
                Session["Unconfirmed"] = true;
                return RedirectToAction("index");
            }
            
            //int DeegreId = db.Degrees.FirstOrDefault(d => d.Name == Degree).Id;
            //sorada application.form=appform.form tipinde gedeceksen yeni test edek)
            applicationForm.FirstName = appForm.FirstName;
            applicationForm.LastName = appForm.LastName;
            applicationForm.Birthday = appForm.Birthday;
            applicationForm.Email = appForm.Email;
            applicationForm.MobilPhone = appForm.MobilPhone;
            applicationForm.SocialNetworks = checkbox1+" "+ checkbox2 + " "+ checkbox3;
            applicationForm.Skype = appForm.Skype;
            applicationForm.InvitationLetterAddress = appForm.InvitationLetterAddress;
            applicationForm.DegreeId = Degree;
            applicationForm.ZipCode = appForm.ZipCode;
            applicationForm.Language = Language;
            applicationForm.CountryLiving = appForm.CountryLiving.Remove(0, 3);
            applicationForm.CountryCitizen = appForm.CountryCitizen;
            applicationForm.Cities =  appForm.Cities;
            applicationForm.CoursToUniversityId = Element.Id;
            applicationForm.Passport = passportfilename;
            applicationForm.Certificate = certificatefilename;
            //var report = new Parti alViewAsPdf("~/Views/Shared/DetailCustomer.cshtml", customer);
            currentUser.StatusId = 2;
            db.ApplicationForms.Add(applicationForm);
            //currentUser.ApplicationFormId = applicationForm.Id;
            
            Session["loginned"] = true;
            db.SaveChanges();
            return RedirectToAction("index", "home"); 
        }
        public JsonResult Faculties(int id)
        {
            var list = db.CoursToUniversities.Where(c => c.UniversityId == id).ToList();
            var response = list.Select(f => new
            {
                f.Id,
                Faculty = new
                {
                    f.Cours.Faculty.Id,
                    f.Cours.Faculty.Name
                }
            }).ToList();
            return Json(response, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Courses(int id)
        {
            var list = db.CoursToUniversities.Where(c => c.Cours.Faculty.Id == id).ToList();
            var response = list.Select(l => new
            {
                l.Id,

                Cours = new
                {
                    l.Cours.Id,
                    l.Cours.Name
                }
            }).ToList();
            return Json(response, JsonRequestBehavior.AllowGet);

        }
    }
}