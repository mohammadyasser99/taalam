using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.DAL.Models
{
    public class Enrollment
    {
        [Column(TypeName = "decimal(5,2)")]
        public decimal? ProgressPercentage { get; set; }
        public int? CompletedLessons { get; set; } // from client side
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public Course? Course { get; set; }
        public User? User { get; set; }

        public ICollection<CompletedLesson>? CompletedLessonsList { get; set; }
    }
}
