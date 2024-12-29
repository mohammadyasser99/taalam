namespace E_Learning.DAL.Models
{
    public class Question 
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public int ModelAnswer { get; set; } // ID
        public List<Answer> Answers { get; set; } = null!; // for display
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
    }
}
