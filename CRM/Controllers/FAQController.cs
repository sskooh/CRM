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
    public class FAQController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: FAQ
        public ActionResult Index()
        {
            ViewBag.titleurladress = "FAQ";
            ViewBag.HtmlStr = "جعبه آماده در جعبه سازی آیس پلاس";
            ViewBag.TitlesP = "جعبه آماده - حداقل 50 عدد- آیس پلاس";
            ViewBag.keywords = "آیس پلاس تولید کننده جعبه فوری, جعبه مقوایی, جعبه مزون, جعبه لباس, جعبه لباس عروس, پک پذیرایی, پک ختم, جعبه آماده وهارد باکس";
            ViewBag.description = "آیس پلاس تولید کننده جعبه فوری آماده،جعبه مقوایی،جعبه مزون،جعبه لباس،جعبه لباس عروس،پک پذیرایی،پک ختم،جعبه آماده وهارد باکس با سابقه ده ساله در خدمت شماست";


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
