using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Areas.Admin.Models;
using CRM.Models;

namespace CRM.Areas.Login.Controllers
{
    public class DefualtController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Login/Defualt
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                //string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(lvm.Password, "MD5");
                var u = db.UserDefs.FirstOrDefault(a => a.UserName == UserName && a.NewPassword == Password);
                if (u != null)
                {

                    if (u.UserIsActive == true)
                    {

                        Session["id_user"] = u.UserId;
                        //Session["id_WorkHouse"] = u.WorkhouseId;
                        Session["Name_family"] = u.UserTitle + " " + u.UserNameFamily;
                        ViewBag.NameFamily = Session["Name_family"];

                        if (u.UserRole == 1)
                        {
                            return RedirectToAction("Index", "Default", new { Area = "Admin" });
                        }
                        else if (u.UserRole == 2)
                        {

                            Session["UserType"] = u.UserType;
                            return RedirectToAction("Index", "HomeAg", new { Area = "AgentPanel" });
                        }
                        else if (u.UserRole == 3)
                        {
                            return RedirectToAction("Index", "MngProcesses");
                        }
                        else
                        {
                            ModelState.AddModelError("UserName", "کاربر با این نقش معرفی نشده است");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "این کاربر فعال نشده است");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است");
                    return RedirectToAction("Index");

                }


            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری یافت نشد");
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        //{

        //    return RedirectToAction("Index", "Default", new { Area = "Admin" });


        //}



    }
}
