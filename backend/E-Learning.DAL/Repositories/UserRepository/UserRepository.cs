using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _context) : base(_context)
        {
        }

        public User GetInstructorInfo(int id)
        {
            return _context.Users.Include(c => c.OwnedCourses).ThenInclude(c=>c.Category).Include(e=>e.UserEnrollments).FirstOrDefault(i => i.Id == id);
        }

        public int CountEnrollment(int id)
        {
            return _context.Enrollments.Count(e => e.CourseId == id);
        }

    }
}
