
using E_Learning.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /*------------------------------------------------------------------------*/
        protected readonly AppDbContext _context;
        /*------------------------------------------------------------------------*/
        // Ctor
        public GenericRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        /*------------------------------------------------------------------------*/
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        /*------------------------------------------------------------------------*/
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        /*------------------------------------------------------------------------*/
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        /*------------------------------------------------------------------------*/
        public void Update(T entity)
        {
            //_context.Set<T>().Update(entity);
        }
        /*------------------------------------------------------------------------*/
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        /*------------------------------------------------------------------------*/
    }
}
