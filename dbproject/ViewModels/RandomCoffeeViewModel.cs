using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dbproject.Models;

namespace dbproject.ViewModels
{
    public class RandomCoffeeViewModel
    {
        internal List<Customer> customers;

        public Coffee Coffee { get; set; }
        public List<Customer> Customers { get; set;}
    }
}