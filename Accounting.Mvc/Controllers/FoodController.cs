using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Mvc.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IPermissionService _permissionService;

        public FoodController(IFoodService foodService, IPermissionService permissionService)
        {
            _foodService = foodService;
            _permissionService = permissionService;
        }

        [PermissionChecker(26)]
        public IActionResult Index()
        {
            return View(_foodService.GetAll());
        }

        [PermissionChecker(27)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _foodService.Add(model);

            return RedirectToAction("Index");
        }


        [PermissionChecker(28)]
        public IActionResult Update(int id)
        {
            var food = _foodService.GetById(id);

            if (food == null)
                return RedirectToAction("Index");

            return View(food);
        }

        [HttpPost]
        public IActionResult Update(Food model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _foodService.Update(model);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(29, User.GetUserId()))
                return false;

            _foodService.Delete(id,User.GetUserId());

            return true;

        }
    }
}
