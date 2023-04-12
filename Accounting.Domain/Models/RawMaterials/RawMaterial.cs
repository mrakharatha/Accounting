using System;
using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Users;

namespace Accounting.Domain.Models.RawMaterials
{
    public class RawMaterial
    {
        [Key]
        public int RawMaterialId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

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