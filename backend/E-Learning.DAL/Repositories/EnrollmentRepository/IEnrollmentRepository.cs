using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;

namespace E_Learning.DAL.Repositories.EnrollmentRepository
{
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {

        bool IsStudentEnrolled (int userId, int courseId);
        bool IsStudentEnrolled(int userId);
        public Enrollment? GetEnrollment(int userId, int courseId);


        void AddEnrollment(Enrollment enrollment);

        void UpdateEnrollment(Enrollment enrollment);
        public bool IsEnrollmentComplete(int userId, int courseId);


        Task<bool> IsStudentEnrolledAsync(int userId, int courseId);
    }
}
