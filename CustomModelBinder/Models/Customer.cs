﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomModelBinder.Models
{
    public class Customer: Person
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}