using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Accounting.Domain.ViewModel.Orders
{
    public class OrderViewModel
    {
        [Display(Name = "ردیف")] public int Row { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "شماره فاکتور")] public string InvoiceNumber { get; set; }
        [Display(Name = "نام مشتری")] public string CustomerTitle { get; set; }
        [Display(Name = "نحوه ی پرداخت")] public string TypePrice { get; set; }
        [Display(Name = "نوع خدمات")] public string TypeService { get; set; }
        [Display(Name = "قیمت نهایی")] public string  FinalPrice { get; set; }
        [Display(Name = "تاریخ ثبت")] public string CreateDate { get; set; }
        [Display(Name = "عملیات")] public string Operation { get; set; }
    }
}