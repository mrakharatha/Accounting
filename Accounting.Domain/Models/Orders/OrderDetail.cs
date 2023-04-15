using System.ComponentModel.DataAnnotations;
using Accounting.Domain.Models.Menus;

namespace Accounting.Domain.Models.Orders
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int FoodId { get; set; }

        public int Count { get; set; }

        public ulong Price { get; set; }
        public ulong FinalPrice { get; set; }


        #region Relations

        public Order Order { get; set; }
        public Food Food { get; set; }

        #endregion
    }
}