using E_Learning.BL.DTO.User;

namespace E_Learning.BL.DTO.CourseDTO.CourseRatingDTO
{
    public class ReadCourseRatingDTO
    {

        public int Id { get; set; }

        public ReadUserInfoForRating Student { get; set; } = null!;

        public int Value { get; set; }
        public string? Description { get; set; }

      

    }
}
