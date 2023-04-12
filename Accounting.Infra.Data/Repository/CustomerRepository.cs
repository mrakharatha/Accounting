using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Domain.Convertors;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Models.Customers;
using Accounting.Domain.ViewModel.Customers;
using Accounting.Domain.ViewModel.DataTable;
using Accounting.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Infra.Data.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DtResult<CustomerViewModel>> GetData(DtParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;

            var result = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(x =>
                    x.PhoneNumber.Contains(searchBy) ||
                    x.FullName.Contains(searchBy)
                );
            }

            var filteredResultsCount = await result.CountAsync();
            var totalResultsCount = await _context.Customers.CountAsync();

            return new DtResult<CustomerViewModel>
            {
                Draw = dtParameters.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = await result
                    .OrderByDescending(r => r.CustomerId)
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .Select(x => new CustomerViewModel()
                    {
                        CreateDate = x.CreateDate.ToShamsi(),
                        CustomerId = x.CustomerId,
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                    })

                    .ToListAsync()
            };
        }

        public bool IsPhoneNumberExist(int customerId, string phoneNumber)
        {
            return customerId == 0 ? _context.Customers.Any(x => x.PhoneNumber.Equals(phoneNumber)) : _context.Customers.Any(x => x.PhoneNumber.Equals(phoneNumber) && x.CustomerId != customerId);
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }

        public Customer GetByCustomerId(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public List<SelectListItem> GetSelectListItem()
        {
            return _context.Customers
                .OrderByDescending(x => x.CustomerId)
                .Select(x => new SelectListItem()
                {
                    Text = x.FullName + " - " + x.CustomerId,
                    Value = x.CustomerId.ToString()
                })
                .ToList();
        }
    }
}