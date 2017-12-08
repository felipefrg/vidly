using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_2.Models;
using Vidly_2.Models.DTO;

namespace Vidly_2.Controllers.API
{
    public class CustomerController : ApiController
    {
        ApplicationDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<CustomerModelDTO> Get()
        {
            return _dbContext.Customer.ToList().Select(Mapper.Map<CustomerModel, CustomerModelDTO>);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var customer = _dbContext.Customer.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CustomerModel,CustomerModelDTO>(customer));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(CustomerModelDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerModelDTO,CustomerModel>(customerDTO);

            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri($"{ Request.RequestUri }/{customer.Id}"),customerDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, CustomerModelDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _dbContext.Customer.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<CustomerModelDTO, CustomerModel>(customerDTO, customerInDb);

            _dbContext.SaveChanges();

            return Ok(customerDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _dbContext.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }


            _dbContext.Customer.Remove(customerInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}