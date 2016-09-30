using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerFactory.Business
{
    public class CustomerServiceImpl : ControllerFactory.Business.CustomerService
    {
        public IEnumerable<Customer> Get()
        {
            return new List<Customer> 
            {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 1, Name = "Smith" } 
            };
        }
    }
}