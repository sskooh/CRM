using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactID { get; set; }
    
        public string NameFamily { get; set; }
    
        public string Telephone { get; set; }
        public string Mobile { get; set; }
  
        public string Description { get; set; }
    }
}