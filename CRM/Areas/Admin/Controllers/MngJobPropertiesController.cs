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
    public class MngJobPropertiesController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/MngJobProperties
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

                var jobProperties = db.JobProperties.Include(j => j.Job);
                return View(jobProperties.ToList());
            };

        }

        // GET: Admin/MngJobProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProperty jobProperty = db.JobProperties.Find(id);
            if (jobProperty == null)
            {
                return HttpNotFound();
            }
            return View(jobProperty);
        }

        // GET: Admin/MngJobProperties/Create
        public ActionResult Create()
        {
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "StartJobDateStr");
            return View();
        }

        // POST: Admin/MngJobProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobPropertyID,JobID,Description")] JobProperty jobProperty)
        {
            if (ModelState.IsValid)
            {
                db.JobProperties.Add(jobProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "StartJobDateStr", jobProperty.JobID);
            return View(jobProperty);
        }

        // GET: Admin/MngJobProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProperty jobProperty = db.JobProperties.Find(id);
            if (jobProperty == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "StartJobDateStr", jobProperty.JobID);
            return View(jobProperty);
        }

        // POST: Admin/MngJobProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobPropertyID,JobID,Description")] JobProperty jobProperty)
        {
            if (ModelState.IsValid)
            {
              


                db.Entry(jobProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "StartJobDateStr", jobProperty.JobID);
            return View(jobProperty);
        }

        // GET: Admin/MngJobProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProperty jobProperty = db.JobProperties.Find(id);
            if (jobProperty == null)
            {
                return HttpNotFound();
            }
            return View(jobProperty);
        }

        // POST: Admin/MngJobProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobProperty jobProperty = db.JobProperties.Find(id);
            db.JobProperties.Remove(jobProperty);
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
