﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        //DB context
        private ApplicationDbContext _context;

        //constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET: /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {

            if (query != null)
            {
                var customers = _context.Customers
                    .Include(c => c.MembershipType)
                    .Where(c => c.Name.Contains(query))
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>);
                return Ok(customers);
            }
            else
            {
                var customers = _context.Customers
                    .Include(c => c.MembershipType)
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>);
                return Ok(customers);
            }
            
        }

        //GET: /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                                   .Include(m => m.MembershipType)
                                   .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST: /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri($"{Request.RequestUri}/{customerDto.Id}"), customerDto);
        }

        //PUT: /api/customers/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();

            return Ok();
        }

        //DELETE: /api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            var customer = Mapper.Map<Customer, CustomerDto>(customerInDb);

            return Ok(content: customer);
        }
    }
}
