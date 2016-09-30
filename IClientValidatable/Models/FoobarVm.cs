using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FoobarVm
    {
        [Required]
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
}