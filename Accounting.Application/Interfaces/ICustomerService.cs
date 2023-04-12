
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Interfaces
{

    public interface ICustomerService
    {
        Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        bool IsPhoneNumberExist(int customerId, string phoneNumber);
        Customer GetByCustomerId(int customerId);
        void DeleteCustomer(int customerId, int userId);
        List<SelectListItem> GetCustomer();
    }
}