using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;

namespace E_Learning.DAL.Repositories.SectionRepository
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
