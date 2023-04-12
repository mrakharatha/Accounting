using System.Collections.Generic;
using Accounting.Domain.Models.Menus;
using Accounting.Domain.Models.RawMaterials;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Domain.Interfaces
{
    public interface IRawMaterialRepository
    {
        List<RawMaterial> GetAll();
        RawMaterial GetById(int rawMaterialId);
        void Add(RawMaterial rawMaterial);
        void Update(RawMaterial rawMaterial);
        List<SelectListItem> GetSelectListItem();
    }
}