using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Domain.Models.Customers
{

    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }

        public int UserId { get; set; }


        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }



        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Remote("IsPhoneExist", "Customer", AdditionalFields = nameof(CustomerId), ErrorMessage = "{0} تکراری می باشد")]
        public string Phone { get; set; }


        [Display(Name = "محل سکونت")] 
        public string Address { get; set; }

        [Display(Name = "توضیحات")]

        public string Description { get; set; }


        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "تاریخ ویرایش")]
        public DateTime? UpdateDate { get; set; }
        [Display(Name = "تاریخ حذف")] 
        public DateTime? DeleteDate { get; set; }



        #region Relations

        public User User { get; set; }

        #endregion

    }
}