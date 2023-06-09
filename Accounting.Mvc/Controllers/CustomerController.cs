﻿using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Application.Security;
using Accounting.Application.Utilities;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;

        public CustomerController(ICustomerService customerService, IPermissionService permissionService)
        {
            _customerService = customerService;
            _permissionService = permissionService;
        }

        [PermissionChecker(13)]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionChecker(14)]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);


            _customerService.Add(model);

            return RedirectToAction("Index");
        }

        [PermissionChecker(15)]
        public IActionResult Update(int id)
        {
            var customer = _customerService.GetByCustomerId(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);


            _customerService.Update(model);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(16, User.GetUserId()))
                return false;

            _customerService.Delete(id, User.GetUserId());

            return true;
        }

        public bool IsPhoneExist(string phoneNumber, int customerId)
        {
            return !_customerService.IsPhoneExist(customerId, phoneNumber);
        }

        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _customerService.GetData(dtParameters);

            return Json(dtResult);
        }
    }

}
