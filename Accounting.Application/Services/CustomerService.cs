using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting.Application.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters)
        {
            var result = _customerRepository.GetData(dtParameters);
            return await result;
        }

       
        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customer.UpdateDate = DateTime.Now;
            _customerRepository.UpdateCustomer(customer);
        }


        public bool IsPhoneNumberExist(int customerId, string phoneNumber)
        {
            return _customerRepository.IsPhoneNumberExist(customerId, phoneNumber);
        }

        public Customer GetByCustomerId(int customerId)
        {
            return _customerRepository.GetByCustomerId(customerId);
        }


        public void DeleteCustomer(int customerId, int userId)
        {
            var customer = GetByCustomerId(customerId);

            if (customer == null)
                return;

            customer.DeleteDate = DateTime.Now;
            customer.UserId = userId;

            UpdateCustomer(customer);
        }

        public List<SelectListItem> GetCustomer()
        {
            var result = _customerRepository.GetCustomer();

            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Value = null, Text = "لطفا انتخاب کنید" }
            };

            items.AddRange(result);
            return items;
        }
    }
}