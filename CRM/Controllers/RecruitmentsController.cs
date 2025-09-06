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
    public class RecruitmentsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Recruitments
        public ActionResult Index()
        {

            ViewBag.titleurladress = "Recruitments";
            ViewBag.HtmlStr = "پدیده بگ تولید ساک خرید کاغذی";
            ViewBag.TitlesP = "تولید ساک دستی ,ساک خرید کاغذی, ساک خرید گلاسه,شاپینگ بگ";
            ViewBag.keywords = "تولید ساک دستی ,ساک خرید کاغذی, ساک خرید گلاسه,شاپینگ بگ";
            ViewBag.description = "انواع ساک خرید - ساک خرید کاغذی- شاپینگ بگ و ساک خرید پارچه ای ";

            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "RecID,JobPosition,NameFamily,BornDate,Telephone,Mobile,EducationLevel,MarriedSingle,Adress")] Recruitment recruitment)
        {
            if (ModelState.IsValid)
            {
                db.Recruitments.Add(recruitment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruitment);
        }


       
  
  
    }
}
