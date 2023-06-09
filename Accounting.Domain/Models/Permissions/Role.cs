﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Users;

namespace Accounting.Domain.Models.Permissions
{

    public class Role
    {
        [Key] public int RoleId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "تاریخ ویرایش")]
        public DateTime? UpdateDate { get; set; }
        [Display(Name = "تاریخ حذف")]
        public DateTime? DeleteDate { get; set; }


        #region Relations

        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        #endregion

    }

}