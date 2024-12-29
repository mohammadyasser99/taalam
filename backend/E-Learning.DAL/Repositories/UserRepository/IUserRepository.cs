using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;

namespace E_Learning.DAL.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetInstructorInfo(int id);
        public int CountEnrollment(int id);
    }
}
