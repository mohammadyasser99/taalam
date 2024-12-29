namespace E_Learning.DAL.Models
{
    public class Section 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int LessonsNo { get; set; } //for display
        public int CourseId { get; set; }
        public int SectionNumber { get; set; }
        public Course Course { get; set; } = null!;
        public List<Lesson>? Lessons { get; set; }
        public List<Quiz>? Quizes { get; set; }
    }
}
