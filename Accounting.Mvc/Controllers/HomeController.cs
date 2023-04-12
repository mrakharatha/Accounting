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
     private  readonly IPermissionService _permissionService;

       public HomeController(IPermissionService permissionService)
       {
           _permissionService = permissionService;
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

    }
}
