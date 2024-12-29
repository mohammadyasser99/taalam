
namespace E_Learning.DAL.Models
{
    public class CertificateOfCompletion
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int CourseId {  get; set; }

        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;

        public DateTime IssuedAy { get; set; } = DateTime.Now;



    }
}
