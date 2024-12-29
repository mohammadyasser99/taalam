using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.DAL.Models
{
    public class User : IdentityUser<int>
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Linkedin { get; set; }
        public string? Youtube { get; set; }
        public string? Twitter { get; set; }
        public string? GitHub { get; set; }
        //public string? TotalStudent { get; set; }


        //[DefaultValue("../../aa.jpeg")]
        public string? ProfilePicture { get; set; }
        public List<Course>? OwnedCourses { get; set; }
        public List<Cart>? CartItems { get; set; }
        public List<Enrollment>? UserEnrollments { get; set; }

        public List<WishList>? WishListItems { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationDateTime { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<CompletedLesson>? CompletedLessonsList { get; set; }
        public ICollection<CertificateOfCompletion>? CertificatesOfCompletion { get; set; }



    }
}
