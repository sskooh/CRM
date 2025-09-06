using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }
        public string Title { get; set; }

    
        public string ProductID { get; set; }
        public string path { get; set; }
       
    }
}