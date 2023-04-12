using System;
using System.Collections.Generic;
using Accounting.Application.Interfaces;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Services
{
    public class FoodService: IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public List<Food> GetAll()
        {
            return _foodRepository.GetAll();
        }

        public Food GetById(int foodId)
        {
            return _foodRepository.GetById(foodId);
        }

        public void Add(Food food)
        {
            _foodRepository.Add(food);
        }

        public void Update(Food food)
        {
            food.UpdateDate = DateTime.Now;
            _foodRepository.Update(food);
        }

        public void Delete(int foodId, int userId)
        {
            var food = GetById(foodId);

            if (food == null)
                return;

            food.DeleteDate = DateTime.Now;
            food.UserId = userId;

            Update(food);
        }

        public List<SelectListItem> GetSelectListItem(int groupFoodId)
        {
            var result = _foodRepository.GetSelectListItem(groupFoodId);

            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Value = null, Text = "لطفا انتخاب کنید" }
            };

            items.AddRange(result);
            return items;
        }
    }
}