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
    public class Order_detailsController : Controller
    {
        private qahwa db = new qahwa();

        // GET: Order_details
        public ActionResult Index()
        {
            var order_details = db.Order_details.Include(o => o.Product);
            return View(order_details.ToList());
        }

        // GET: Order_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // GET: Order_details/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name");
            return View();
        }

        // POST: Order_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,product_id,quantity,discount,invoice_id")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Order_details.Add(order_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", order_details.product_id);
            return View(order_details);
        }

        // GET: Order_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", order_details.product_id);
            return View(order_details);
        }

        // POST: Order_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,product_id,quantity,discount,invoice_id")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", order_details.product_id);
            return View(order_details);
        }

        // GET: Order_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // POST: Order_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_details order_details = db.Order_details.Find(id);
            db.Order_details.Remove(order_details);
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
