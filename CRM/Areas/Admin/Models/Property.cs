using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Property
    {
        [Key]

        //همه خصوصیات در سیستم را در اینجا ثبت می کنیم
        public int PropertyID { get; set; }

        [Display(Name = "نوع خصوصیت")]
        public string PropertyName { get; set; }


    }
}