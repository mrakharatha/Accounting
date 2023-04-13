using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Domain.Interfaces
{

    public interface ICustomerRepository
    {
        Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters);
        bool IsPhoneExist(int customerId, string phone);
        void Add(Customer customer);
        void Update(Customer customer);
        Customer GetByCustomerId(int customerId);
        List<SelectListItem> GetSelectListItem();

    }
}