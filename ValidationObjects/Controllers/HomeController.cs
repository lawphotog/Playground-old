using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ValidationObjects.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var persons = new List<Person>()
            {
                new Person{ Id = 1, Forename = "George", Surname = "", DateOfBirth = DateTime.Now, Country = "UK" },
                new Person{ Id = 2, Forename = "Fred", Surname = "Weasley", DateOfBirth = DateTime.Now, Country = "UK" },
                new Person{ Id = 3, Forename = "", Surname = "", DateOfBirth = DateTime.Now, Country = "UK" },
                new Person{ Id = 4, Forename = "John", Surname = "", DateOfBirth = DateTime.Now, Country = "Korea" },
            };

            var valErrors = new List<ValidationError>();
            var valError = new ValidationError();

            foreach (var p in persons)
            {
                var validator = new Validatr();
                string message = string.Empty;
                if (!validator.Validate(p, ref message))
                {
                    valError = new ValidationError { PersonId = p.Id, Message = message };
                    valErrors.Add(valError);
                }
            }            

            return View(valErrors);
        }

        public class Validatr
        {
            public bool Validate(Person p, ref String Message)
            {
                var isValid = true;
                var sb = new StringBuilder();

                if(p.Forename.Length > 50)
                {
                    p.Forename = p.Forename.Substring(0, 50);
                    sb.Append("Some forenames are too long and trancated to 50 characters.");                    
                }

                if(p.Forename == "")
                {                    
                    sb.Append("Forename is required<br />");
                    isValid = false;
                }

                if(p.Surname == "")
                {
                    sb.Append("Surname is required<br />");
                    isValid = false;
                }

                Message = sb.ToString();

                return isValid;
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Country { get; set; }
        }

        public class ValidationError
        {
            public int PersonId { get; set; }
            public string Message { get; set; }
        }
    }
}