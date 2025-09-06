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
    public class CeremonyBoxController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: CeremonyBox
        public ActionResult Index()
        {
            ViewBag.Titlesh1 = "جعبه پذیرایی آماده از کجا بخریم؟";

            ViewBag.TitlesP = "جعبه پذیرایی آماده از کجا بخریم؟";
            ViewBag.keywords = " پک پذیرایی,جعبه پذیرایی مراسم,جعبه پذیرایی آماده از کجا بخریم؟";
            ViewBag.description = "جعبه سازی آیس پلاس تولید کننده انواع و اقسام سایز جعبه پذیرایی آماده ";
            ViewBag.UrlPage = "https://iceplusbox.com/CeremonyBox/";

            ViewBag.PictureMain = "https://iceplusbox.com/images/CeremonyBox.jpg";


            return View(db.Contents.ToList().Where(s => s.BranchID == 35));
        }

        // GET: CeremonyBox/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: CeremonyBox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CeremonyBox/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,LangID,BranchID,Title,TitleAdress,Title1,ContentStr,Completedescription,Completedescription1,Size,Wight,Material,Type,ProductCode,ProductSerial,DateStr,MainPicture,Pic1,AltPic1,Pic2,AltPic2,Pic3,AltPic3,Pic4,AltPic4,Pic5,AltPic5,ShowFirstPage,ViewNumber,Keywords,Branchstr,Keywords1,Keywords2,Keywords3,Keywords4,Keywords5,Video1,VideoIDaparat1,VideoDescription1,VideoTag1,Video2,VideoIDaparat2,VideoDescription2,VideoTag2")] Content content)
        {
            if (ModelState.IsValid)
            {
                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(content);
        }

        // GET: CeremonyBox/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: CeremonyBox/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,LangID,BranchID,Title,TitleAdress,Title1,ContentStr,Completedescription,Completedescription1,Size,Wight,Material,Type,ProductCode,ProductSerial,DateStr,MainPicture,Pic1,AltPic1,Pic2,AltPic2,Pic3,AltPic3,Pic4,AltPic4,Pic5,AltPic5,ShowFirstPage,ViewNumber,Keywords,Branchstr,Keywords1,Keywords2,Keywords3,Keywords4,Keywords5,Video1,VideoIDaparat1,VideoDescription1,VideoTag1,Video2,VideoIDaparat2,VideoDescription2,VideoTag2")] Content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: CeremonyBox/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: CeremonyBox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
