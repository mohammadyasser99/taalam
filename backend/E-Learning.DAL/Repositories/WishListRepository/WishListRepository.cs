using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories.WishListRepository
{
    public class WishListRepository:GenericRepository<WishList>, IWishListRepository
    {
        public WishListRepository(AppDbContext _context) : base(_context)
        {
        }


        public IEnumerable<WishList> GetWishListItemsByUserId(int userId)
        {
            return _context.WishList.Include(c => c.Course).ThenInclude(course => course.User).Where(c => c.UserId == userId);
        }
        public WishList? GetWishListItem(int userId, int courseId)
        {
            return _context.WishList.FirstOrDefault(c => c.UserId == userId && c.CourseId == courseId);
        }

        public bool WishListITemExists(int userId, int courseId)
        {
            return _context.WishList.Any(c => c.UserId == userId && c.CourseId == courseId);
        }


    }
}
