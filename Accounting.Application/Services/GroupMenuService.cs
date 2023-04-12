using System;
using System.Collections.Generic;
using Accounting.Application.Interfaces;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Services
{
    public class GroupMenuService: IGroupMenuService
    {
        private readonly IGroupMenuRepository _groupMenuRepository;

        public GroupMenuService(IGroupMenuRepository groupMenuRepository)
        {
            _groupMenuRepository = groupMenuRepository;
        }

        public List<GroupMenu> GetAll()
        {
            return _groupMenuRepository.GetAll();
        }

        public GroupMenu GetById(int groupMenuId)
        {
            return _groupMenuRepository.GetById(groupMenuId);
        }

        public void Add(GroupMenu groupMenu)
        {
            _groupMenuRepository.Add(groupMenu);
        }

        public void Update(GroupMenu groupMenu)
        {
            groupMenu.UpdateDate = DateTime.Now;
            _groupMenuRepository.Update(groupMenu);
        }

        public void Delete(int groupMenuId, int userId)
        {
            var groupMenu = GetById(groupMenuId);

            if (groupMenu == null)
                return;

            groupMenu.DeleteDate = DateTime.Now;
            groupMenu.UserId = userId;

            Update(groupMenu);
        }

        public List<SelectListItem> GetSelectListItem()
        {
            var result = _groupMenuRepository.GetSelectListItem();

            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Value = null, Text = "لطفا انتخاب کنید" }
            };

            items.AddRange(result);
            return items;
        }
    }
}