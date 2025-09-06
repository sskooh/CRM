using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Areas.Admin.Models;
using CRM.Models;

namespace CRM.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Definition).Include(c => c.Property);
            return View(customers.ToList());
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            ViewBag.DefID = new SelectList(db.Definitions, "DefID", "DefTitle");
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyName");
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,RegDate,RegDateInt,NameFmily,Tel,Mob,Adress,DefID,PropertyID,BornDate,BornDateInt,CompanyName,UserName,Password,Active,CustomerJob,CustomerPostalCode,CustomerEmail,CustomerEconomyCode,CustomerTitle,Description,CustomerFactor,CustomerRank")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DefID = new SelectList(db.Definitions, "DefID", "DefTitle", customer.DefID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyName", customer.PropertyID);
            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DefID = new SelectList(db.Definitions, "DefID", "DefTitle", customer.DefID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyName", customer.PropertyID);
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,RegDate,RegDateInt,NameFmily,Tel,Mob,Adress,DefID,PropertyID,BornDate,BornDateInt,CompanyName,UserName,Password,Active,CustomerJob,CustomerPostalCode,CustomerEmail,CustomerEconomyCode,CustomerTitle,Description,CustomerFactor,CustomerRank")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DefID = new SelectList(db.Definitions, "DefID", "DefTitle", customer.DefID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyName", customer.PropertyID);
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
