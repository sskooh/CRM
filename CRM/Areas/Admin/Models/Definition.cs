using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class Definition
    {
        [Key]

        public int DefID { get; set; }


        [Display(Name = "عنوان")]

        public string DefTitle { get; set; }

        public int IdPage { get; set; }
  

    }
}