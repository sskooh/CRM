using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Areas.Admin.Models;
using CRM.Models;
using CRM.Classes;


namespace CRM.Areas.Admin.Controllers
{
    public class MngProcessesController : Controller
    {
        private CRMContext db = new CRMContext();

        // GET: Admin/MngProcesses
        public ActionResult Index()
        {
            //int lastnum;
            //try
            //{

            //    lastnum = db.Processes.Max(c => c.ProcessID) + 1;


            //    Session["ProcessIDlast"] = Convert.ToString(lastnum);
            //}
            //catch
            //{
            //    lastnum = 1;
            //}
            //var processes = db.Processes.Include(p => p.Customer).OrderByDescending(p=> p.ProcessID);
            //return View(processes.ToList());

            string NAME_FAMILY;
            NAME_FAMILY = Convert.ToString(Session["Name_family"]);

            if (NAME_FAMILY == "")
            {
                return RedirectToAction("Index", "Default", new { Area = "Login" });
        
            }
            else
            {
                var processes = db.Processes.Include(p => p.Customer).OrderByDescending(p => p.ProcessID).Where(p => p.Status == 0);
                return View(processes.ToList());
            };



        }

        public ActionResult GetAutoComplete(string term)
        {

            

            //var persons = (from Customer in this.db.Customers
            //               where term.StartsWith(term)
            //               select new
            //               {
            //                   label = Customer.NameFmily,
            //                   val = Customer.CustomerID
            //               }).Take(10).ToList();

            //return Json(persons, JsonRequestBehavior.AllowGet);


            var persons = (from Customer in this.db.Customers
                           where Customer.NameFmily.StartsWith(term)
                           select new
                           {
                               label = Customer.NameFmily,
                               val = Customer.CustomerID
                           }).Take(10).ToList();

            return Json(persons, JsonRequestBehavior.AllowGet);





        }

        public ActionResult Change_jobStatus(Process Process, string data1, string data2)
        {

            int ProsesID;


            ProsesID = Convert.ToInt32(Session["ProcessId"]);



           Process processbuy = db.Processes.FirstOrDefault(j => j.ProcessID == ProsesID);

            // finish process in Faktor
            processbuy.typeOrder = data1;
            processbuy.Title = data2;
            db.Entry(processbuy).State = EntityState.Modified;
            db.SaveChanges();

           
            return RedirectToAction("../MngProcesses/Index");
         

        }

