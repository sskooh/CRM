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

using CRM.Classes;


namespace CRM.Areas.Admin.Controllers
{
    public class MngJobsController : Controller
    {
        private CRMContext db = new CRMContext();


        public ActionResult NXT()
        {
            int processid;

            int processidNXT;

            //var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.Status != 4).OrderByDescending(j => j.ProcessID);

            processid = Convert.ToInt32(Session["ProcessID"]);
           

           
           
            var countl = (db.Processes.Count(x => x.ProcessID < processid && x.Status == 0));
            if (countl == 0)
            {
                processidNXT = processid;

            }
            else
            {
                var exitthis = (db.Processes.Where(x => x.ProcessID < processid && x.Status == 0));
                processidNXT = exitthis.Max(x => x.ProcessID);
            }

            string path_str;

            path_str = "../MngJobs/Index/" + Convert.ToString(processidNXT);

            return RedirectToAction(path_str);


        }

        public ActionResult PRV()
        {
            int processid;

            int processidNXT;

            //var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.Status != 4).OrderByDescending(j => j.ProcessID);

            processid = Convert.ToInt32(Session["ProcessID"]);




            var countl = (db.Processes.Count(x => x.ProcessID > processid && x.Status == 0));
            if (countl == 0)
            {
                processidNXT = processid;

            }
            else
            {
                var exitthis = (db.Processes.Where(x => x.ProcessID > processid && x.Status == 0));
                processidNXT = exitthis.Min(x => x.ProcessID);
            }

            string path_str;

            path_str = "../MngJobs/Index/" + Convert.ToString(processidNXT);

            return RedirectToAction(path_str);


        }

        public ActionResult add_job(Job job, string data1, int data2)
        {
            int processid;


            processid = Convert.ToInt32(Session["ProcessID"]);

            if (data1 == "")
            {
                Session["msgInkarmojodAst"] = "دستور کار را وارد کنید";
            }
            else
            {



                var find_foroshgah = db.Jobs.FirstOrDefault(x => x.OrderTypeID == data2 && x.ProcessID == processid);
                if (find_foroshgah != null)
                {
                    Session["msgInkarmojodAst"] = "این کار قبلا ثبت شده است";

                }
                else
                {
                    Session["msgInkarmojodAst"] = null;
                    if (ModelState.IsValid)
                    {

                        int customerID;

                        var Processi = (db.Processes.First(x => x.ProcessID == processid));
                        customerID = Processi.CustomerID;


                        var customeri = (db.Customers.First(x => x.CustomerID == customerID));

                      



                        job.CustomerName= customeri.NameFmily;
                        job.CustomerIDjob = customeri.CustomerID;
                        job.Title = Processi.Title;




                        job.ProcessID = processid;

                        int dt_int;
                        string dtorder;
                        dtorder = DateTime.Now.ToShamsi();

                        if (dtorder == "")
                        {
                            dt_int = 0;

                        }
                        else
                        {
                            dt_int = Convert.ToInt32(dtorder.Replace("/", ""));


                        }
                        job.ProcessID = processid;

                        //0  هنوز کاری نشده
                        //1 به کارشناس ارجاع شده
                        //2 تمام شده
                        job.Status = 1;

                        job.StartJobDate = dt_int;
                        job.StartJobDateStr = dtorder;
                        job.AgentID = data2;
                        job.Description = data1;
                        job.OrderTypeID = data2;


                        db.Jobs.Add(job);
                        db.SaveChanges();



                        var find_process = db.Processes.FirstOrDefault(x => x.ProcessID == processid);
                        string ss;
                        string add_ss;
                        ss = find_process.ProcessSteps;

                        add_ss = "";

                        if (data2==1)
                        {
                            add_ss = " طراحی ";
                        };
                        if (data2 == 2)
                        {
                            add_ss = " ليتو گرافی ";
                        };
                        if (data2 == 3)
                        {
                            add_ss = " کاغذ فروش ";
                        };
                        if (data2 == 4)
                        {
                            add_ss = " چاپخانه ";
                        };
                        if (data2 == 5)
                        {
                            add_ss = " یو وی ";
                        };
                        if (data2 == 6)
                        {
                            add_ss = " سلفون  ";
                        };
                        if (data2 == 7)
                        {
                            add_ss = " لتر و چسب ";
                        };
                        if (data2 == 8)
                        {
                            add_ss = " کارتن سازی ";
                        };

                        if (data2 == 9)
                        {
                            add_ss = " کارگاه آلارد ";
                        };
                        if (data2 == 10)
                        {
                            add_ss = " فرم عمومی ";
                        };
                        if (data2 == 11)
                        {
                            add_ss = " ارسال ";
                        };
                        if (data2 == 12)
                        {
                            add_ss = " فاکتور ";
                        };

                        if (data2 == 13)
                        {
                            add_ss = " قالب سازی ";
                        };
                        if (data2 == 14)
                        {
                            add_ss = " متفرقه ";
                        };

                        if (data2 == 15)
                        {
                            add_ss = " لیزر ";
                        };
                        find_process.ProcessSteps = ss+ add_ss;

                        db.Entry(find_process).State = EntityState.Modified;
                        db.SaveChanges();


                    }

                }
            }
            string path_str;

            path_str = "../MngJobs/Index/" + Convert.ToString(processid);

            return RedirectToAction(path_str);

         


        }




     

