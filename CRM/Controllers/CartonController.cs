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
    public class CartonController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Carton
        public ActionResult Index()
        {
            ViewBag.Titlesh1 = "کارتن آماده مادر از کجا بخریم؟";

            ViewBag.TitlesP = "کارتن مادر- کارتن آماده حتی تعداد کم";
            ViewBag.keywords = "کارتن مادر,کارتن آماده,جعبه آماده,خرید کارتن مادر,سفارش کارتن,کارتن آماده مادر از کجا بخریم؟";
            ViewBag.description = "جعبه سازی آیس پلاس تولید کننده انواع و اقسام سایز کارتن و جعبه آماده";
            ViewBag.UrlPage = "https://iceplusbox.com/Carton/";

            ViewBag.PictureMain = "https://iceplusbox.com/images/carton-madar.jpg";


            return View(db.Contents.ToList().Where(s=> s.BranchID == 33));
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
