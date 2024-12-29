using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Learning;
namespace E_Learning.DAL.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        [Required(ErrorMessage = "End of sale date is required")]
        [FutureDate(ErrorMessage = "The end of sale date must be in the future")]

        public DateTime EndOfSale { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; }


    }

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
