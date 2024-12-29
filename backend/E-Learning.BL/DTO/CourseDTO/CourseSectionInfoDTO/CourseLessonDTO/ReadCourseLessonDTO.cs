using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseLessonDTO
{
    public class ReadCourseLessonDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public string? Content  { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
