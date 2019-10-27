using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
        //[Route("Customers/Details/{custId:regex(\\d)}")]
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
    }
}