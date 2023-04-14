using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using System.Threading.Tasks;
using Accounting.Domain.ViewModel.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Accounting.Application.Interfaces
{
    public interface IOrderService
    {
        Task<DtResult<OrderViewModel>> GetData(DtParameters dtParameters);
        List<SelectListItem> GetTypePrice();
        List<SelectListItem> GetTypeService();
    }
}