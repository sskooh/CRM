using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CRM.Models
{
    public class Content
    {

        //  این مدل برای  بلاگ و مطالب سایت است  
        [Key]
        public int ContentID { get; set; }

        [Display(Name = "زبان مطلب")]
        public int LangID { get; set; }

        [Display(Name = "دسته مطلب")]
        public int BranchID { get; set; }

        [Display(Name = "عنوان2")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "عنوان به همراه آندرلاین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TitleAdress { get; set; }
        [Display(Name = "عنوان2")]
        public string Title1 { get; set; }

        public string ContentStr { get; set; }
        [Display(Name = "توضیحات1")]
        [AllowHtml]
        public string Completedescription { get; set; }
        [Display(Name = "توضیحات2")]
        public string Completedescription1 { get; set; }
        [Display(Name = "ابعاد")]
        public string Size { get; set; }
        [Display(Name = "وزن")]
        public string Wight { get; set; }
       
        [Display(Name = "جنس")]
        public string Material { get; set; }
        [Display(Name = "نوع")]
        public string Type { get; set; }
        [Display(Name = "کد محصول")]
        public string ProductCode { get; set; }
        [Display(Name = "شناسه")]
        public string ProductSerial { get; set; }


        public string DateStr { get; set; }

        public string MainPicture { get; set; }
        public string Pic1 { get; set; }
        public string AltPic1 { get; set; }
        public string Pic2 { get; set; }
        public string AltPic2 { get; set; }
        public string Pic3 { get; set; }
        public string AltPic3 { get; set; }
        public string Pic4 { get; set; }
        public string AltPic4 { get; set; }
        public string Pic5 { get; set; }
        public string AltPic5 { get; set; }

        public int ShowFirstPage { get; set; }
        public int ViewNumber { get; set; }

        public string Keywords { get; set; }

        public string Branchstr { get; set; }
        public string Keywords1 { get; set; }
        public string Keywords2 { get; set; }
        public string Keywords3 { get; set; }
        public string Keywords4 { get; set; }
        public string Keywords5 { get; set; }

        public string Video1 { get; set; }
        public string VideoIDaparat1 { get; set; }
        public string VideoDescription1 { get; set; }
        public string VideoTag1 { get; set; }
        public string Video2 { get; set; }
        public string VideoIDaparat2 { get; set; }
        public string VideoDescription2 { get; set; }
        public string VideoTag2 { get; set; }

    }
}