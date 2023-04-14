using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Accounting.Application.Interfaces
{
    public interface IFoodService
    {
        List<Food> GetAll();
        Food GetById(int foodId);
        void Add(Food food);
        void Update(Food food);
        void Delete(int foodId, int userId);
        List<SelectListItem> GetSelectListItem();
    }
}