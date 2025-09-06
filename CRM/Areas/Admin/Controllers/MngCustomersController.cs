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
    public class MngCustomersController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/MngCustomers
        public ActionResult Index()
        {
            string NAME_FAMILY;
            NAME_FAMILY = Convert.ToString(Session["Name_family"]);

            if (NAME_FAMILY == "")
            {



                return RedirectToAction("Index", "Defualt", new { Area = "Login" });
            }
            else
            {
                return View(db.Customers.ToList());
            };

        }

        // GET: Admin/MngCustomers/Details/5
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

        // GET: Admin/MngCustomers/Create
        public ActionResult Create()
        {
            ViewBag.DefID = new SelectList(db.Definitions.Where(s => s.IdPage == 1), "DefID", "DefTitle");

            return View();
        }

        // POST: Admin/MngCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,RegDate,RegDateInt,NameFmily,Tel,Mob,Adress,DefIDCustomer,PropertyIDCustomer,BornDate,BornDateInt,CompanyName,UserName,Password,Active,CustomerJob,CustomerPostalCode,CustomerEmail,CustomerEconomyCode,CustomerTitle,Description,CustomerFactor,CustomerRank")] Customer customer, string dtborn)
        {
            if (ModelState.IsValid)
            {

                int dt_int;

                if (dtborn == "")
                {
                    dt_int = 0;

                }
                else
                {
                    dt_int = Convert.ToInt32(dtborn.Replace("/", ""));


                }


                


                customer.BornDateInt = dt_int;
                customer.BornDate = dtborn;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        public ActionResult CreateModal()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal([Bind(Include = "CustomerID,NameFmily,Tel,Mob,BornDate,BornDateInt,CompanyName,UserName,Password,Active")] Customer customer, string dtborn)
        {
            if (ModelState.IsValid)
            {

                //int dt_int;

                //if (dtborn == "")
                //{
                //    dt_int = 0;

                //}
                //else
                //{
                //    dt_int = Convert.ToInt32(dtborn.Replace("/", ""));


                //}




                //customer.BornDateInt = dt_int;
                //customer.BornDate = dtborn;

                db.Customers.Add(customer);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return View(customer);
        }

            return View(customer);
        }

        // GET: Admin/MngCustomers/Edit/5
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
            return View(customer);
        }

        // POST: Admin/MngCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,NameFmily,Tel,Mob,BornDate,BornDateInt,CompanyName,UserName,Password,Active")] Customer customer, string dtborn)
        {
            if (ModelState.IsValid)
            {

                int dt_int;

                if (dtborn == "")
                {
                    dt_int = 0;

                }
                else
                {
                    dt_int = Convert.ToInt32(dtborn.Replace("/", ""));


                }




                customer.BornDateInt = dt_int;
                customer.BornDate = dtborn;

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Admin/MngCustomers/Delete/5
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

        // POST: Admin/MngCustomers/Delete/5
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
