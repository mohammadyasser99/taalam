using E_Learning.BL.DTO.CourseDTO.CourseSectionDTO;
using E_Learning.BL.DTO.CourseDTO.InstructorInfoDTO;
using E_Learning.BL.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseUploadDTO
{
    public class UploadCourseDTO
    {
        public int? CourseId { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public string? CourseCategory { get; set; }
        public string? CoverPicture { get; set; }
        public decimal Price { get; set; } 
        public int SectionsNo { get; set; }
        public decimal? Rate { get; set; }  // derived
        public DateTime CreationDate { get; set; }
        public List<UploadSectionDto>? Sections { get; set; } = null!;

    }
}
        