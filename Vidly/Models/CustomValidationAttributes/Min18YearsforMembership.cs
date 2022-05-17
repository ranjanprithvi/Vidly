using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidationAttributes
{
    public class Min18YearsforMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipCode == MembershipCode.PayAsYouGo || customer.MembershipCode == MembershipCode.Unknown)
                return ValidationResult.Success;
            else
            {
                if (customer.Birthdate == null)
                    return new ValidationResult("Birthdate is required");

                if ((DateTime.Today - customer.Birthdate).Value.TotalDays / 365 < 18)
                    return new ValidationResult("Customer should be at least 18 years old for membership");

                return ValidationResult.Success;
            }
        }
    }
}