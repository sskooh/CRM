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
    public class JobsDetailsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: AgentPanel/JobsDetails
        public ActionResult Index(int? id)
        {
            string NAME_FAMILY;
            NAME_FAMILY = Convert.ToString(Session["Name_family"]);

            if (NAME_FAMILY == "")
            {



                return RedirectToAction("Index", "Defualt", new { Area = "Login" });
            }
            else
            {

                var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType);
                return View(jobs.ToList());
            };

        }


        public ActionResult Change_jobStatus(Job job, string data1,int data2,string data3)
        {

            int JobID;


            JobID = Convert.ToInt32(Session["JobID"]);
          


            Job stockBuy = db.Jobs.FirstOrDefault(j => j.JobID == JobID);

            int status;
            status = stockBuy.Status;

            if (status == 4)
            {
                Session["messages"] = "این کار پایان یافته است ، امکان تغییر وجود ندارد";
                return RedirectToAction("../JobsDetails/Details/"+ JobID);
            }
            else {
               
           
            string dtorder;
            dtorder = DateTime.Now.ToShamsi();
            //stockBuy.FinishJobDateStr = dtorder;




            //0  هنوز کاری نشده
            //1 به کارشناس ارجاع شده
            // 2 دریافت شده
            //3 در حال انجام
            // 4 پایان

            int agentID;

            agentID = stockBuy.AgentID;
            int processid;
            processid = stockBuy.ProcessID;



            stockBuy.Status = data2;
            stockBuy.FaktorNumber = data3;


            stockBuy.DescriptionExpert = data1;


            db.Entry(stockBuy).State = EntityState.Modified;
            db.SaveChanges();


           
            if (agentID == 12 && data2==4)
            {
                Process processbuy = db.Processes.FirstOrDefault(j => j.ProcessID== processid);
                // finish process in Faktor
                processbuy.Status = 1;

                db.Entry(processbuy).State = EntityState.Modified;
                db.SaveChanges();

            };
                return RedirectToAction("../HomeAg/Index");
            };

            
        }




        // GET: AgentPanel/JobsDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int UserType;
            int IdProcess;
           

            UserType = Convert.ToInt32(Session["UserType"]);
            Session["JobID"] = id;
            Job job = db.Jobs.Find(id);
            Session["DescriptionExpert"] = job.DescriptionExpert;
            Session["FaktorNumber"] = job.FaktorNumber;
            IdProcess = job.ProcessID;

            Process pros = db.Processes.Find(IdProcess);

            Session["ProcessSteps"] = pros.ProcessSteps;
            Session["TelCustomer"] = pros.Customer.Mob;
            Session["Description"] = pros.typeOrder +" "+ pros.Title ;
            Session["TarikhOrder"] = pros.dateOrderStr;

            if (job == null)
            {

                return HttpNotFound();
            }
            return View(job);
        }

        // GET: AgentPanel/JobsDetails/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title");
            return View();
        }

        // POST: AgentPanel/JobsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Title,CustomerName,Status")] Job job)
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

        // GET: AgentPanel/JobsDetails/Edit/5
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

        // POST: AgentPanel/JobsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Title,CustomerName,Status")] Job job)
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

        // GET: AgentPanel/JobsDetails/Delete/5
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

        // POST: AgentPanel/JobsDetails/Delete/5
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
