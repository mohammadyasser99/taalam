using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace E_Learning.BL.DTO.CourseDTO.InstructorInfoDTO
{
    public class ReadCourseInstructorInfoDTO
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Description { get; set; }

        public string? ProfilePicture { get; set; }


    }
}
