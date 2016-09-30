using ControllerFactory.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerFactory.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService _customerService;

        //public CustomerController()
        //    : this(new CustomerServiceImpl())
        //{
        //}

        public CustomerController(CustomerService customerService)
        {
            this._customerService = customerService;
        }

        //
        // GET: /Customer/
        public ActionResult Index()
        {
            var customers = _customerService.Get();
            return View(customers);
        }
	}
}