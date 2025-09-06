using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Contents",
                url: "{name}",
                defaults: new { controller = "Contents", action = "Index" }
            );

            routes.MapRoute("ProductPaging", "Product/{name}",
                     defaults: new
                     {
                         controller = "Product",
                         action = "Index",
                          //id = "all",
                          pid = UrlParameter.Optional
                     }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );


      //      routes.MapRoute("ContentsPaging", "Contents/{name}",
      //defaults: new
      //{
      //    controller = "Contents",
      //    action = "Index",
      //         //id = "all",
      //         pid = UrlParameter.Optional
      //}
      //);
      //      routes.MapRoute("FAQPaging", "FAQ/{name}",
      //                defaults: new
      //                {
      //                    controller = "FAQ",
      //                    action = "Index",
      //                    //id = "all",
      //                    pid = UrlParameter.Optional
      //                }
      //        );

         


      //      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      //      routes.MapRoute(
      //          name: "Default",
      //          url: "{controller}/{action}/{id}",
      //          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }


      //      );

           
        }
    }
}
