using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplyUkraine.Filter;
using ApplyUkraine.Models;

namespace ApplyUkraine.Areas.Admin.Controllers
{
    public class DescriptionsController : Controller
    {
        private ApplyUkraineDBEntities db = new ApplyUkraineDBEntities();

        // GET: Admin/Descriptions
        [auth]
        public ActionResult Index()
        {
            var descriptions = db.Descriptions.Include(d => d.University);
            return View(descriptions.ToList());
        }

        // GET: Admin/Descriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // GET: Admin/Descriptions/Create
        public ActionResult Create()
        {
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name");
            return View();
        }

        // POST: Admin/Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Text,UniversityId")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Descriptions.Add(description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", description.UniversityId);
            return View(description);
        }

        // GET: Admin/Descriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", description.UniversityId);
            return View(description);
        }

        // POST: Admin/Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Text,UniversityId")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", description.UniversityId);
            return View(description);
        }

        // GET: Admin/Descriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Admin/Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Description description = db.Descriptions.Find(id);
            db.Descriptions.Remove(description);
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
