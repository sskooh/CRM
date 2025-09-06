using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Agent
    {
        [Key]

        public int AgentID { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NameFmily { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Tel { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Mob { get; set; }
        [Display(Name = "تاریخ تولد")]
        public string BornDate { get; set; }

        public Nullable<int> BornDateInt { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "كلمه عبور")]
        public string Password { get; set; }


        [Display(Name = "فعال")]
        public string Active { get; set; }
    }
}