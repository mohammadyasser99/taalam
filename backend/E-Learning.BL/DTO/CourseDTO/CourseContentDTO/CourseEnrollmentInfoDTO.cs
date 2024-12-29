using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.CourseContentDTO
{
    public class CourseEnrollmentInfoDTO
    {
        public decimal? ProgressPercentage { get; set; }
        public int? CompletedLessons { get; set; } 
        public DateTime? EnrollmentDate { get; set; }


    }
}
