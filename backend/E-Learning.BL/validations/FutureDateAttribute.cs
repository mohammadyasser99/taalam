using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.validations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateValue = (DateTime)value;

                if (dateValue <= DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage ?? "The date must be in the future");
                }
            }

            return ValidationResult.Success;
        }
    }

}