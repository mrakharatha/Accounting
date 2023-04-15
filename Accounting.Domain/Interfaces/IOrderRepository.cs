using Accounting.Domain.Models.Orders;
using Accounting.Domain.ViewModel.DataTable;
using Accounting.Domain.ViewModel.Orders;
using System.Threading.Tasks;

namespace Accounting.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<DtResult<OrderViewModel>> GetData(DtParameters dtParameters);
        void Add(Order order);

    }
}