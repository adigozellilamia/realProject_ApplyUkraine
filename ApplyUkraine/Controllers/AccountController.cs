using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;
using System.Web.Helpers;
using Stripe;

namespace ApplyUkraine.Controllers
{
    public class AccountController : Controller
    {

        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();
        // GET: Account
        int UserId;
        public ActionResult Index()
        {

            if (Session["loginned"] == null)
            {
                return RedirectToAction("login", "login");
            }
           
            ViewBag.user= (User)Session["loginnedUser"];
           
           
           
            //this.UserId = usr;
            //User CurrentUser = db.Users.First(p => p.Id == usr);
            //ViewBag.user = CurrentUser;
            // ViewBag.birthday = CurrentUser.Birthday.Value.ToString("yyyy/MM/dd");
            //Session["id"] = CurrentUser.Id;
            //ViewBag.FullName = CurrentUser.Name + " " + CurrentUser.Surname;
            return View();
        }

        [HttpPost]
        public ActionResult Update(User usr,string oldPassword,string newPassword)
        {

            User CurrentUser = db.Users.First(p => p.Id == usr.Id);
            var x = CurrentUser.Password;
            var email = CurrentUser.Email;
           // var mirta = db.Users.Where(p => (p.Email == usr.Email) != null ? p.Email == usr.Email : false).ToList();
            List<User> usersEmail = db.Users.ToList();
            foreach (var item in usersEmail)
            {
                //Session["sakam"] = true;
                if (item.Email != usr.Email)
                {
                    CurrentUser.Email = usr.Email;
                }else
                {
                    CurrentUser.Email = email;
                    break;
                }


               
            }

            // CurrentUser.Id = id;
            CurrentUser.Name = usr.Name;
            if (usr.Password != null)
            {
                if (CurrentUser.Password == oldPassword && newPassword == usr.Password)
                {
                    CurrentUser.Password = Crypto.HashPassword(usr.Password);
                }
            }
            else
            {
                CurrentUser.Password = x;
            }
           
            CurrentUser.Password = usr.Surname;
            CurrentUser.TelNumber = usr.TelNumber;
            CurrentUser.ZipCode = usr.ZipCode;
           
            //CurrentUser.Email = usr.Email;
            CurrentUser.Birthday = usr.Birthday;
            CurrentUser.Address = usr.Address;
            CurrentUser.Country = usr.Country.Remove(0, 3);
            CurrentUser.City = usr.City;
            // db.Entry(CurrentUser).State = EntityState.Modified;
            db.SaveChanges();
         
            return RedirectToAction("index", new { usr = CurrentUser.Id });
        }
        public ActionResult Payment()
        {
            User usr = (User)Session["loginnedUser"];
            if (usr.Paid == true)
            {
            
                List<UsersForm> UsersForms =  db.UsersForms.Where(i => i.UserId == usr.Id).ToList();
                int? listID = UsersForms[UsersForms.Count - 1].LetterId;
                ViewBag.invitationLetter = db.Letters.FirstOrDefault(i => i.Id == listID);
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult pay(string stripeToken, string stripeEmail)
        //{
        //    var myCharge = new StripeChargeCreateOptions();
        //   User currentUser= (User)Session["loginnedUser"];
        //    // always set these properties
        //    myCharge.Amount = 10000;
        //    myCharge.Currency = "usd";

        //    myCharge.ReceiptEmail = stripeEmail;
        //    myCharge.Description = "Test Charge";
        //    myCharge.SourceTokenOrExistingSourceId = stripeToken;
        //    myCharge.Capture = true;
           
        //    var chargeService = new StripeChargeService();
        //    StripeCharge stripeCharge = chargeService.Create(myCharge);

        //    return View("Payment");
        //}




       
    }
}