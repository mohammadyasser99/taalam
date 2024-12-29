using E_Learning.BL.DTO.CourseDTO.CourseSectionDTO;
using E_Learning.BL.DTO.CourseDTO.InstructorInfoDTO;
using E_Learning.BL.Dtos.Category;

namespace E_Learning.BL.DTO.Course
{
    public class ReadOneCourseDetailsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverPicture { get; set; }
        public decimal Price { get; set; }
        public decimal? Rate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int SectionsNo { get; set; }
        public ReadCategoryDto? CourseCategory { get; set; } = null!;
        public List<ReadCourseSectionInfoDTO>? Sections { get; set; } = null!;
        public ReadCourseInstructorInfoDTO? Instructor { get; set; }


    }
}
