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
    public class HomeController : Controller
    {
        private CRMContext db = new CRMContext();

        [HttpGet]
        public ActionResult Partial()
        {

            return View();
        }

        public ActionResult Index()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Index(string search)
        {


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
