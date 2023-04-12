using Accounting.Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Accounting.Domain.Models.RawMaterials;

namespace Accounting.Application.Interfaces
{
    public interface IRawMaterialService
    {
        List<RawMaterial> GetAll();
        RawMaterial GetById(int rawMaterialId);
        void Add(RawMaterial rawMaterial);
        void Update(RawMaterial rawMaterial);
        void Delete(int rawMaterialId,int userId);
        List<SelectListItem> GetSelectListItem();
    }
}