using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbproject.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int points { get; set; }
        public int rating { get; set; }

        //view model is specifically made for one view separate for other
    }
}