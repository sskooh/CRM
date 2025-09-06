using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Models
{
    public class Recruitment
    {
        [Key]
        public int RecID { get; set; }
        public string JobPosition { get; set; }
        public string NameFamily { get; set; }
        public string BornDate { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string EducationLevel { get; set; }
        public string MarriedSingle { get; set; }

        public string Adress { get; set; }
    }
 
}