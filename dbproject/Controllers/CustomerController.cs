using dbproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbproject.Controllers
{
    public class CustomerController : Controller
    {
        private qahwa db = new qahwa();



        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }
        // GET: Customer
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.customer_id == id); //unanimous function transverses

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> { };
            //{
              //  new Customer { Id = 1, Name = "Toludepo NoLastName"},
               // new Customer { Id = 2, Name = "GiGi TranTran"}
            //};
            
        }
    }
}