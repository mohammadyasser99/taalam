using System.ComponentModel.DataAnnotations;

namespace E_Learning.BL.DTO.CourseDTO.CourseRatingDTO
{
    public class CreateRatingByUser
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int Value { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int UserId { get; set; } 
    }
}
