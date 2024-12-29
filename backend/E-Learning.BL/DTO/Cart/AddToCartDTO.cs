using System.ComponentModel.DataAnnotations;

namespace E_Learning.BL.DTO.Cart
{
    public class AddToCartDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }

    }
}
