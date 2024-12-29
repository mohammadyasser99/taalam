using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories.WishListRepository
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        IEnumerable<WishList> GetWishListItemsByUserId(int userId);
        WishList? GetWishListItem(int userId, int courseId);
        public bool WishListITemExists(int userId, int courseId);

    }
}
