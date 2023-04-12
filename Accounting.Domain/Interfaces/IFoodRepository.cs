using System.Collections.Generic;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Domain.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        Food GetById(int foodId);
        void Add(Food food);
        void Update(Food food);
        List<SelectListItem> GetSelectListItem(int groupFoodId);
    }
}