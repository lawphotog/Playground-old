using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples
{
    public class Contact
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public Contact(String firstname, String lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public String GetFullName() 
        {
            return LastName + ", " + FirstName;
        }
    }
}
