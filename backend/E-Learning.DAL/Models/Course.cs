using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.DAL.Models
{
    public class Course 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverPicture { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal? Rate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public int LessonsNo { get; set; }
        public int SectionsNo { get; set; }
        public string? Duration { get; set; } // check logic laterrr
        public List<Section> Sections { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<Cart>? Carts { get; set; }
        public List<Enrollment>? Enrollments { get; set; }
        public List<WishList>? WishLists { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<CertificateOfCompletion>? CertificatesOfCompletion { get; set; }

        public bool IsDeleted { get; set; } // Soft delete flag



    }
}
