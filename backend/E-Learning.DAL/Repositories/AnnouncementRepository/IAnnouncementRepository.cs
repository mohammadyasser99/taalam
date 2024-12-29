using E_Learning.DAL.Models;
using E_Learning.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories.AnnouncementRepository
{
    public interface IAnnouncementRepository : IGenericRepository<Announcement>
    {
        void deleteannouncement(Announcement announcement);

        Announcement getannouncement(int id);
    }
}
