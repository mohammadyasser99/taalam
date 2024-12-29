using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseAdminDTO
{
    public class PaginatedCourseResponseDTO
    {
        
            public IEnumerable<CourseAdminDTO> Courses { get; set; }
            public int TotalCourses { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        
    }
}
