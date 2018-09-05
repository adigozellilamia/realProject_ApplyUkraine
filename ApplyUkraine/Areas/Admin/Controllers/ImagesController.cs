using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Models;

namespace ApplyUkraine.Areas.Admin.Controllers
{
    public class ImagesController : Controller
    {
        private ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        // GET: Admin/Images
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.About).Include(i => i.Blog).Include(i => i.University);
            return View(images.ToList());
        }

        // GET: Admin/Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Admin/Images/Create
        public ActionResult Create()
        {
            ViewBag.AboutId = new SelectList(db.Abouts, "Id", "Header");
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name");
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name");
            return View();
        }

        // POST: Admin/Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AboutId,UniversityId,BlogId")] HttpPostedFileBase file, Image image)
        {
            if (file == null)
            {
                Session["uploaderror"] = "your must select your file";
                return Content("filesec");
            }
            if (file.ContentType != "image/png" && file.ContentType != "image/jpeg" && file.ContentType != "image/gif")
            {
                Session["uploaderror"] = "your file must be jpg,png or gif";
                return Content("file");
            }
            if ((file.ContentLength / 1024) > 10024)
            {
                Session["uploaderror"] = "your file size must be max 10mb";
                return Content("olcu");
            }
            string filename = DateTime.Now.ToString("ddmmyyyyhhmmssffff") + file.FileName;
            string path = Path.Combine(Server.MapPath("~/Public/Images"), filename);

            file.SaveAs(path);
            //about.photo = filename;

            //image.Name = filename;
            //db.Images.Add(image);
            //db.descriptions.Add(dsc);

            //// var x = db.group_products.FirstOrDefault(p => p.name == prd.name);
            //product prdc = new product
            //{
            //    description_id = dsc.id,
            //    name = prd.name,
            //    image_id = img.id

            //};
            //db.products.Add(prdc);
            //db.SaveChanges();
            ////return Content(usr.id.ToString());
            //return RedirectToAction("add");

            if (ModelState.IsValid)
            {
                image.Name = filename;
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AboutId = new SelectList(db.Abouts, "Id", "Header", image.AboutId);
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", image.BlogId);
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", image.UniversityId);
            return View(image);
        }

        // GET: Admin/Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.AboutId = new SelectList(db.Abouts, "Id", "Header", image.AboutId);
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", image.BlogId);
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", image.UniversityId);
            return View(image);
        }

        // POST: Admin/Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AboutId,UniversityId,BlogId")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AboutId = new SelectList(db.Abouts, "Id", "Header", image.AboutId);
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Name", image.BlogId);
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", image.UniversityId);
            return View(image);
        }

        // GET: Admin/Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Admin/Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
