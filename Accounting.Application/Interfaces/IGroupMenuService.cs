using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Accounting.Application.Interfaces
{
    public interface IGroupMenuService
    {
        List<GroupMenu> GetAll();
        GroupMenu GetById(int groupMenuId);
        void Add(GroupMenu groupMenu);
        void Update(GroupMenu groupMenu);
        void Delete(int groupMenuId,int userId);
        List<SelectListItem> GetSelectListItem();
    }
}