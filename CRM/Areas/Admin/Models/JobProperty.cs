using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Areas.Admin.Models
{
    public class JobProperty
    {
        //مشخصات کار مثل رنگ و مدل .. گرماژو .....برای این یک کار خاص 
        [Key]

        public int JobPropertyID { get; set; }


        [Display(Name = "نوع کار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int JobID { get; set; }
        public virtual Job Job { get; set; }

        [Display(Name = "توضیحات مشخصات کار")]
  
        public string Description { get; set; }



    }
}