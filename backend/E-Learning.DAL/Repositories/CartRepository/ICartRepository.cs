using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;

namespace E_Learning.DAL.Repositories.CartRepository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        IEnumerable<Cart> GetCartItemsByUserId(int userId);
        Cart? GetCartItem(int userId, int courseId);
        public decimal GetCartTotalByUserId(int userId);
        public bool CartItemExists(int userId, int courseId);
    }
}
