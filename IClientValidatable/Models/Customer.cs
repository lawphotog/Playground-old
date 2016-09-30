using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [IsNameUnique]
        [Required]
        public string Name { get; set; }

        [MustLiveInNewcastle]
        [Required]
        public string City { get; set; }
    }
}