using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.AnnouncementManager
{
    public interface IAnnouncementManager
    {
        bool createannouncement(Announcement announcement);
    }
}
