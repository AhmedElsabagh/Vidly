using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.customers.Include(c => c.membershipType).ToList();  //GetCustomers();
            return View(customers);
        }

        //Customers/Details/1
        [Route("Customers/Details/{custId}")]
        public ActionResult Details(int custId)
        {
            var customer = _context.customers.Include(c => c.membershipType).SingleOrDefault(c => c.customerId == custId);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
                return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerDataViewModel
            {
                membershipTypes = _context.membershipTypes.ToList(),
                customer = new Customers()
            };

            return View("CustomerData", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerDataViewModel
                {
                    membershipTypes = _context.membershipTypes.ToList(),
                    customer = customer
                };

                return View("CustomerData", viewModel);
            }

            if (customer.customerId == 0)
                _context.customers.Add(customer);
            else
            {
                var customerDB = _context.customers.Single(c => c.customerId == customer.customerId);
                customerDB.customerName = customer.customerName;
                customerDB.birthdate = customer.birthdate;
                customerDB.isSubscripedToNewsletter = customer.isSubscripedToNewsletter;
                customerDB.membershipTypeId = customer.membershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CustomerDataViewModel
            {
                membershipTypes = _context.membershipTypes.ToList(),
                customer = _context.customers.SingleOrDefault(c=> c.customerId == id)
            };

            return View("CustomerData", viewModel);
        }
    }
}