using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ControllerFactory.Business
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [AllowHtml]
        public string Comments { get; set; }
    }
}
