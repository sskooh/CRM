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
    public class ContentsController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Contents
        public ActionResult Index(string name)
        {

          

            switch (name)
            {



                case null:
                    ViewBag.HtmlStr = "پدیده بگ-ساک خرید آماده";
                    ViewBag.TitlesP = "ساک خرید";
                    ViewBag.keywords = "شاپینگ بگ";
                    ViewBag.description = " ساک خرید";

                    ViewBag.matlab = 0;
                    var stockBuys = db.Contents.Where(s => s.BranchID == 1);
                    return View(stockBuys.ToList());

                case "Catalog":
                    ViewBag.titleurladress = "Catalog";

                    return View("../Catalog/index");

                case "Recruitments":
                    ViewBag.titleurladress = "Recruitments";

                    return View("../Recruitments/index");

                case "Product":

                    ViewBag.titleurladress = "Product";
                    return View("../Product/index");

                case "Blog":

                    ViewBag.HtmlStr = "پدیده بگ-ساک خرید آماده";
                    ViewBag.TitlesP = "ساک خرید کاغذی آماده-پدیده بگ";
                    ViewBag.keywords = "ساک خرید کاغذی-ساک خرید گلاسه-ساک خرید پارچه ای-تولید انواع ساک خرید-ساک خرید آماده فوری-شاپینگ بگ";
                    ViewBag.description = "تولید انواع ساک خرید کاغذی پارچه ای گلاسه و کرافت در پدیده بگ - آماده و تحویل فوری با حداقل تیراژ";
                    ViewBag.matlab = 2;
                    ViewBag.titleurladress = "Blog";

                    ViewBag.HtmlStr = "پدیده بگ";
                    stockBuys = db.Contents.Where(s => s.BranchID == 2);
                    return View(stockBuys.ToList());


                case "FAQ":
                    ViewBag.titleurladress = "FAQ";
                    return View("../FAQ/index");

                case "ContactUs":

                    ViewBag.titleurladress = "ContactUs";
                    return View("../ContactUs/index");

                case "AboutUs":

                    ViewBag.titleurladress = "AboutUs";
                    return View("../AboutUs/index");
                case "AllProduct":

                    ViewBag.TitlesP = "پدیده بگ, ";
                    ViewBag.keywords = "ساک دستی , خرید ساك دستي گلاسه اختصاصی";
                    ViewBag.description = "پدیده بگ تولید کننده-ساک دستی گلاسه";
                    ViewBag.titleurladress = "AllProduct";
                    ViewBag.matlab = 0;

                    ViewBag.HtmlStr = "پدیده بگ";
                    stockBuys = db.Contents.Where(s => s.BranchID == 1);
                    return View(stockBuys.ToList());

                case "Articles":

                    ViewBag.titleurladress = "Articles";

                    ViewBag.TitlesP = "پدیده بگ";
                    ViewBag.keywords = " ساک دستی ";
                    ViewBag.description = "پدیده بگ ";

                    ViewBag.matlab = 0;

                    ViewBag.HtmlStr = "پدیده بگ";
                    stockBuys = db.Contents.Where(s => s.BranchID == 2);
                    return View(stockBuys.ToList());



                default:

                    name = name.Trim();

                    string keywords_n, keywords_n_keyword;






                    ViewBag.HtmlStr = name;

                    stockBuys = db.Contents.Where(s => s.AltPic5.Contains(name) && s.BranchID == 1);

                    var stockBuys2 = db.Contents.Where(s => s.TitleAdress==name && s.BranchID == 2).Count();


                    if (stockBuys2 == 0)
                    {
                        keywords_n = "پدیده بگ -تولید ساک خرید کاغذی دستی" + " " + name;

                        keywords_n_keyword = keywords_n;
                        ViewBag.matlab = 0;

                        ViewBag.TitlesP = name;
                        ViewBag.keywords = keywords_n_keyword;
                        ViewBag.description = keywords_n;

                        var stockBuys3 = db.Contents.Where(s => s.AltPic5.Contains(name) && s.BranchID == 1).Count();
                        if (stockBuys3 == 0)

                        {
                            //stockBuys = db.Contents.Where(s => s.BranchID == 1);
                            //return View(stockBuys.ToList());
                        }
                        else
                        {
                           
                         
                            stockBuys = db.Contents.Where(s => s.AltPic5.Contains(name) && s.BranchID == 1);
                            return View(stockBuys.ToList());
                        }

                    }
                    else
                    {
                        ViewBag.matlab = 1;

                        var stockBuys3 = db.Contents.First(s => s.TitleAdress==name && s.BranchID == 2);
                        keywords_n = stockBuys3.ContentStr;
                        ViewBag.MainPicture = stockBuys3.MainPicture;
                        ViewBag.Keywords = stockBuys3.Keywords;
                        keywords_n_keyword = stockBuys3.Keywords;
                        ViewBag.TitlesP = stockBuys3.Title;
                        ViewBag.description = stockBuys3.ContentStr;
                        ViewBag.Branchstr = stockBuys3.Branchstr;
                        ViewBag.titleurladress = stockBuys3.TitleAdress;

                        ViewBag.Branchstr = stockBuys3.Branchstr;
                        ViewBag.ContentStr = stockBuys3.ContentStr;
                        ViewBag.Titlemain = stockBuys3.Title;
                        ViewBag.Title1 = stockBuys3.Title1;
                        ViewBag.Pic1 = stockBuys3.Pic1;
                        ViewBag.AltPic1 = stockBuys3.AltPic1;
                        ViewBag.Pic2 = stockBuys3.Pic2;
                        ViewBag.AltPic2 = stockBuys3.AltPic2;
                        ViewBag.Pic3 = stockBuys3.Pic3;
                        ViewBag.AltPic3 = stockBuys3.AltPic3;
                        ViewBag.Pic4 = stockBuys3.Pic4;
                        ViewBag.AltPic4 = stockBuys3.AltPic4;

                        ViewBag.Pic5 = stockBuys3.Pic5;
                        ViewBag.AltPic5 = stockBuys3.AltPic5;

                        ViewBag.Completedescription = stockBuys3.Completedescription;
                        ViewBag.Completedescription1 = stockBuys3.Completedescription1;
                        ViewBag.Keywords1 = stockBuys3.Keywords1;
                        ViewBag.Keywords2 = stockBuys3.Keywords2;
                        ViewBag.Keywords3 = stockBuys3.Keywords3;
                        ViewBag.Keywords4 = stockBuys3.Keywords4;
                        ViewBag.Keywords5 = stockBuys3.Keywords5;

                        ViewBag.VideoIDaparat1 = stockBuys3.VideoIDaparat1;
                        ViewBag.VideoTag1 = stockBuys3.VideoTag1;
                        ViewBag.VideoIDaparat2 = stockBuys3.VideoIDaparat2;
                        ViewBag.VideoTag2 = stockBuys3.VideoTag2;
                        ViewBag.VideoDescription1 = stockBuys3.VideoDescription1;

                        ViewBag.VideoDescription2 = stockBuys3.VideoDescription2;
                        ViewBag.Video1 = stockBuys3.Video1;
                        ViewBag.Video2 = stockBuys3.Video2;



                    }







                    return View(stockBuys.ToList());
            };









  
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
