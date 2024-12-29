using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.LessonRepository
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        bool MarkLessonAsComplete(int userId, int lessonId, int enrollmentId);
        bool MarkLessonAsNotComplete(int userId, int lessonId);

        bool IsLessonCompleted(int lessonId, int userId);

        public int GetTotalLessonsForCourse(int courseId);



    }
}
