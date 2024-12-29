using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.BL.DTO.User
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverPicture { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal? Rate { get; set; }
        public string? Category { get; set; }
    }
}
