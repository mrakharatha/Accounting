using System.ComponentModel.DataAnnotations;

namespace Accounting.Domain.ViewModel.Customers
{

    public class CustomerViewModel
    {
        [Display(Name = "ردیف")] public int Row { get; set; }
        [Display(Name = "کد اشتراک")] public int CustomerId { get; set; }
        [Display(Name = "نام و نام خانوادگی")] public string FullName { get; set; }
        [Display(Name = "تلفن")] public string Phone { get; set; }
        [Display(Name = "تاریخ ثبت")] public string CreateDate { get; set; }
        [Display(Name = "عملیات")] public string Operation { get; set; }
    }
}
