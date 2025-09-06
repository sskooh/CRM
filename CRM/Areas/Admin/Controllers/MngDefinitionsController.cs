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
    public class MngDefinitionsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/MngDefinitions
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
                return View(db.Definitions.ToList());
            };

        }

        // GET: Admin/MngDefinitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        // GET: Admin/MngDefinitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MngDefinitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DefID,DefTitle,IdPage")] Definition definition)
        {
            if (ModelState.IsValid)
            {
                db.Definitions.Add(definition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(definition);
        }

        // GET: Admin/MngDefinitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        // POST: Admin/MngDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DefID,DefTitle,IdPage")] Definition definition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(definition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(definition);
        }

        // GET: Admin/MngDefinitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        // POST: Admin/MngDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Definition definition = db.Definitions.Find(id);
            db.Definitions.Remove(definition);
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
