using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.CourseDTO.EnrollmentDTO
{
    public class EnrollPostRequestDTO
    {
        [Required]
        public int CourseId { get; set; }
    }
}
