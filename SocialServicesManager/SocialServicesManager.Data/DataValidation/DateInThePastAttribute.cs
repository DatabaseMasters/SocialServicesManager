using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialServicesManager.Data.DataValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DateInThePastAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var pastDate = value as DateTime?;
            var memberNames = new List<string>() { context.MemberName };

            if (pastDate != null)
            {
                if (pastDate.Value.Date > DateTime.UtcNow.Date)
                {
                    return new ValidationResult("Date must be in the past.", memberNames);
                }
            }

            return ValidationResult.Success;
        }
    }
}
