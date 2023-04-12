using System;
using System.Collections.Generic;
using Accounting.Application.Interfaces;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.Models.Menus;
using Accounting.Domain.Models.RawMaterials;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Services
{
    public class RawMaterialService: IRawMaterialService
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public RawMaterialService(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public List<RawMaterial> GetAll()
        {
            return _rawMaterialRepository.GetAll();
        }

        public RawMaterial GetById(int rawMaterialId)
        {
            return _rawMaterialRepository.GetById(rawMaterialId);
        }

        public void Add(RawMaterial rawMaterial)
        {
            _rawMaterialRepository.Add(rawMaterial);
        }

        public void Update(RawMaterial rawMaterial)
        {
            rawMaterial.UpdateDate = DateTime.Now;
            _rawMaterialRepository.Update(rawMaterial);
        }

        public void Delete(int rawMaterialId, int userId)
        {
            var rawMaterial = GetById(rawMaterialId);

            if (rawMaterial == null)
                return;

            rawMaterial.DeleteDate = DateTime.Now;
            rawMaterial.UserId = userId;

            Update(rawMaterial);
        }

        public List<SelectListItem> GetSelectListItem()
        {
            return _rawMaterialRepository.GetSelectListItem();
        }
    }
}