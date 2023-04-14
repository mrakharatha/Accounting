using System.Linq;
using System.Threading.Tasks;
using Accounting.Application.Utilities;
using Accounting.Domain.Convertors;
using Accounting.Domain.Interfaces;
using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Accounting.Domain.ViewModel.Orders;
using Accounting.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DtResult<OrderViewModel>> GetData(DtParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;

            var result = _context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(x =>
                    x.Customer.FullName.Contains(searchBy) ||
                    x.InvoiceNumber.Contains(searchBy)
                );
            }

            var filteredResultsCount = await result.CountAsync();
            var totalResultsCount = await _context.Orders.CountAsync();

            return new DtResult<OrderViewModel>
            {
                Draw = dtParameters.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = await result
                    .OrderByDescending(r => r.OrderId)
                    .Include(x=> x.Customer)
                    .Include(x=> x.OrderDetails)
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .Select(x => new OrderViewModel()
                    {
                        CreateDate = x.CreateDate.ToShamsi(),
                        TypeService= x.TypeService.ToDisplay(DisplayProperty.Name),
                        TypePrice = x.TypePrice.ToDisplay(DisplayProperty.Name),
                        CustomerTitle = x.Customer.FullName,
                        FinalPrice = x.OrderDetails.Sum(o=>(decimal) o.FinalPrice).ToString("#,0 تومان"),
                        InvoiceNumber = x.InvoiceNumber,
                        OrderId = x.OrderId
                    })

                    .ToListAsync()
            };
        }
    }
}