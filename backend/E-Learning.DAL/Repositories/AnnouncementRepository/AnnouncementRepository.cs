using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.AnswerRepository;
using E_Learning.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories.AnnouncementRepository
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext _context) : base(_context)
        {
        }

        public void deleteannouncement(Announcement announcement)
        {
            _context.Announcements.Remove(announcement);
        }

        public Announcement getannouncement(int id)
        {
            return _context.Announcements.FirstOrDefault(x => x.Id == id);
        }
    }
}
