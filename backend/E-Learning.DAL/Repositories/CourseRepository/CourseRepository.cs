using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_Learning.DAL.Repositories.CourseRepository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public Course getCourseDetailsById(int id)
        {
            var course = _context.Courses
                .Include(c => c.Sections)
                    .ThenInclude(s => s.Lessons)
                .Include(c => c.Sections)
                    .ThenInclude(s => s.Quizes)
                .Include(c => c.Category)
                .Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);

            return course;
        }

        public (Course, Enrollment) GetCourseContentForUser(int userId, int courseId)
        {
            var course = _context.Courses
                .Include(c => c.Sections)
                    .ThenInclude(s => s.Lessons)
                .Include(c => c.Sections)
                    .ThenInclude(s => s.Quizes)
                .FirstOrDefault(c => c.Id == courseId);

            var enrollment = _context.Enrollments
                 .Include(e => e.CompletedLessonsList)
                .FirstOrDefault(e => e.CourseId == courseId && e.UserId == userId);

            if (course == null || enrollment == null)
            {
                return (null, null);
            }

            return (course, enrollment);

        }

        public HashSet<int> GetCompletedLessonIdsForUserAndCourse(int userId, int courseId)
        {
            return _context.CompletedLessons
                .Where(cl => cl.UserId == userId && cl.CourseId == courseId)
                .Select(cl => cl.LessonId)
                .ToHashSet();
        }

        
        public void CreateCertificate(int userId, int courseId)
        {
            
           var newCert = _context.CertificatesOfCompletion.Add(new CertificateOfCompletion
            {
                UserId = userId,
                CourseId = courseId
            });  

            


        }

        public CertificateOfCompletion? GetCertOfComp(int userId, int courseId)
        {
            return _context.CertificatesOfCompletion
               .Include(c => c.User)   
               .Include(c => c.Course) 
               .FirstOrDefault(c => c.UserId == userId && c.CourseId == courseId);
        }

        public bool CertAlreadyExists(int userId, int courseId)
        {
            return _context.CertificatesOfCompletion.Any(c => c.UserId == userId && c.CourseId == courseId);

            
        }

        public IEnumerable<Course> GetPaginatedCourses(
            string searchTerm,
            int page,
            int pageSize,
            string sortBy,
            string sortOrder,
            out int totalCourses)
        {
            var query = _context.Courses
                .Include(c => c.User)
                .Include(c => c.Category)
                .Include(c => c.Enrollments)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => c.Title.Contains(searchTerm) ||( c.Description!=null&& c.Description.Contains(searchTerm)));
            }

            // Apply sorting
            switch (sortBy.ToLower())
            {
                case "title":
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(c => c.Title) : query.OrderBy(c => c.Title);
                    break;

                case "createddate":
                case "creationdate":
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(c => c.CreationDate) : query.OrderBy(c => c.CreationDate);
                    break;

                case "categoryname": // Sorting by Category
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(c => c.Category.Name) : query.OrderBy(c => c.Category.Name);
                    break;

                case "instructorname": // Sorting by Instructor Name (User's Full Name)
                    query = sortOrder.ToLower() == "desc"
                        ? query.OrderByDescending(c => c.User.FName + " " + c.User.LName)
                        : query.OrderBy(c => c.User.FName + " " + c.User.LName);
                    break;

                default:
                    query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(c => c.Id) : query.OrderBy(c => c.Id);
                    break;
            }

            totalCourses = query.Count();

            var paginatedCourses = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return paginatedCourses;
        }

        public void DeleteCourse(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            if (course != null)
            {
                course.IsDeleted = true;
                _context.SaveChanges();
            }
        }





        /////////////////////////////////////////////////////////////
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.User).Include(c => c.Category);
        }

        public IEnumerable<Course> SearchCourses(string searchTerm)
        {
            return _context.Courses.Include(c => c.User).Include(c => c.Category)
           .Where(c => c.Title.Contains(searchTerm) || c.Description.Contains(searchTerm));
        }
        public IEnumerable<Course> GetAllCoursesByUserId(int userId)
        {
            return _context.Courses
                  .Include(c => c.Enrollments)
                  .Include(c => c.User)
                  .Include(c => c.Category)
                  .Where(c => c.Enrollments.Any(e => e.UserId == userId))
                  .ToList();
        }

        public IEnumerable<Course> GetInstructorCourses(int id)
        {
            return _context.Courses.Where(c => c.UserId == id);
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Include(c=>c.Category).Include(c=>c.Sections).ThenInclude(l =>l.Lessons).FirstOrDefault(c => c.Id == id);
        }


        public void updateCourse(Course course) {
            _context.Courses.Update(course);

        }

    }
}
