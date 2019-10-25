using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //List<Customers> customers;
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        //Customers/Details/1
        //[Route("Customers/Details/{custId:regex(\\d)}")]
        public ActionResult Details(int custId)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.customerId == custId);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
                return View(customer);
        }

        private IEnumerable<Customers> GetCustomers()
        {
            return new List<Customers>
            {
                new Customers { customerId = 1, customerName = "John Smith" },
                new Customers { customerId = 2, customerName = "Mary Williams" },
                new Customers { customerId = 3 , customerName="Ahmed Elsabagh"},
                new Customers { customerId = 4, customerName ="Amr Fetait"}
            };
        }
    }
}