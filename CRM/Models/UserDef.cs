using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Models
{
    public class UserDef
    {
        [Required]
        [Key]
        [Display(Name = "کد کاربر")]

        public int UserId { get; set; }

        [Display(Name = "نوع کاربر")]

        public int UserType { get; set; }



        [Display(Name = "نام کاربری")]

        public string UserName { get; set; }




        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("NewPassword", ErrorMessage = "با هم برابر نیستند")]
        public string ConfirmPassword { get; set; }


        //1- admin
        //2-agent
        //3-users
        [Display(Name = "نوع کاربر سیستم")]

        public int UserRole { get; set; }


        [Display(Name = "مرز")]

        public int BorderID { get; set; }

        [Display(Name = "عنوان")]
        public string UserTitle { get; set; }


        [Required(ErrorMessage = "لطفا نام شخص را وارد کنید")]
        [Display(Name = "نام شخص")]
        public string UserNameFamily { get; set; }



        [Display(Name = "کد ملی")]
        public string UserNationalCode { get; set; }
        [Display(Name = "تلفن")]
        public string UserTel { get; set; }

        [Display(Name = "تلفن همراه")]
        public string UserMob { get; set; }


        [Display(Name = "فعال")]
        public bool? UserIsActive { get; set; }





        [Display(Name = "توضیحات")]
        //[DataType(DataType.MultilineText)]

        public string UserDescription { get; set; }


    }


    public class MyLogInViewModel
    {
        [Key]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool RememberMe { get; set; }
    }
}