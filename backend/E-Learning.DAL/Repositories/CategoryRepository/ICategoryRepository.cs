using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;

namespace E_Learning.DAL.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetByIdWithCourses(int id);
        public int GetCategoryIdByName(string categoryName);
    }
}
