using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    class MustLiveInNewcastle : ValidationAttribute, IClientValidatable
    {
        private CustomerRepository _repository;

        public MustLiveInNewcastle()
        {
            _repository = new CustomerRepository();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var isValid = _repository.MustLiveInNewcastle(value);
                if (!isValid)
                {
                    return new ValidationResult("Must live in newcastle");
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new System.Web.Mvc.ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());            
            rule.ValidationType = "mustliveinnewcastle";
            yield return rule;
        }
    }
}
