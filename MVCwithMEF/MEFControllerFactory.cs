using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCwithMEF
{
    public class MEFControllerFactory : DefaultControllerFactory
    {
        static CompositionContainer container;

        static MEFControllerFactory()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            container = new CompositionContainer(catalog);
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);

            container.ComposeParts(controller);

            return controller;
        }
    }
}