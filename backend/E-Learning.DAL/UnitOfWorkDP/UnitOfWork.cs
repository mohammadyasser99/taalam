using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Repositories.AnnouncementRepository;
using E_Learning.DAL.Repositories.AnswerRepository;
using E_Learning.DAL.Repositories.CartRepository;
using E_Learning.DAL.Repositories.CategoryRepository;
using E_Learning.DAL.Repositories.CourseRepository;
using E_Learning.DAL.Repositories.EnrollmentRepository;
using E_Learning.DAL.Repositories.LessonRepository;
using E_Learning.DAL.Repositories.QuestionRepository;
using E_Learning.DAL.Repositories.QuizRepository;
using E_Learning.DAL.Repositories.RatingRepository;
using E_Learning.DAL.Repositories.SectionRepository;
using E_Learning.DAL.Repositories.UserRepository;
using E_Learning.DAL.Repositories.WishListRepository;

namespace E_Learning.DAL.UnitOfWorkDP
{
    public class UnitOfWork : IUnitOfWork
    {
        /*------------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        /*------------------------------------------------------------------------*/
        public IAnswerRepository AnswerRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IEnrollmentRepository EnrollmentRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IQuizRepository QuizRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWishListRepository WishListRepository { get; }

        public IRatingRepository RatingRepository { get; }

        public IAnnouncementRepository AnnouncementRepository { get; }
        /*------------------------------------------------------------------------*/
        public UnitOfWork
             (AppDbContext context)
        {
            _context = context;
            AnswerRepository = new AnswerRepository(_context);
            CartRepository = new CartRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            CourseRepository = new CourseRepository(_context);
            EnrollmentRepository = new EnrollmentRepository(_context);
            LessonRepository = new LessonRepository(_context);
            QuestionRepository = new QuestionRepository(_context);
            QuizRepository = new QuizRepository(_context);
            SectionRepository = new SectionRepository(_context);
            UserRepository = new UserRepository(_context);
            WishListRepository = new WishListRepository(_context);
            RatingRepository = new RatingRepository(_context);
            AnnouncementRepository = new AnnouncementRepository(_context);
        }
        /*------------------------------------------------------------------------*/
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        /*------------------------------------------------------------------------*/
    }
}
