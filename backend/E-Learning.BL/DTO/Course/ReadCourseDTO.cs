using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.Course
{
    public class ReadCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Rate { get; set; }
        public string? CoverPicture { get; set; }
        public string CategoryName { get; set; }
        public string? Duration { get; set; }

    }
}
