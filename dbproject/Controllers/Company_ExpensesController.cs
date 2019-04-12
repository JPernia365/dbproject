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
    public class Company_ExpensesController : Controller
    {
        private qahwa db = new qahwa();

        // GET: Company_Expenses
        public ActionResult Index()
        {
            var company_Expenses = db.Company_Expenses.Include(c => c.Employee).Include(c => c.Product).Include(c => c.Supplier);
            return View(company_Expenses.ToList());
        }

        // GET: Company_Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Expenses company_Expenses = db.Company_Expenses.Find(id);
            if (company_Expenses == null)
            {
                return HttpNotFound();
            }
            return View(company_Expenses);
        }

        // GET: Company_Expenses/Create
        public ActionResult Create()
        {
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "employee_email");
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name");
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name");
            return View();
        }

        // POST: Company_Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "expenses_id,supplier_id,employee_id,product_id,cost,order_date,quantity_purchased")] Company_Expenses company_Expenses)
        {
            if (ModelState.IsValid)
            {
                db.Company_Expenses.Add(company_Expenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "employee_email", company_Expenses.employee_id);
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", company_Expenses.product_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", company_Expenses.supplier_id);
            return View(company_Expenses);
        }

        // GET: Company_Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Expenses company_Expenses = db.Company_Expenses.Find(id);
            if (company_Expenses == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "employee_email", company_Expenses.employee_id);
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", company_Expenses.product_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", company_Expenses.supplier_id);
            return View(company_Expenses);
        }

        // POST: Company_Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "expenses_id,supplier_id,employee_id,product_id,cost,order_date,quantity_purchased")] Company_Expenses company_Expenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Expenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "employee_email", company_Expenses.employee_id);
            ViewBag.product_id = new SelectList(db.Products, "product_id", "product_name", company_Expenses.product_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", company_Expenses.supplier_id);
            return View(company_Expenses);
        }

        // GET: Company_Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Expenses company_Expenses = db.Company_Expenses.Find(id);
            if (company_Expenses == null)
            {
                return HttpNotFound();
            }
            return View(company_Expenses);
        }

        // POST: Company_Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Expenses company_Expenses = db.Company_Expenses.Find(id);
            db.Company_Expenses.Remove(company_Expenses);
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
