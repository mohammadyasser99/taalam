using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseDTO.InstructorInfoDTO;

namespace E_Learning.BL.DTO.CourseDTO.CertDTO
{
    public class CertificateOfCompletionDto
    {
        public string Id { get; set; }
        public DateTime IssuedAy { get; set; }
        public ReadCourseInstructorInfoDTO User { get; set; }
        public ReadOneCourseDetailsDto Course { get; set; }
    }
}
