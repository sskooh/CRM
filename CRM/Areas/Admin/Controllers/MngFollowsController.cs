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
    public class MngFollowsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/MngFollows
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
                var follows = db.Follows.Include(f => f.Agent).Include(f => f.Customer);
                return View(follows.ToList());
            };

        }

        // GET: Admin/MngFollows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follows.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            return View(follow);
        }

        // GET: Admin/MngFollows/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "RegDate");
            return View();
        }

        // POST: Admin/MngFollows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FollowID,RegDatestr,RegDateInt,RegClockstr,CustomerID,Title,AgentID,RememberJobDateStr,RememberJobDate,RememberClockstr,Description,DescriptionExpert,CustomerDescription,Ordered,Star,Status")] Follow follow)
        {
            if (ModelState.IsValid)
            {
                db.Follows.Add(follow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", follow.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "RegDate", follow.CustomerID);
            return View(follow);
        }

        // GET: Admin/MngFollows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follows.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", follow.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "RegDate", follow.CustomerID);
            return View(follow);
        }

        // POST: Admin/MngFollows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FollowID,RegDatestr,RegDateInt,RegClockstr,CustomerID,Title,AgentID,RememberJobDateStr,RememberJobDate,RememberClockstr,Description,DescriptionExpert,CustomerDescription,Ordered,Star,Status")] Follow follow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(follow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", follow.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "RegDate", follow.CustomerID);
            return View(follow);
        }

        // GET: Admin/MngFollows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follows.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            return View(follow);
        }

        // POST: Admin/MngFollows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Follow follow = db.Follows.Find(id);
            db.Follows.Remove(follow);
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
