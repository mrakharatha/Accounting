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
        bool IsPhoneNumberExist(int customerId, string phoneNumber);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetByCustomerId(int customerId);
        List<SelectListItem> GetCustomer();

    }
}