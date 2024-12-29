using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseLessonDTO;
using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseQuizInfoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseUploadDTO
{
    public class UploadSectionDto
    {
        public int? SectionId { get; set; }
        public string? SectionTitle { get; set; }
        public int NumberOfLessons { get; set; }
        public List<UploadLessonDto>? Lessons { get; set; }

    }
}
