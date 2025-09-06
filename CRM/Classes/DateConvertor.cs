
using System.Globalization;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Areas.Admin.Models;
using CRM.Models;
using CRM.Classes;


namespace CRM.Classes
{

    public static class DateConvertor
    {
      
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
        }

 

        public static DateTime ToMiladi(string dt)
        {
            string[] date = dt.Split('/');
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0,
                0);
        }

    

    }
}