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
    public class ProductController : Controller
    {
        private CRMContext db = new CRMContext();


        public ActionResult Index(string name)
        {

            //Job job = db.Jobs.Find(id);


            ViewBag.HtmlStr = name;
            //var stockBuys = db.Contents.Where(s => s.Title.Contains(id));

            var stockBuys = db.Contents.Where(s => s.TitleAdress==(name) && s.BranchID==2 );
            foreach (var item in stockBuys)
            {
                ViewBag.Titlesh1 = item.Title;

                ViewBag.TitlesP = item.Title;
                ViewBag.keywords = item.Title + ","+ item.Keywords;
                ViewBag.description = item.ContentStr;
                ViewBag.UrlPage = "https://padidehbags.com/Product/" + name;

                ViewBag.PictureMain = "https://padidehbags.com/img/" + item.MainPicture;
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
