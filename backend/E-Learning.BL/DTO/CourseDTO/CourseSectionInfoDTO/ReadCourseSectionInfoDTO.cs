using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseLessonDTO;
using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseQuizInfoDTO;
using E_Learning.DAL.Models;

namespace E_Learning.BL.DTO.CourseDTO.CourseSectionDTO
{
    public class ReadCourseSectionInfoDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int LessonsNo { get; set; } 
        public int SectionNumber { get; set; }
        public List<ReadCourseLessonDTO>? Lessons { get; set; }
        public List<ReadCourseQuizInfoDTO>? Quizes { get; set; }


    }
}
