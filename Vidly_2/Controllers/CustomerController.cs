using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;
using Vidly_2.ViewModel;

namespace Vidly_2.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _dbContext;
        IList<MembershipTypeModel> LstMembershipType;

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
        }

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();

            this.LstMembershipType = _dbContext.MembershipType.ToList();
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


            var customerViewModel = new CustomerViewModel()
            {
                Customer = customer,
                LstMembershipType = this.LstMembershipType
            };

            return View(customerViewModel);
        }

        [Route("Customer/New")]                
        public ActionResult New()
        {
            var customerViewModel = new CustomerViewModel()
            {
                Customer = new CustomerModel(),
                LstMembershipType = this.LstMembershipType
            };

            return View("FormCustomer",customerViewModel);
        }

        [HttpPost]        
        public ActionResult Save(CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {

            }

            if (customer.Id <= 0)
            {
                _dbContext.Customer.Add(customer);
            }
            else
            {
                var dbcustomer = _dbContext.Customer.SingleOrDefault(c => c.Id == customer.Id);
                dbcustomer.Name = customer.Name;
                dbcustomer.LastName = customer.LastName;
                dbcustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                dbcustomer.MembershiptypeId = customer.MembershiptypeId;
            }

            int intResult = _dbContext.SaveChanges();

            return RedirectToAction("Index","Customer");
        }
        
        [Route("Customer/Edit/{id ?}")]
        public ActionResult Edit(int Id)
        {
            var customer = _dbContext.Customer.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return new HttpNotFoundResult();

            var customerViewModel = new CustomerViewModel()
            {
                Customer = customer,
                LstMembershipType = this.LstMembershipType
            };

            return View("FormCustomer",customerViewModel);
        }
    }
}