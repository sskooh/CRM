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
    public class GlassBoxController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: GlassBox
        public ActionResult Index()
        {
            ViewBag.Titlesh1 = "جعبه پنجره ای یا جعبه طلق دار از کجا بخریم؟";

            ViewBag.TitlesP = "جعبه پنجره ای یا جعبه طلق دار از کجا بخریم؟";
            ViewBag.keywords = "جعبه طلق دار,جعبه پنجره ای,جعبه آماده طلق دار,کارتن آماده طلق دار,جعبه آماده,خرید جعبه طلق دار,سفارش جعبه پنجره دار,کارتن آماده طلق دار از کجا بخریم؟";
            ViewBag.description = "جعبه سازی آیس پلاس تولید کننده انواع و اقسام سایز جعبه پنجره ای یا جعبه طلق دار";
            ViewBag.UrlPage = "https://iceplusbox.com/GlassBox";

            ViewBag.PictureMain = "https://iceplusbox.com/images/GlassBox.jpg";

            return View(db.Contents.ToList().Where(s => s.BranchID == 38));
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
