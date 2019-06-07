using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KendoTesting.Models;

namespace KendoTesting.Controllers
{
    public class RangGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RangGroups
        public ActionResult Index()
        {
            return View(db.RangGroups.ToList());
        }

        // GET: RangGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangGroup rangGroup = db.RangGroups.Find(id);
            if (rangGroup == null)
            {
                return HttpNotFound();
            }
            return View(rangGroup);
        }

        // GET: RangGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RangGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RangGroup rangGroup)
        {
            if (ModelState.IsValid)
            {
                db.RangGroups.Add(rangGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rangGroup);
        }

        // GET: RangGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangGroup rangGroup = db.RangGroups.Find(id);
            if (rangGroup == null)
            {
                return HttpNotFound();
            }
            return View(rangGroup);
        }

        // POST: RangGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RangGroup rangGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rangGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rangGroup);
        }

        // GET: RangGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangGroup rangGroup = db.RangGroups.Find(id);
            if (rangGroup == null)
            {
                return HttpNotFound();
            }
            return View(rangGroup);
        }

        // POST: RangGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RangGroup rangGroup = db.RangGroups.Find(id);
            db.RangGroups.Remove(rangGroup);
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
