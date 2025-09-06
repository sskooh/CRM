using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//  اين مدل برای نمونه کارهاست و کارهای تولید شده قبلی مشتریان
namespace CRM.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string MainPicture { get; set; }
        public string Completedescription { get; set; }
        public string Keywords { get; set; }


    }
}
