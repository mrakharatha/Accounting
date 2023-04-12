using System.Collections.Generic;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Domain.Interfaces
{
    public interface IGroupMenuRepository
    {
        List<GroupMenu> GetAll();
        GroupMenu GetById(int groupMenuId);
        void Add(GroupMenu groupMenu);
        void Update(GroupMenu groupMenu);
        List<SelectListItem> GetSelectListItem();
    }
}