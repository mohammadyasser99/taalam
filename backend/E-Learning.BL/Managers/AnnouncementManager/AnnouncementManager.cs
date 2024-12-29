using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.AnnouncementManager
{
    public class AnnouncementManager : IAnnouncementManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool createannouncement(Announcement announcement)
        {
            using (var unitOfWork = _unitOfWork) // Or inject the UnitOfWork if using dependency injection
            {
                unitOfWork.AnnouncementRepository.Create(announcement);

                var courses = unitOfWork.CourseRepository.GetAll();
                foreach (var course in courses)
                {
                    course.Price -= course.Price * announcement.Discount / 100;
                    // Ensure the modified course is tracked
                    unitOfWork.CourseRepository.Update(course);
                }

                unitOfWork.SaveChanges(); // Save the changes after updating courses
                return true;
            }
        }


    }
}
