using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidationAttribute.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [ExcludeChars("!@.")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MustUK]
        public string Country { get; set; }
    }
}