using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Category GetByIdWithCourses(int id)
        {
            return _context.Categories.Where(c => c.Id == id).Include(c => c.Courses).ThenInclude(c => c.User).FirstOrDefault();
        }

        public int GetCategoryIdByName(string categoryName)
        {
            Category? category = _context.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
            if(category == null)
            {
                _context.Categories.Add(new Category { Name = categoryName });
            }
            return category.Id;
        }

    }
}
