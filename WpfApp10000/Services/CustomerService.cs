﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp10000.Contexts;
using WpfApp10000.Models;
using WpfApp10000.Models.Entities;

namespace WpfApp10000.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerCreateModel model)
        {
            try
            {
                var customerEntity = new CustomerEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address
                };
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
            }
            catch { }
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Phone = customer.Phone, Address = customer.Address });
            return customers;
        }

        public async Task<CustomerModel> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerModel { Id = customerEntity.Id, FirstName = customerEntity.FirstName, LastName = customerEntity.LastName, Email = customerEntity.Email, Phone = customerEntity.Phone, Address = customerEntity.Address };

            return null!;
        }
    }
}
