using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class CRMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CRMContext() : base("name=CRMContext")
        {
        }

        public System.Data.Entity.DbSet<CRM.Models.UserDef> UserDefs { get; set; }

        public System.Data.Entity.DbSet<CRM.Models.MyLogInViewModel> MyLogInViewModels { get; set; }

       

        public System.Data.Entity.DbSet<CRM.Models.Content> Contents { get; set; }

        public System.Data.Entity.DbSet<CRM.Models.Recruitment> Recruitments { get; set; }

        public System.Data.Entity.DbSet<CRM.Models.ContactUs> ContactUs { get; set; }

   

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Agent> Agents { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Process> Processes { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.OrderType> OrderTypes { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Property> Properties { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.JobProperty> JobProperties { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Definition> Definitions { get; set; }

        public System.Data.Entity.DbSet<CRM.Areas.Admin.Models.Follow> Follows { get; set; }

        public System.Data.Entity.DbSet<CRM.Models.Product> Products { get; set; }
    }
}
