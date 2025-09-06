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
    public class SubjectController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Subject
        public ActionResult Index(string name)
        {

            //Job job = db.Jobs.Find(id);


            ViewBag.HtmlStr = name;
            //var stockBuys = db.Contents.Where(s => s.Title.Contains(id));

            var stockBuys = db.Contents.Where(s => s.TitleAdress.Contains(name));
            foreach (var item in stockBuys)
            {

               
                ViewBag.TitlesP = item.Title+" "+ item.Keywords;
                ViewBag.keywords = item.Keywords;
                ViewBag.description = item.ContentStr;
            };

            return View(stockBuys);


      
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
