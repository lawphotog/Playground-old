using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CustomValidationAttribute.Models
{
    class MustUKAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationcontext)
        {
            if(value != null)
            {
                if(value.ToString().ToLower() != "uk")
                {
                    //var errorMessage = FormatErrorMessage(validationcontext.DisplayName);
                    var errorMessage = "You must be in the UK";
                    return new ValidationResult(errorMessage);
                }                
            }
            
            return ValidationResult.Success;
        }
    }
}
