using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customers customer = (Customers)validationContext.ObjectInstance;

            if (customer.membershipTypeId == MembershipType.unknown 
                || customer.membershipTypeId == MembershipType.payOnGo)
                return ValidationResult.Success;

            if(customer.birthdate == null)
            {
                return new ValidationResult("You must enter birthdate");
            }

            int age = DateTime.Today.Year - customer.birthdate.Value.Year;

            if(age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The age must be greater or equal 18");
            }
        }
    }
}