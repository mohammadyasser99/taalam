using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.LessonRepository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext _context) : base(_context)
        {
        }

        public bool MarkLessonAsComplete(int userId, int lessonId, int courseId)
        {
            if (IsLessonCompleted(userId,lessonId))
            {
                return false;
            }

            var completedLesson = new CompletedLesson
            {
                UserId = userId,
                LessonId = lessonId,
                CourseId = courseId,
                CompletedDate = DateTime.Now
            };

            _context.CompletedLessons.Add(completedLesson);

            _context.SaveChanges();
            return true;
        }

        public bool MarkLessonAsNotComplete(int userId, int lessonId)
        {
            if (!IsLessonCompleted(userId, lessonId))
            {
                return false;
            }

            var completedLesson =  _context.CompletedLessons
                .FirstOrDefault(cl => cl.UserId == userId && cl.LessonId == lessonId);

            if (completedLesson != null)
            {
                _context.Set<CompletedLesson>().Remove(completedLesson);
                 _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool IsLessonCompleted(int lessonId, int userId)
        {
            return _context.CompletedLessons.Any(l => l.UserId == userId && l.LessonId == lessonId);
        }

        public int GetTotalLessonsForCourse(int courseId)
        {
            var course = _context.Courses
                .Include(c => c.Sections)
                .ThenInclude(s => s.Lessons)
                .FirstOrDefault(c => c.Id == courseId);

            return course?.Sections.Sum(section => section.Lessons.Count) ?? 0;
        }

    }
}
