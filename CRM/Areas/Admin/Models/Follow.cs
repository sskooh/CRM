using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Areas.Admin.Models
{
    public class Follow
    {
        [Key]

        public int FollowID { get; set; }
        [Display(Name = "تاریخ پیگیری")]

        public string RegDatestr { get; set; }
        public int RegDateInt { get; set; }

        [Display(Name = "ساعت پیگیری")]

        public string RegClockstr { get; set; }

        [Display(Name = "مشتری")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        //1-- رفت دست کارشناس
        //2-- دریافت شد توسط کارشناس
        //3-- در حال انجام
        //4-- پایان


        [Display(Name = "عنوان کار")]

        public string Title { get; set; }


        [Display(Name = "گروه کاری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int AgentID { get; set; }
        public virtual Agent Agent { get; set; }


        [Display(Name = "تاریخ یادآوری")]

        public string RememberJobDateStr { get; set; }
        public int RememberJobDate { get; set; }
        [Display(Name = "ساعت یادآوری")]

        public string RememberClockstr { get; set; }

        [Display(Name = "توضیحات")]

        public string Description { get; set; }


        [Display(Name = "توضیحات کارشناس")]

        public string DescriptionExpert { get; set; }


        [Display(Name = "توضیحات نظر مشتری")]

        public string CustomerDescription { get; set; }


        [Display(Name = "سفارش داد")]

        public Boolean Ordered { get; set; }

        [Display(Name = "امتیاز این پیگیری")]
        public int Star { get; set; }
        [Display(Name = "این پیگیری پایان یافت")]
        public int Status { get; set; }
    }
}