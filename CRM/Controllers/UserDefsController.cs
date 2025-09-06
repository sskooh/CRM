using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class UserDefsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: UserDefs
        public ActionResult Index()
        {
            return View(db.UserDefs.ToList());
        }

        // GET: UserDefs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDef userDef = db.UserDefs.Find(id);
            if (userDef == null)
            {
                return HttpNotFound();
            }
            return View(userDef);
        }

        // GET: UserDefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserType,UserName,NewPassword,ConfirmPassword,UserRole,UserTitle,UserNameFamily,UserNationalCode,UserTel,UserMob,UserIsActive,UserDescription")] UserDef userDef)
        {
            if (ModelState.IsValid)
            {
                db.UserDefs.Add(userDef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDef);
        }

        // GET: UserDefs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDef userDef = db.UserDefs.Find(id);
            if (userDef == null)
            {
                return HttpNotFound();
            }
            return View(userDef);
        }

        // POST: UserDefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserType,UserName,NewPassword,ConfirmPassword,UserRole,UserTitle,UserNameFamily,UserNationalCode,UserTel,UserMob,UserIsActive,UserDescription")] UserDef userDef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDef);
        }

        // GET: UserDefs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDef userDef = db.UserDefs.Find(id);
            if (userDef == null)
            {
                return HttpNotFound();
            }
            return View(userDef);
        }

        // POST: UserDefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDef userDef = db.UserDefs.Find(id);
            db.UserDefs.Remove(userDef);
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
