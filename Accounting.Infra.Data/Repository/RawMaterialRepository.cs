using System.Collections.Generic;
using System.Linq;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Menus;
using Accounting.Domain.Models.RawMaterials;
using Accounting.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Infra.Data.Repository
{

    public class RawMaterialRepository : IRawMaterialRepository
    {
        private readonly ApplicationContext _context;

        public RawMaterialRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<RawMaterial> GetAll()
        {
            return _context.RawMaterials.OrderByDescending(x => x.RawMaterialId).ToList();
        }

        public RawMaterial GetById(int rawMaterialId)
        {
            return _context.RawMaterials.Find(rawMaterialId);
        }

        public void Add(RawMaterial rawMaterial)
        {
            _context.Add(rawMaterial);
            _context.SaveChanges();
        }

        public void Update(RawMaterial rawMaterial)
        {
            _context.Update(rawMaterial);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItem()
        {
            return _context.RawMaterials
                .OrderByDescending(x => x.RawMaterialId)
                .Select(x => new SelectListItem()
                {
                    Value = x.RawMaterialId.ToString(),
                    Text = x.Title
                })
                .ToList();
        }
    }
}