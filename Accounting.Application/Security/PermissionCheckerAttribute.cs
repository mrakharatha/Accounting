using System.Security.Claims;
using Accounting.Application.Interfaces;
using Accounting.Application.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Accounting.Application.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;
        private readonly int _permissionId;
        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;
            
            var currentUserId = context.HttpContext.User.GetUserId();

            if (_permissionService==null||!_permissionService.CheckPermission(_permissionId, currentUserId))
                context.Result = new RedirectResult("/Permission");
        }
    }
}
