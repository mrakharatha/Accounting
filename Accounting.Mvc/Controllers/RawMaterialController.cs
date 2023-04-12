
using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Menus;
using Accounting.Domain.Models.RawMaterials;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Mvc.Controllers
{
    public class RawMaterialController : Controller
    {
        private readonly IRawMaterialService _rawMaterialService;
        private readonly IPermissionService _permissionService;

        public RawMaterialController(IRawMaterialService rawMaterialService, IPermissionService permissionService)
        {
            _rawMaterialService = rawMaterialService;
            _permissionService = permissionService;
        }

        [PermissionChecker(22)]
        public IActionResult Index()
        {
            return View(_rawMaterialService.GetAll());
        }

        [PermissionChecker(23)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RawMaterial model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _rawMaterialService.Add(model);

            return RedirectToAction("Index");
        }


        [PermissionChecker(24)]
        public IActionResult Update(int id)
        {
            var rawMaterial = _rawMaterialService.GetById(id);

            if (rawMaterial == null)
                return RedirectToAction("Index");

            return View(rawMaterial);
        }

        [HttpPost]
        public IActionResult Update(RawMaterial model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _rawMaterialService.Update(model);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(25, User.GetUserId()))
                return false;

            _rawMaterialService.Delete(id,User.GetUserId());

            return true;

        }
    }
}
