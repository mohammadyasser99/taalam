using System.ComponentModel.DataAnnotations;

namespace E_Learning.BL.DTO.WishList
{
    public class AddToWishListDTO
    {
            [Required]
            public int UserId { get; set; }

            [Required]
            public int CourseId { get; set; }

        
    }
}
