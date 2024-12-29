namespace E_Learning.DAL.Models
{
    public class Answer 
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
