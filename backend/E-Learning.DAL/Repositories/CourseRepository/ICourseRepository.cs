using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.CourseRepository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Course getCourseDetailsById(int id);
        (Course, Enrollment) GetCourseContentForUser(int userId, int courseId);

        HashSet<int> GetCompletedLessonIdsForUserAndCourse(int userId, int courseId);

        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> SearchCourses(string searchTerm);
        IEnumerable<Course> GetAllCoursesByUserId(int id);

        IEnumerable<Course> GetInstructorCourses(int id);

        Course GetCourseById(int id);



        public void CreateCertificate(int userId, int courseId);

        public bool CertAlreadyExists(int userId, int courseId);
        public CertificateOfCompletion? GetCertOfComp(int userId, int courseId);


        public void updateCourse(Course course);

        public IEnumerable<Course> GetPaginatedCourses(string searchTerm, int page, int pageSize, string sortBy, string sortOrder, out int totalCourses);
        public void DeleteCourse(int courseId);





    }
}
