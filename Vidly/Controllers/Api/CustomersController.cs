using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersModel = _context.Customers.Include(c =>c.MembershipType).ToList();
            var customersDto = Mapper.Map<IEnumerable<CustomerDto>>(customersModel);
            return customersDto;
            //return _context.Customers.ToList().Select(Mapper.Map<CustomerDto>);
        }

        //GET /api/Customers/{id}
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        // POST/ api/Customers
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            var customerModel = Mapper.Map<Customer>(customerDto);
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customerModel);
            _context.SaveChanges();

            customerDto.Id = customerModel.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerModel.Id),customerDto);
        }

        //PUT api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); // can pass if object already exist CustomerinDb


            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
