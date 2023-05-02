using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Application.Utilities;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Orders;
using Accounting.Domain.ViewModel.DataTable;
using Accounting.Domain.ViewModel.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<DtResult<OrderViewModel>> GetData(DtParameters dtParameters)
        {
            var result = _orderRepository.GetData(dtParameters);
            return await result;
        }

        public List<SelectListItem> GetTypePrice()
        {
            return EnumExtensions.GetAllEnumSelectListItem<TypePrice>().ToList();
        }

        public List<SelectListItem> GetTypeService()
        {
            return EnumExtensions.GetAllEnumSelectListItem<TypeService>().ToList();
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public string GetInvoiceNumber()
        {
            var invoiceNumber = _orderRepository.GetInvoiceNumber(DateTime.Now);

            return "#" + (invoiceNumber + 1).ToString("00");
        }
    }
}