        public ActionResult Delete_job(Job job, int data1)
        {
            int processid;


            processid = Convert.ToInt32(Session["ProcessID"]);

          



                var find_foroshgah = db.Jobs.FirstOrDefault(x => x.OrderTypeID == data1 && x.ProcessID == processid);
                if (find_foroshgah == null)
                {
                    Session["msgInkarmojodAst"] = "این کار وجود ندارد عسیسم";

                }
                else
                {
                    Session["msgInkarmojodAst"] = null;
                    if (ModelState.IsValid)
                    {




                  
                    db.Jobs.Remove(find_foroshgah);
                    db.SaveChanges();





                    }

                }
           
            string path_str;

            path_str = "../MngJobs/Index/" + Convert.ToString(processid);

            return RedirectToAction(path_str);




        }

        public ActionResult ShowRep(int? id)
        {
          if (id==0)
            {
                var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.Status != 4 ).OrderByDescending(j => j.ProcessID);



                return View(jobs.ToList());
            }
            else
            {
                var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.Status != 4 && j.OrderTypeID == id).OrderByDescending(j => j.ProcessID);



                return View(jobs.ToList());
            };
               
      
     

           
        }
        //public ActionResult PRV()

        //{
        //    int id;
        //    id=Convert.ToInt32(Session["ProcessID"]);
        //    return View();

        //}

        //public ActionResult NXT()

        //{
        //    int id;
        //    id = Convert.ToInt32(Session["ProcessID"]);
        //    return View();

        //}

        // GET: Admin/MngJobs
        public ActionResult Index(int? id)
        {
            string NAME_FAMILY;
            NAME_FAMILY = Convert.ToString(Session["Name_family"]);

            if (NAME_FAMILY == "")
            {



                return RedirectToAction("Index", "Defualt", new { Area = "Login" });
            }
            else
            {
                Session["IDprv"] = id - 1;
                Session["IDnxt"] = id + 1;

                Session["ProcessID"] = id;
                if (id != null)
                {
                    //Job job = (db.Jobs.First(x => x.ProcessID == id));
                    //if (job == null)
                    //{
                    //    return HttpNotFound();
                    //}
                    //else
                    //{




                    var Tarahi = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 1 && x.ProcessID == id);
                    if (Tarahi != null)
                    {

                        Session["MsgTarahi"] = "";
                        Session["mojodin"] = 0;

                        Session["MsgTarahi"] = Tarahi.Description;
                        Session["TarikhTarahi"] = Tarahi.StartJobDateStr;
                        Session["mojodin"] = Tarahi.Status;

                    }
                    else
                    {
                        Session["MsgTarahi"] = "";
                        Session["mojodin"] = 0;
                        Session["TarikhTarahi"] = "";

                    };




                    var Lito = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 2 && x.ProcessID == id);
                    if (Lito != null)
                    {

                        Session["MsgLito"] = null;
                        Session["mojodin_lito"] = 0;
                        Session["MsgLito"] = Lito.Description;
                        Session["TarikhLito"] = Lito.StartJobDateStr;
                        Session["mojodin_lito"] = Lito.Status;

                    }
                    else
                    {
                        Session["MsgLito"] = null;
                        Session["mojodin_lito"] = 0;
                        Session["TarikhLito"] = "";

                    };

                    var Kaghaz = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 3 && x.ProcessID == id);
                    if (Kaghaz != null)
                    {

                        Session["MsgKaghaz"] = null;
                        Session["mojodin_Kaghaz"] = 0;
                        Session["MsgKaghaz"] = Kaghaz.Description;
                        Session["TarikhKaghaz"] = Kaghaz.StartJobDateStr;
                        Session["mojodin_Kaghaz"] = Kaghaz.Status;

                    }
                    else
                    {
                        Session["MsgKaghaz"] = null;
                        Session["mojodin_Kaghaz"] = 0;
                        Session["TarikhKaghaz"] = "";

                    };


                    var chapkhaneh = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 4 && x.ProcessID == id);
                    if (chapkhaneh != null)
                    {

                        Session["MsgChapkhaneh"] = null;
                        Session["mojodin_Chapkhaneh"] = 0;
                        Session["MsgChapkhaneh"] = chapkhaneh.Description;
                        Session["TarikhChapkhaneh"] = chapkhaneh.StartJobDateStr;
                        Session["mojodin_Chapkhaneh"] = chapkhaneh.Status;

                    }
                    else
                    {
                        Session["MsgChapkhaneh"] = null;
                        Session["mojodin_Chapkhaneh"] = 0;
                        Session["TarikhChapkhaneh"] = "";

                    };


                    var UV = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 5 && x.ProcessID == id);
                    if (UV != null)
                    {

                        Session["MsgUV"] = null;
                        Session["mojodin_UV"] = 0;
                        Session["MsgUV"] = UV.Description;
                        Session["TarikhUV"] = UV.StartJobDateStr;
                        Session["mojodin_UV"] = UV.Status;

                    }
                    else
                    {
                        Session["MsgUV"] = null;
                        Session["mojodin_UV"] = 0;
                        Session["TarikhUV"] = "";

                    };



                    var Selfon = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 6 && x.ProcessID == id);
                    if (Selfon != null)
                    {

                        Session["MsgSelfon"] = null;
                        Session["mojodin_Selfon"] = 0;
                        Session["MsgSelfon"] = Selfon.Description;
                        Session["TarikhSelfon"] = Selfon.StartJobDateStr;
                        Session["mojodin_Selfon"] = Selfon.Status;

                    }
                    else
                    {
                        Session["MsgSelfon"] = null;
                        Session["mojodin_Selfon"] = 0;
                        Session["TarikhSelfon"] = "";

                    };



                    var leter = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 7 && x.ProcessID == id);
                    if (leter != null)
                    {

                        Session["Msgleter"] = null;
                        Session["mojodin_leter"] = 0;
                        Session["Msgleter"] = leter.Description;
                        Session["Tarikhleter"] = leter.StartJobDateStr;
                        Session["mojodin_leter"] = leter.Status;

                    }
                    else
                    {
                        Session["Msgleter"] = null;
                        Session["mojodin_leter"] = 0;
                        Session["Tarikhleter"] = "";

                    };


                    var Karton = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 8 && x.ProcessID == id);
                    if (Karton != null)
                    {

                        Session["MsgKarton"] = null;
                        Session["mojodin_kartonsazi"] = 0;
                        Session["MsgKarton"] = Karton.Description;
                        Session["Tarikhkarton"] = Karton.StartJobDateStr;
                        Session["mojodin_kartonsazi"] = Karton.Status;

                    }
                    else
                    {
                        Session["MsgKarton"] = null;
                        Session["mojodin_kartonsazi"] = 0;
                        Session["Tarikhkarton"] = "";

                    };

                    var kargah = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 9 && x.ProcessID == id);
                    if (kargah != null)
                    {

                        Session["Msgkargah"] = null;
                        Session["mojodin_kargah"] = 0;
                        Session["Msgkargah"] = kargah.Description;
                        Session["Tarikhkargah"] = kargah.StartJobDateStr;
                        Session["mojodin_kargah"] = kargah.Status;

                    }
                    else
                    {
                        Session["Msgkargah"] = null;
                        Session["mojodin_kargah"] = 0;
                        Session["Tarikhkargah"] = "";

                    };

                    var Motafareghe = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 10 && x.ProcessID == id);
                    if (Motafareghe != null)
                    {

                        Session["MsgMotafareghe"] = null;
                        Session["mojodin_Motafareghe"] = 0;
                        Session["MsgMotafareghe"] = Motafareghe.Description;
                        Session["TarikhMotafareghe"] = Motafareghe.StartJobDateStr;
                        Session["mojodin_Motafareghe"] = Motafareghe.Status;

                    }
                    else
                    {
                        Session["MsgMotafareghe"] = null;
                        Session["mojodin_Motafareghe"] = 0;
                        Session["TarikhMotafareghe"] = "";

                    };

                    var Ersal = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 11 && x.ProcessID == id);
                    if (Ersal != null)
                    {

                        Session["MsgErsal"] = null;
                        Session["mojodin_Ersal"] = 0;
                        Session["MsgErsal"] = Ersal.Description;
                        Session["TarikhErsal"] = Ersal.StartJobDateStr;
                        Session["mojodin_Ersal"] = Ersal.Status;

                    }
                    else
                    {
                        Session["MsgErsal"] = null;
                        Session["mojodin_Ersal"] = 0;
                        Session["TarikhErsal"] = "";

                    };


                    var Faktor = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 12 && x.ProcessID == id);
                    if (Faktor != null)
                    {

                        Session["MsgFaktor"] = null;
                        Session["mojodin_Faktor"] = 0;
                        Session["MsgFaktor"] = Faktor.Description;
                        Session["TarikhFaktor"] = Faktor.StartJobDateStr;
                        Session["mojodin_Faktor"] = Faktor.Status;

                    }
                    else
                    {
                        Session["MsgFaktor"] = null;
                        Session["mojodin_Faktor"] = 0;
                        Session["TarikhFaktor"] = "";

                    };



                    var Ghaleb = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 13 && x.ProcessID == id);
                    if (Ghaleb != null)
                    {

                        Session["Msgghalebsazi"] = null;
                        Session["mojodin_ghalebSazi"] = 0;
                        Session["Msgghalebsazi"] = Ghaleb.Description;
                        Session["Tarikhghalebsazi"] = Ghaleb.StartJobDateStr;
                        Session["mojodin_ghalebSazi"] = Ghaleb.Status;

                    }
                    else
                    {
                        Session["Msgghalebsazi"] = null;
                        Session["mojodin_ghalebSazi"] = 0;
                        Session["Tarikhghalebsazi"] = "";

                    };


                    var Motef = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 14 && x.ProcessID == id);
                    if (Motef != null)
                    {

                        Session["MsgMotafareghi"] = null;
                        Session["mojodin_Motefareghi"] = 0;
                        Session["MsgMotafareghi"] = Motef.Description;
                        Session["TarikhMotefareghi"] = Motef.StartJobDateStr;
                        Session["mojodin_Motefareghi"] = Motef.Status;

                    }
                    else
                    {
                        Session["MsgMotafareghi"] = null;
                        Session["mojodin_Motefareghi"] = 0;
                        Session["TarikhMotefareghi"] = "";

                    };

                    var laser = db.Jobs.FirstOrDefault(x => x.OrderTypeID == 15 && x.ProcessID == id);
                    if (laser != null)
                    {

                        Session["MsgLaser"] = null;
                        Session["mojodin_Laser"] = 0;
                        Session["MsgLaser"] = laser.Description;
                        Session["TarikhLaser"] = laser.StartJobDateStr;
                        Session["mojodin_Laser"] = laser.Status;

                    }
                    else
                    {
                        Session["MsgLaser"] = null;
                        Session["mojodin_Laser"] = 0;
                        Session["TarikhLaser"] = "";

                    };


                    int customerID;

                    var Processi = (db.Processes.First(x => x.ProcessID == id));
                    customerID = Processi.CustomerID;


                    var customeri = (db.Customers.First(x => x.CustomerID == customerID));

                    Session["NameFmily"] = customeri.NameFmily;
                    Session["Mob"] = customeri.Mob;
                    Session["Tel"] = customeri.Tel;

                    Session["ProcessTitle"] = Processi.Title;
                    Session["ProcessTypeOrder"] = Processi.typeOrder;



                }

                var jobs = db.Jobs.Include(j => j.Agent).Include(j => j.OrderType).Where(j => j.ProcessID == id);

                return View(jobs.ToList());

            };


        }



        // GET: Admin/MngJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Admin/MngJobs/Create
        public ActionResult Create()
        {


            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Status")] Job job,string dtorder)
        {








            int processid;

            processid = Convert.ToInt32(Session["ProcessID"]);

            job.ProcessID = processid;

            if (ModelState.IsValid)
            {
               
                int dt_int;

                if (dtorder == "" )
                {
                    dt_int = 0;

                }
                else
                {
                    dt_int = Convert.ToInt32(dtorder.Replace("/", ""));


                }
                
               


                job.StartJobDate = dt_int;
                job.StartJobDateStr = dtorder;

               

                db.Jobs.Add(job);
                db.SaveChanges();

                ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
                ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);




                return View(job);

               


                //string path_str;

                //path_str = "/MngJobs/Index/" + Convert.ToString(processid);

                //return RedirectToAction(path_str);
            }

            return View(job);


            //string path_str;

            //path_str = "Index/" + Convert.ToString(processid);

            //return RedirectToAction(path_str);

        }

        // GET: Admin/MngJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // POST: Admin/MngJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,ProcessID,OrderTypeID,AgentID,StartJobDateStr,StartJobDate,FinishJobDateStr,FinishJobDate,Description,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                int processid;


                processid = Convert.ToInt32(Session["ProcessID"]);
                job.ProcessID = processid;

                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();

              

             string path_str;


                path_str = "Index/" + Convert.ToString(processid);


                return RedirectToAction(path_str);
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "NameFmily", job.AgentID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "Title", job.OrderTypeID);
            return View(job);
        }

        // GET: Admin/MngJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Admin/MngJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            int processid;


            processid = Convert.ToInt32(Session["ProcessID"]);
            string path_str;

            path_str = "Index/" + Convert.ToString(processid);

            return RedirectToAction(path_str);
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
