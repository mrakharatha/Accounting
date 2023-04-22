using Accounting.Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Application.Interfaces;

namespace Accounting.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly ICustomerService _customerService;
        private readonly IFoodService _foodService;
        public HomeController(IPermissionService permissionService, ICustomerService customerService, IFoodService foodService)
        {
            _permissionService = permissionService;
            _customerService = customerService;
            _foodService = foodService;
        }

        public IActionResult Index()
        {
            if (_permissionService.CheckPermission(1, User.GetUserId()))
                return View();

            return RedirectToAction("IndexNotPermission");
        }

        public IActionResult IndexNotPermission()
        {
            return View();
        }



        #region GetInformations

        public IActionResult GetCustomer(int id)
        {
            return Json(_customerService.GetByCustomerId(id));
        }

        public IActionResult GetFoods(int id)
        {
            return Json(_foodService.GetSelectListItem(id));
        }

        public IActionResult GetFood(int id)
        {
            return Json(_foodService.GetById(id));
        }

        #endregion
    }
}
