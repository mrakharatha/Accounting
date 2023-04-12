using System.Collections.Generic;
using System.Linq;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Menus;
using Accounting.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Infra.Data.Repository
{

    public class GroupMenuRepository : IGroupMenuRepository
    {
        private readonly ApplicationContext _context;

        public GroupMenuRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<GroupMenu> GetAll()
        {
            return _context.GroupMenus.OrderByDescending(x => x.GroupMenuId).ToList();
        }

        public GroupMenu GetById(int groupMenuId)
        {
            return _context.GroupMenus.Find(groupMenuId);
        }

        public void Add(GroupMenu groupMenu)
        {
            _context.Add(groupMenu);
            _context.SaveChanges();
        }

        public void Update(GroupMenu groupMenu)
        {
            _context.Update(groupMenu);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItem()
        {
            return _context.GroupMenus
                .OrderByDescending(x => x.GroupMenuId)
                .Select(x => new SelectListItem()
                {
                    Value = x.GroupMenuId.ToString(),
                    Text = x.Title
                })
                .ToList();
        }
    }
}