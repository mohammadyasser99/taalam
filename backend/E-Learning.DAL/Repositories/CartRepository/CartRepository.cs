using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.CartRepository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {

        public CartRepository(AppDbContext _context) : base(_context)
        {
        }


        public IEnumerable<Cart> GetCartItemsByUserId(int userId)
        {
            return _context.Carts.Include(c => c.Course ).ThenInclude(course => course.User).Where(c => c.UserId == userId);
        }
        public Cart? GetCartItem(int userId, int courseId)
        {
            return _context.Carts.FirstOrDefault(c => c.UserId == userId && c.CourseId == courseId);
        }
        public decimal GetCartTotalByUserId(int userId)
        {
            // return _context.Carts.Where(c => c.UserId == userId).Sum(c => c.Course.Price);
            return _context.Carts.Where(c => c.UserId == userId).Sum(c => (decimal?)c.Course.Price) ?? 0;
        }

        public bool CartItemExists(int userId, int courseId)
        {
            return _context.Carts.Any(c => c.UserId==userId && c.CourseId == courseId);
        }
    }
}
