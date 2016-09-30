using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class FutureDateAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DateFormat = "MM/dd/yyyy";
        private const string DefaultErrorMessage = "'{0}' must be a date between {1:d} and current date.";

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }

        public FutureDateAttribute(string min)
            : base(DefaultErrorMessage)
        {
            Min = ParseDate(min);
            Max = DateTime.Now;
        }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is DateTime))
            { return true; }
            DateTime dateValue = (DateTime)value;
            return Min <= dateValue && dateValue <= Max;
        }

        private static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, DateFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(System.Globalization.CultureInfo.CurrentCulture, ErrorMessageString, name, Min);
        }

        public class ModelClientValidationFutureDateRule : ModelClientValidationRule
        {
            public ModelClientValidationFutureDateRule(string errorMessage,
                DateTime min)
            {
                ErrorMessage = errorMessage;
                ValidationType = "futuredate";
                ValidationParameters["min"] = min.ToString("MM/dd/yyyy");
                ValidationParameters["max"] = DateTime.Now.ToString("MM/dd/yyyy");
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationFutureDateRule("Error message goes here", this.Min);
            yield return rule;
        }
    }
}