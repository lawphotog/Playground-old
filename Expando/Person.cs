using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String GetFullName()
        {
            return String.Format("{0}, {1}", LastName, FirstName);
        }
    }
}
