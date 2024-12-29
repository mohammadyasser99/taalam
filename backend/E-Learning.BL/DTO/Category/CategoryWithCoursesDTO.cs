using E_Learning.BL.DTO.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.Category
{
    public class CategoryWithCoursesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReadCourseDTO> Courses { get; set; } = new List<ReadCourseDTO>();
    }
}
