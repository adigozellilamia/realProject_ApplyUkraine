using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ApplyUkraine.Models;
using System.Data.Entity.Validation;
using Facebook;
using Newtonsoft;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace ApplyUkraine.Controllers
{
    public class LoginController : Controller
    {
        string name = "login";
        ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();
        // GET: Login
        public ActionResult Login()
        {
            
            
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User usr)
        {
            
            User loginned = db.Users.FirstOrDefault(u => u.Email == usr.Email);
            if (loginned != null)
            {

                if (Crypto.VerifyHashedPassword(loginned.Password, usr.Password))
                {
                    Session["loginnedUser"] = loginned;

                    Session["loginned"] = true;
                    Session["usrid"] = loginned.Name;
                    Session["FirstYouMustSingIn"] = null;
                    return RedirectToAction("index", "account");

                }
                Session["LoginInvalid"] = true;

            }

            return RedirectToAction("login");
        }


        public ActionResult Logout()
        {
            Session["loginned"] = null;
            return RedirectToAction("index", "home");

        }
        public ActionResult Register()
        {
            return View();


        }

        [HttpPost]
        public ActionResult SubmitRegister(User usr,string confirmPassword)
        {
            
                User newUser = new User();
                List<User> hasUsr = db.Users.ToList();
                if (usr != null)
                {
                if (confirmPassword == usr.Password)
                {
                    foreach (User item in hasUsr)
                    {
                        if (item.Email == usr.Email)
                        {

                            Session["emptyEmail"] = true;
                            return RedirectToAction("register");
                        }
                    }
                    newUser.Name = usr.Name;
                    newUser.Surname = usr.Surname;
                    newUser.Email = usr.Email;
                    newUser.StatusId = 1;
                    newUser.Password = Crypto.HashPassword(usr.Password);
                    newUser.Token = Crypto.Hash(usr.Email + DateTime.Now.ToString("yyyyMMddHHmmss"), "sha256");
                    newUser.Address = null;
                    //newUser.ApplicationFormId = null;
                    newUser.Birthday = null;
                    newUser.City = null;
                    newUser.Country = null;
                    newUser.TelNumber = null;
                    newUser.ZipCode = null;
                    SendConfirmEmail(newUser.Email, newUser.Token);
                    db.Users.Add(newUser);

                    db.SaveChanges();
              
                    Session["loginned"] = true;
                    Session["emptyEmail"] = null;
                    Session["loginnedUser"] = newUser;
                    return RedirectToAction("index", "account");
                }else
                {
                    return RedirectToAction("register");
                }
               

                   
                   
                }
                return RedirectToAction("register");

            
           
        }
        private Uri RediredUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("facebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "2049319091767986",
                client_secret= "3e6bc458eedb9cea18f8446fed5505e3",
                redirect_uri= RediredUri.AbsoluteUri,
                response_type="code",
                scope="email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();

   
            dynamic result = fb.Post("oauth/access_token", new {
                client_id = "2049319091767986",
                client_secret = "3e6bc458eedb9cea18f8446fed5505e3",
                redirect_uri = RediredUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,id,first_name,last_name,email");
        
            string email = me.email;
            string firstname = me.first_name;
            string lastname = me.last_name;
            string facebookId = me.id;
            var usr = db.Users.ToList();
            bool isHave = false;
            foreach(User item in usr)
            {
                if (item.facebookId == facebookId)
                {

                    isHave = true;
                }
                else
                {
                    isHave = false;
                }
            }
            if(isHave==true)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                Session["facebookLogin"] = true;
                Session["loginned"] = true;
                User user = db.Users.First(p => p.facebookId == facebookId);
                Session["loginnedUser"] = user;
                return RedirectToAction("index", "account");
            }
            else
            {
                User user = new User();
                user.facebookId = facebookId;
                Session["loginned"] = true;
                user.Email = email;
                user.Name = firstname;
                user.Surname = lastname;
                user.StatusId = 1;
                Session["facebookLogin"] = true;
                db.Users.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("index", "account", new { usr = user.Id });
            }
        }
        public ActionResult loginwithfacebook(string email,
        string firstname ,
        string lastname )
        {
            ViewBag.email = email;
            ViewBag.firstname = firstname;
            ViewBag.lastname = lastname;
            return View();
        }
        public ActionResult SubmitRegisterFacebook()
        {
            return Content("salam");
        }
       
        [HttpPost]
        public ActionResult GoogleLogin(string email, string name, string gender, string lastname, string location)
        {
            User adam = new User();
            adam.Name = name;
            adam.Email = email;
            adam.Surname = lastname;
            db.Users.Add(adam);
            db.SaveChanges();
            return RedirectToAction("login");
        }
        private bool SendConfirmEmail(string email, string token)
        {
            var body = "<p>ApplyUkraine.com Xos geldiniz: üzvlüyünüzü təsdiql?m?k üçün <a href='http://localhost:50538/Login/Confirm?token=" + token + "'>tiklayin</a></p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("no-reply@devita.az");  // replace with valid value
            message.Subject = "Üzvlüyünüzü təsdiq";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "elcnaghyv@gmail.com",  // replace with valid value
                    Password = "elcin238"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                return true;
            }
        }

        public ActionResult Confirm(string token)
        {
            if (token == null)
            {
                return HttpNotFound();
            }
            User usr = db.Users.FirstOrDefault(u => u.Token == token);
            Session["userId"] = usr.Id;
            if (usr == null)
            {
                return HttpNotFound();
            }
            if (usr.IsConfirm == true)
            {
                return HttpNotFound();
            }
            usr.IsConfirm = true;
            db.SaveChanges();
            Session["loginned"] = true;
            Session["UserConfirmed"] = true;
            Session["FirstYouMustSingIn"] = null;
            Session["loginnedUser"] = usr;
            return RedirectToAction("index", "home");
        }

        public ActionResult Reset()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SendConfirmMail(string Email)
        {
            User usr = db.Users.FirstOrDefault(u => u.Email == Email);
            if (usr == null)
            {
                Session["NonExistEmail"] = "There is not any account for this email";
            }
            else
            {

                Session["ExistEmail"] = true;
                usr.ForgotToken = Crypto.Hash(usr.Email + DateTime.Now.ToString("yyyyMMddHHmmss"), "sha256");
                db.SaveChanges();
                SendForgetEmail(usr.Email, usr.ForgotToken);
                Session["message"] = "We sent e - mail to you.Please check your e-mail inbox or e - mail spam";

            }

            return RedirectToAction("Reset");
        }
        private bool SendForgetEmail(string email, string token)
        {
            var body = "<p>Please click this link to change your password: <a href='http://localhost:50538/login/ChangePassword?token=" + token + "'>Click</a></p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("no-reply@ukraine.az");  // replace with valid value
            message.Subject = "Sifr? sifirlamasi";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "elcnaghyv@gmail.com",  // replace with valid value
                    Password = "elcin238"  // replace with valid value-Detiva-Password-@pww({Kf2wfy@AL7
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                //smtp.Host = "smtp.live.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                return true;
            }
        }

        public ActionResult ChangePassword(string token)
        {
            if (token == null)
            {
                return HttpNotFound();
            }
            User usr = db.Users.FirstOrDefault(u => u.ForgotToken == token);

            if (usr == null)
            {
                return HttpNotFound();
            }

            return View(model: token);
        }


        [HttpPost]
        public ActionResult ChangePassword(string token, string password, string confirmPassword)
        {

            User usr = db.Users.FirstOrDefault(u => u.ForgotToken == token);
            Session["userId"] = usr.Id;

            if (usr == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (password == confirmPassword)
                {
                    usr.Password = Crypto.HashPassword(password);
                    usr.ForgotToken = null;
                    db.SaveChanges();
                    Session["ChangeSuccess"] = "Sizin sifr?niz yenil?ndi";
                    return RedirectToAction("login");
                }
                else
                {
                    Session["DifferentPas"] = "Passwords are not same";
                    return RedirectToAction("ChangePassword");
                }
            }
        }
        

    }
}