using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dbproject;

namespace dbproject.Controllers
{
    public class Access_levelController : Controller
    {
        private qahwa db = new qahwa();

        // GET: Access_level
        public ActionResult Index()
        {
            return View(db.Access_level.ToList());
        }

        // GET: Access_level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // GET: Access_level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Access_level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "access_code,access_value")] Access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.Access_level.Add(access_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(access_level);
        }

        // GET: Access_level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: Access_level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "access_code,access_value")] Access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(access_level);
        }

        // GET: Access_level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: Access_level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Access_level access_level = db.Access_level.Find(id);
            db.Access_level.Remove(access_level);
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
