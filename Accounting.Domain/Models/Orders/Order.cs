using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.Models.Users;

namespace Accounting.Domain.Models.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? CustomerId { get; set; }

        [Display(Name = "شماره فاکتور")]
        public string InvoiceNumber { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }


        [Display(Name = "نحوه ی پرداخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public TypePrice TypePrice { get; set; }


        [Display(Name = "نوع خدمات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public TypeService TypeService { get; set; }

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
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}

public enum TypePrice
{
    [Display(Name = "نقد")]
    Cash=1,
    [Display(Name = "نسیه")]
    Credit = 2,
    [Display(Name = "کارت بانکی")]
    BankCard = 3
}

public enum TypeService
{
    [Display(Name = "سالن")]
    Hall=1,
    [Display(Name = "بیرون بر")]
    GetOut = 2,
    [Display(Name = "پیک")]
    Delivery = 3
}