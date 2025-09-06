using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Process
    {
        [Key]

        //شماره پروسه کاری
        public int ProcessID { get; set; }


        [Display(Name = "تاریخ سفارش")]
      
        public string dateOrderStr { get; set; }
        public int dateOrder { get; set; }
      


        [Display(Name = "تاریخ شروع")]
       
        public string dateStartStr { get; set; }
        public int dateStart { get; set; }


        [Display(Name = "تاریخ تخمینی پایان")]

        public string guessdateEndStr { get; set; }
        public int guessdateEnd { get; set; }


        [Display(Name = "تاریخ پایان")]
 
        public string dateEndStr { get; set; }
        public int dateEnd { get; set; }

        [Display(Name = "ساعت شروع")]

        public string Starthour { get; set; }

        [Display(Name = "ساعت خروج")]

        public string Endhour { get; set; }


        //[Display(Name = "نوع سفارش")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //public int OrderTypeID { get; set; }
        //public virtual OrderType OrderType { get; set; }

        [Display(Name = "نوع سفارش")]

        public string typeOrder { get; set; }


        [Display(Name = "عنوان کار")]
  
        public string Title { get; set; }

        [Display(Name = "مراحل انجام سفارش")]

        public string ProcessSteps { get; set; }


        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


        //start 0 , finished 1 , suspend 2 
        public int Status { get; set; }

     


    }
}