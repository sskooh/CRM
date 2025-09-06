using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class OrderType
    {
        [Key]

        //طراحی --- لیتوگرافی ---تهیه کاغذ -- چاپخانه
        public int OrderTypeID { get; set; }


        [Display(Name = "نوع کار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

    }
}