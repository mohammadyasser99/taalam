namespace E_Learning.DAL.Models
{
    public class Quiz 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Grade { get; set; }
        public List<Question> Questions { get; set; } = null!;
        public int SectionId { get; set; }
        public Section Section { get; set; } = null!;
    }
}
