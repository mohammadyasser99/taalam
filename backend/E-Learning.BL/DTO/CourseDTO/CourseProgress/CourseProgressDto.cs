using E_Learning.BL.DTO.CourseDTO.CourseSectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseProgress
{
    public class CourseProgressDto
    {
        public int CourseId { get; set; }
        public string? CourseTitle { get; set; }
        public decimal ProgressPercentage { get; set; }
        public List<ReadCourseSectionInfoDTO>? Sections { get; set; }
    }
}
