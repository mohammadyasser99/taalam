namespace E_Learning.BL.DTO.User
{
    public class InstructorDTO
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Description { get; set; }
        public string? Github { get; set; }
        public string? Facebook { get; set; }
        public string? Linkedin { get; set; }
        public string? Youtube { get; set; }
        public string? Twitter { get; set; }
        public string? ProfilePicture { get; set; }
     
        public int TotalStudents { get; set; }
        public List<CourseDTO>? OwnedCourses { get; set; }
    }
}
