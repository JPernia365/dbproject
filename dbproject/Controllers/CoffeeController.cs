using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbproject.Models;
using dbproject.ViewModels; //always add yourself


namespace dbproject.Controllers
{
    public class CoffeeController : Controller
    {
        

       
        // GET: Coffee
        public ActionResult Random()
        {
            var coffee = new Coffee() {  Name   = "Espresso" };

            var customers = new List<Customer> { };
           // {
               // new Customer { Name = "Customer 1"},
               // new Customer { Name = "Customer 2"}
           // };//make a list of customers linked to the model <-->controller
            
            var viewModel = new RandomCoffeeViewModel
            {
                Coffee = coffee,
                customers = customers
            };
            

            return View(viewModel);

            //different outcomes for actionResult
            // return Content("Hello Wordl");
            //return HttpNotFound();
            // return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        public ActionResult ByType( string bean,string size)
        {
            return Content(bean+ "-"+ size);
        }


        

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}


