using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Job
    {
        [Key]

        public int JobID { get; set; }


        [Display(Name = "کد کار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
  
        public int ProcessID { get; set; }
     
        
        [Display(Name = "نوع کار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int OrderTypeID { get; set; }
        public virtual OrderType OrderType { get; set; }


        [Display(Name = "مسئول / کارگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int AgentID { get; set; }
        public virtual Agent Agent { get; set; }


        [Display(Name = "تاریخ شروع")]
     
        public string StartJobDateStr { get; set; }
        public int StartJobDate { get; set; }


        [Display(Name = "تاریخ پایان")]
     
        public string FinishJobDateStr { get; set; }
        public int FinishJobDate { get; set; }

        [Display(Name = "توضیحات")]

        public string Description { get; set; }


        [Display(Name = "توضیحات کارشناس")]

        public string DescriptionExpert { get; set; }

        [Display(Name = "عنوان کار")]

        public string Title { get; set; }


        [Display(Name = "نام مشتری")]

        public string CustomerName { get; set; }


        [Display(Name = "شماره فاکتور")]

        public string FaktorNumber { get; set; }

        public int CustomerIDjob { get; set; }
        public virtual Customer Customer { get; set; }

        //1-- رفت دست کارشناس
        //2-- دریافت شد توسط کارشناس
        //3-- در حال انجام
        //4-- پایان
        public int Status { get; set; }

    }
}