        public JsonResult AutoCompleteCountry(string term = "")
        {
            List<Customer> lst = new List<Customer>();
           


            var result = (from r in lst
                          where r.NameFmily.ToLower().Contains(term.ToLower())
                          select new { r.NameFmily, r.CustomerID }).Distinct();

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult AutoComplete(string term)
        //{
        //    if (!String.IsNullOrEmpty(term))
        //    {
        //        var list = db.Customers.Where(c => c.NameFmily.ToUpper().Contains(term.ToUpper())).Select(c => new { Name = c.NameFmily, ID = c.CustomerID })
        //            .ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var list = db.Customers.Select(c => new { Name = c.NameFmily, ID = c.CustomerID })
        //            .ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //}



        [HttpPost]
  
        public ActionResult Index(Process process,string dateorder, string txtCustomer, string TitleOrder, string txtType)
        {


            
            var exitthis = (db.Customers.Count(x => x.NameFmily == txtCustomer));


            if (exitthis==0)
            {
                Session["messages"] = "این مشتری وجود ندارد";

            }
            else
            {
                int cid;

                cid = (db.Customers.First(x => x.NameFmily == txtCustomer).CustomerID);
                process.CustomerID = cid;

                process.Status = 0;
                process.dateOrder = 0;
                process.dateOrderStr = dateorder;
                process.Title = TitleOrder;
                process.typeOrder = txtType;


                string dt_str;
                int dt_int;

                dt_str = DateTime.Now.ToShamsi();

                dt_int = Convert.ToInt32(dt_str.Replace("/", ""));


                process.dateOrderStr = dt_str;
                process.dateOrder = dt_int;


                process.dateEnd = 0;


                process.dateEndStr = "";



                db.Processes.Add(process);
                db.SaveChanges();

            };
           
            
            


            return RedirectToAction("Index");


        }




        // GET: Admin/MngProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // GET: Admin/MngProcesses/Create
        [HttpPost]
        public ActionResult Create(int? id)
        {
            Session["CustomerID"] = id;
            if (id != null)
            {

              




                var Customerr = (db.Customers.First(x => x.CustomerID == id));


                Session["NameMoshtari"] = Customerr.NameFmily;
                Session["TelMoshtari"] = Customerr.Tel;
                Session["MobMoshtari"] = Customerr.Mob;
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NameFmily");
            return View();
        }

        // POST: Admin/MngProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProcessID,dateOrderStr,dateOrder,dateStartStr,dateStart,guessdateEndStr,guessdateEnd,dateEndStr,dateEnd,Starthour,Endhour,typeOrder,Title,CustomerID,Status")] Process process, string dtorder, string dtstart, string guessdateEnd)
        {
            //   $("#dtorder").kendoDatePicker();
            //$("#dateStart").kendoDatePicker();
            //$("#guessdateEnd").kendoDatePicker();
            //$("#dateEnd").kendoDatePicker();

            //if (ModelState.IsValid)
            //{
                int CustomerID;

                CustomerID = Convert.ToInt32(Session["CustomerID"]);

                process.CustomerID = CustomerID;

                int dtorder_int, dateStart_int, guessdateEnd_int, dateEnd_int;



                dtorder_int = Convert.ToInt32(dtorder.Replace("/", ""));
                dateStart_int = Convert.ToInt32(dtstart.Replace("/", ""));
                guessdateEnd_int = Convert.ToInt32(guessdateEnd.Replace("/", ""));

                //dateEnd_int = Convert.ToInt32(dateEnd.Replace("/", ""));

                //status = 0 شروع کار
                //start 0 , finished 1 , suspend 2 

                process.Status = 0;
                process.dateOrder = dtorder_int;
                process.dateOrderStr = dtorder;

                process.dateStart = dateStart_int;
                process.dateStartStr = dtstart;


                process.guessdateEnd = guessdateEnd_int;
                process.guessdateEndStr = guessdateEnd;

                process.dateEnd = 0;


                process.dateEndStr = "";



                db.Processes.Add(process);
                db.SaveChanges();



                return RedirectToAction("Index");

            //}

            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NameFmily", process.CustomerID);
            //return View(process);



        }

        // GET: Admin/MngProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            Session["ProcessId"]= id;
            ViewBag.ProcessId = id;

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NameFmily", process.CustomerID);
            return View(process);
        }

     

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        // POST: Admin/MngProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            int processID;
           

            Process process = db.Processes.Find(id);
            processID = process.ProcessID;


            db.Processes.Remove(process);
            db.SaveChanges();


            //var Query = (from P in db.Jobs select P).SingleOrDefault();
            //db.Jobs.Remove(Query);
            //db.SaveChanges();


            //var DeleteCatList = db.Jobs.Where();
            //db.Jobs.RemoveRange(DeleteCatList);
            //db.SaveChanges();
            //db.Jobs.Where(x => job..ToList().Contains(x.ProcessID)).ToList().ForEach(c => c.Color = dic[c.Id]);
            //Job cust = new Job();

            //cust.ProcessID = processID;

            //db.Jobs.Attach(cust);

            //db.Jobs.Remove(cust);

            //db.SaveChanges();
            string cs;

            cs = "delete from Jobs where ProcessID=" +Convert.ToString(processID);

            System.Data.SqlClient.SqlConnection con = new SqlConnection("Data Source=185.159.152.5;Database=apadaco_com_iceplusboxDB;Trusted_Connection=false;Persist Security Info=True;Connect Timeout=45;User ID=apadaco_com_iceplusUser;Password=zvB1l5#84");
            SqlCommand com = new SqlCommand(cs, con);
          
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


            return RedirectToAction("Index");
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
