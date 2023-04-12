
using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Mvc.Controllers
{
    public class GroupMenuController : Controller
    {
        private readonly IGroupMenuService _groupMenuService;
        private readonly IPermissionService _permissionService;

        public GroupMenuController(IGroupMenuService groupMenuService, IPermissionService permissionService)
        {
            _groupMenuService = groupMenuService;
            _permissionService = permissionService;
        }

        [PermissionChecker(18)]
        public IActionResult Index()
        {
            return View(_groupMenuService.GetAll());
        }

        [PermissionChecker(19)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupMenu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _groupMenuService.Add(model);

            return RedirectToAction("Index");
        }


        [PermissionChecker(20)]
        public IActionResult Update(int id)
        {
            var groupMenu = _groupMenuService.GetById(id);

            if (groupMenu == null)
                return RedirectToAction("Index");

            return View(groupMenu);
        }

        [HttpPost]
        public IActionResult Update(GroupMenu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _groupMenuService.Update(model);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(21, User.GetUserId()))
                return false;

            _groupMenuService.Delete(id,User.GetUserId());

            return true;

        }
    }
}
