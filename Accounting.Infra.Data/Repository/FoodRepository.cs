using System.Collections.Generic;
using System.Linq;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Menus;
using Accounting.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Infra.Data.Repository
{

    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationContext _context;

        public FoodRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<Food> GetAll()
        {
            return _context.Foods
                .Include(x=> x.GroupMenu)
                .OrderByDescending(x => x.FoodId)
                .ToList();
        }

        public Food GetById(int foodId)
        {
            return _context.Foods.Find(foodId);
        }

        public void Add(Food food)
        {
            _context.Add(food);
            _context.SaveChanges();
        }

        public void Update(Food food)
        {
            _context.Update(food);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItem(int groupFoodId)
        {
            return _context.Foods
                .Where(x=> x.GroupMenuId==groupFoodId)
                .OrderByDescending(x => x.FoodId)
                .Select(x => new SelectListItem()
                {
                    Value = x.FoodId.ToString(),
                    Text = x.Title
                })
                .ToList();
        }
    }
}