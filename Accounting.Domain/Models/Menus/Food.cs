using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Orders;
using Accounting.Domain.Models.Users;

namespace Accounting.Domain.Models.Menus
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "گروه منو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? GroupMenuId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong Price { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "تاریخ ویرایش")]
        public DateTime? UpdateDate { get; set; }
        [Display(Name = "تاریخ حذف")]
        public DateTime? DeleteDate { get; set; }

        #region Relations

        public GroupMenu GroupMenu { get; set; }
        public User User  { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

    }
}