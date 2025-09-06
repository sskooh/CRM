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
    public class Jobs12Controller : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/Jobs12
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType);
            return View(jobs.ToList());
        }

        // GET: Admin/Jobs12/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Admin/Jobs12/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title");
            return View();
        }

        // POST: Admin/Jobs12/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return View(job);
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // GET: Admin/Jobs12/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // POST: Admin/Jobs12/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // GET: Admin/Jobs12/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Admin/Jobs12/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
