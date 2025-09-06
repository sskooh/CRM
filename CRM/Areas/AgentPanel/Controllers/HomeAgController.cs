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
using CRM.Classes;

namespace CRM.Areas.AgentPanel.Controllers
{
    public class HomeAgController : Controller
    {
        private CRMContext db = new CRMContext();


        public ActionResult Finish_job(Job job, int data1)
        {
            int UserType;
            UserType = 0;

            UserType = Convert.ToInt32(Session["UserType"]);



            Job stockBuy = db.Jobs.FirstOrDefault(j=> j.JobID == data1);
            //db.Jobs.Remove(stockBuy);
            //db.SaveChanges();



            int dt_int;
            string dtorder;
            dtorder = DateTime.Now.ToShamsi();
            stockBuy.FinishJobDateStr = dtorder;

            if (dtorder == "")
            {
                dt_int = 0;

            }
            else
            {
                dt_int = Convert.ToInt32(dtorder.Replace("/", ""));


            }


            //0  هنوز کاری نشده
            //1 به کارشناس ارجاع شده
            // 2 تمام شده
            stockBuy.Status = 3;

            stockBuy.FinishJobDate = dt_int;




            db.Entry(stockBuy).State = EntityState.Modified;
            db.SaveChanges();


            //var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.AgentID == UserType && j.Status == 1);
            return RedirectToAction("Index");
        }


            // GET: AgentPanel/HomeAg
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
                Session["Memorytedad"] = 10;
                Session["Msgtedad"] = 5;


                int UserType;
                UserType = 0;

                UserType = Convert.ToInt32(Session["UserType"]);

                var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.AgentID == UserType && j.Status != 4).OrderByDescending(p => p.ProcessID);
                return View(jobs.ToList());

            };

        }

        // GET: AgentPanel/HomeAg/Details/5
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

        // GET: AgentPanel/HomeAg/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title");
            return View();
        }

        // POST: AgentPanel/HomeAg/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // GET: AgentPanel/HomeAg/Edit/5
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

        // POST: AgentPanel/HomeAg/Edit/5
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

        // GET: AgentPanel/HomeAg/Delete/5
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

        // POST: AgentPanel/HomeAg/Delete/5
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
