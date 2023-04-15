using System.Linq;
using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Services;
using Accounting.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Accounting.Domain.Models.Orders;

namespace Accounting.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPermissionService _permissionService;

        public OrderController(IOrderService orderService, IPermissionService permissionService)
        {
            _orderService = orderService;
            _permissionService = permissionService;
        }

        [PermissionChecker(30)]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionChecker(31)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            order.OrderDetails.Remove(order.OrderDetails.FirstOrDefault());
            order.OrderDetails.ToList().RemoveAll(x => x.FoodId == 0);
            //if (!ModelState.IsValid)
            //    return View(order);


            _orderService.Add(order);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _orderService.GetData(dtParameters);

            return Json(dtResult);
        }
    }
}
