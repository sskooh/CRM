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
    public class ContactUsController : Controller
    {
        private CRMContext db = new CRMContext();

      
        public ActionResult Index()
        {
            ViewBag.titleurladress = "ContactUs";
            ViewBag.HtmlStr = "جعبه سازی آیس پلاس - جعبه آماده فوری";
            ViewBag.TitlesP = "جعبه سازی آیس پلاس - جعبه آماده فوری";
            ViewBag.keywords = "آیس پلاس تولید کننده جعبه فوری, جعبه مقوایی, جعبه مزون, جعبه لباس, جعبه لباس عروس, پک پذیرایی, پک ختم, جعبه آماده وهارد باکس";
            ViewBag.description = "آیس پلاس تولید کننده جعبه فوری،جعبه مقوایی،جعبه مزون،جعبه لباس،جعبه لباس عروس،پک پذیرایی،پک ختم،جعبه آماده وهارد باکس با سابقه ده ساله در خدمت شماست";


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ContactID,NameFamily,Telephone,Mobile,Description")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactUs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactUs);
        }


        // POST: ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ContactID,NameFamily,Telephone,Mobile,Description")] ContactUs contactUs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ContactUs.Add(contactUs);
        //        db.SaveChanges();
        //        return RedirectToAction("Create");
        //    }

        //    return View(contactUs);
        //}

        // GET: ContactUs/Edit/5
      

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,NameFamily,Telephone,Mobile,Description")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactUs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactUs);
        }

        // GET: ContactUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = db.ContactUs.Find(id);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            return View(contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactUs contactUs = db.ContactUs.Find(id);
            db.ContactUs.Remove(contactUs);
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
