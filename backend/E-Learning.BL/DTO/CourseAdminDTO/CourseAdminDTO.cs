
namespace E_Learning.BL.DTO.CourseAdminDTO
{
    public class CourseAdminDTO
    {
        
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string CategoryName { get; set; }
            public string InstructorName { get; set; }
            public int EnrollmentCount { get; set; }
            public DateTime CreationDate { get; set; }
    }
}
