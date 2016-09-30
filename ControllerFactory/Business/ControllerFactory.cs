using ControllerFactory.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerFactory.Business
{
    public class MyControllerFactory: DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Customer")
            {
                return new CustomerController(new CustomerServiceImpl());
            }
            else
            {
                return base.CreateController(requestContext, controllerName);
            }           
        }
    }
}