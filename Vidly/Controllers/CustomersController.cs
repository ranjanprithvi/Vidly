using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            return View("CustomerForm", new CustomerFormViewModel {
                Customer = new Customer(),
                MembershipTypes = membershiptypes});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerinDb.Name = customer.Name;
                customerinDb.Birthdate = customer.Birthdate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Route("customers/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer != null)
                return View(customer);
            else
                return HttpNotFound("Customer Not Found");
        }

        [Route("customers/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDb == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customerinDb,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}