using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;

namespace Vidly_2.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _dbContext;

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
        }

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Customer
        [Route("Customer/Index")]
        public ActionResult Index()
        {
            var customers = _dbContext.Customer.Include(c=> c.MembershipType).ToList();

            return View(customers);
        }

        [Route("Customer/Detail/{id ?}")]
        public ActionResult Detail(int? Id)
        {

            if (!Id.HasValue)
                Id = 1;

            var customer = _dbContext.Customer.Include(c => c.MembershipType).Where(c => c.Id == Id).FirstOrDefault();

            return View(customer);
        }
    }
}