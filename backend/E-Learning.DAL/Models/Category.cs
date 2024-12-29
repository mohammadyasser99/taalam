namespace E_Learning.DAL.Models
{
    public class Category 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public List<Course> Courses { get; set; } = null!;
    }
}
