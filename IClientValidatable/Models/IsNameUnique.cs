using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class IsNameUnique : ValidationAttribute
    {
        private CustomerRepository _repository;

        public IsNameUnique()
        {
            _repository = new CustomerRepository();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var isValid = _repository.IsNameUnique(value);
                if(!isValid)
                {
                    return new ValidationResult("Name must be unique");
                }
            }

            return ValidationResult.Success;
        }        
    }
}