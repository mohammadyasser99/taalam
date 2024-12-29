using System.ComponentModel.DataAnnotations;

namespace E_Learning.BL.DTO.CourseDTO.CourseRatingDTO
{
    public class ReadCourseRatingByUserDTO
    {

        public int Id { get; set; }

        public ReadCourseInfoForRatingDTO Course { get; set; } = null!;

        [Range(1, 5)]
        [Required]
        public int Value { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }

    }
}
