using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class CompletedLesson
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int LessonId { get; set; } 
        public Lesson Lesson { get; set; } = null!;

        public DateTime CompletedDate { get; set; } = DateTime.Now;
    }
}
