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
    public class AboutUsController : Controller
    {
        private CRMContext db = new CRMContext();

        public ActionResult Index()
        {
            ViewBag.titleurladress = "AboutUs";
            ViewBag.HtmlStr = "ساک خرید در پدیده بگ";
            ViewBag.TitlesP = "ساک خرید گلاسه - حداقل 50 عدد- پدیده بگ";
            ViewBag.keywords = "قیمت ساک دستی گلاسه,قیمت ساک دستی  پارچه ای دوختی";
            ViewBag.description = "قیمت ساک دستی گلاسه,قیمت ساک دستی  پارچه ای دوختی";


            return View();
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
