using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseUploadDTO
{
    public class UploadLessonDto
    {
        public int? LessonId { get; set; }
        public string LessonTitle { get; set; }
        public string LessonUrl { get; set; }
    }
}
