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
    public class Product1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product1
        public ActionResult Index()
        {
            var product1 = db.Product1s.Include(p => p.Group).Include(p => p.RangGroup);
            return View(product1.ToList());
        }

        // GET: Product1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // GET: Product1/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.RangGroupId = new SelectList(db.RangGroups, "Id", "Name");
            return View();
        }

        // POST: Product1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,GroupId,RangGroupId")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Product1s.Add(product1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product1.GroupId);
            ViewBag.RangGroupId = new SelectList(db.RangGroups, "Id", "Name", product1.RangGroupId);
            return View(product1);
        }

        // GET: Product1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product1.GroupId);
            ViewBag.RangGroupId = new SelectList(db.RangGroups, "Id", "Name", product1.RangGroupId);
            return View(product1);
        }

        // POST: Product1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GroupId,RangGroupId")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", product1.GroupId);
            ViewBag.RangGroupId = new SelectList(db.RangGroups, "Id", "Name", product1.RangGroupId);
            return View(product1);
        }

        // GET: Product1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product1 product1 = db.Product1s.Find(id);
            db.Product1s.Remove(product1);
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
