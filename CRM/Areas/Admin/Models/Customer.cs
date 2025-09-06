using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Customer
    {
        
       
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string RegDate { get; set; }
        public Nullable<int> RegDateInt { get; set; }


        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NameFmily { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Tel { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Mob { get; set; }
        [Display(Name = "آدرس")]
    
        public string Adress { get; set; }

        [Display(Name = "نحوه آشنایی")]

        public int DefID { get; set; }
        public virtual Definition Definition { get; set; }


        [Display(Name = "گروه کاری")]

        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }



        [Display(Name = "تاریخ تولد")]
        public string BornDate { get; set; }
        public Nullable<int> BornDateInt { get; set; }

        [Display(Name = "اسم شرکت")]
        public string CompanyName { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "كلمه عبور")]
        public string Password { get; set; }


        [Display(Name = "فعال")]
        public bool? Active { get; set; }


        

        [Display(Name = "شغل")]
        public string CustomerJob { get; set; }
        [Display(Name = "کد پستی")]
        public string CustomerPostalCode { get; set; }

        [Display(Name = "ایمیل")]
        public string CustomerEmail { get; set; }
        [Display(Name = "کد اقتصادی")]
        public string CustomerEconomyCode{ get; set; }

        [Display(Name = "عنوان")]
        public string CustomerTitle { get; set; }

        [Display(Name = "توضيحات")]
        public string Description { get; set; }

        [Display(Name = "تعداد سفارشات مشتری")]

        public int CustomerFactor { get; set; }

        [Display(Name = "امتیاز مشتری")]

        public int CustomerRank { get; set; }

    }
}