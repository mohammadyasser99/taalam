using E_Learning.BL.DTO.CourseDTO.CourseSectionDTO;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseContentDTO
{
    public class ReadCourseContentDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public List<ReadCourseSectionInfoDTO>? Sections { get; set; } = null!;
        public CourseEnrollmentInfoDTO? StudentEnrollment { get; set; }



    }
}
