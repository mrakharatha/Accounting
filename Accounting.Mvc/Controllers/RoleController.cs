using System.Collections.Generic;
using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Mvc.Controllers
{

    public class RoleController : Controller
    {
        private readonly IPermissionService _permissionService;


        public RoleController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [PermissionChecker(7)]
        public IActionResult Index()
        {
            return View(_permissionService.GetRoles());
        }

        [PermissionChecker(8)]
        public IActionResult Create()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role, List<int> selectedPermission)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Permissions"] = _permissionService.GetAllPermission();
                return View(role);
            }

            _permissionService.AddRole(role);


            _permissionService.AddRolePermission(role.RoleId, selectedPermission);


            return RedirectToAction("Index");
        }

        [PermissionChecker(9)]
        public IActionResult Update(int id)
        {
            var role = _permissionService.GetRoleById(id);

            if (role == null)
                return RedirectToAction("Index");

            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);

            return View(role);
        }

        [HttpPost]

        public IActionResult Update(Role role, List<int> selectedPermission)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Permissions"] = _permissionService.GetAllPermission();
                ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(role.RoleId);
                return View(role);
            }

            _permissionService.UpdateRole(role);
            _permissionService.UpdateRolePermission(role.RoleId, selectedPermission);


            return RedirectToAction("Index");
        }

        public int Delete(int id)
        {
            if (!_permissionService.CheckPermission(10, User.GetUserId()))
                return 1;

            if (_permissionService.CheckDelete(id))
                return 2;

            _permissionService.DeleteRole(id);
            return 3;
        }
    }

}