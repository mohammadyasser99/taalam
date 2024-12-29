using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning.DAL.Data.Context;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using E_Learning.DAL.UnitOfWorkDP;
using E_Learning.BL.Managers.CourseManager;
using E_Learning.BL.Managers.AnnouncementManager;

namespace E_Learning.APIs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : APIBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        private readonly ICourseManager _courseManager;
        private readonly IAnnouncementManager _announcementManager;

        public AnnouncementController(AppDbContext context , IUnitOfWork unitOfWork,ICourseManager courseManager 
            , IAnnouncementManager announcementManager )
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _courseManager = courseManager;
            _announcementManager = announcementManager;
        }

        // GET: api/Announcement
        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IEnumerable<Announcement>> GetAnnouncements()
        {
          //  return await _context.Announcements.ToListAsync();
            return  _unitOfWork.AnnouncementRepository.GetAll().ToList();
        }

        // GET: api/Announcement/5
        [HttpGet("{id}")]
        public  ActionResult<Announcement> GetAnnouncement(int id)
        {
        //    var announcement =  _context.Announcements.FindAsync(id);
            var announcement = _unitOfWork.AnnouncementRepository.GetById(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return announcement;
        }

        // PUT: api/Announcement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnouncement(int id, Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return BadRequest();
            }

            _context.Entry(announcement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Announcement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<Announcement> PostAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors to the client
            }

            var allAnnouncements = _unitOfWork.AnnouncementRepository.GetAll();
            foreach (var existingAnnouncement in allAnnouncements)
            {
                // Step 2: Delete each existing announcement
                _unitOfWork.AnnouncementRepository.deleteannouncement(existingAnnouncement); // Pass the existingAnnouncement here
            }

            _unitOfWork.AnnouncementRepository.Create(announcement);

            var courses = _unitOfWork.CourseRepository.GetAll();
            foreach (var course in courses)
            {
                course.Price -= course.Price * announcement.Discount / 100;
                // Ensure the modified course is tracked
                _unitOfWork.CourseRepository.updateCourse(course);
            }

            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetAnnouncement", new { id = announcement.Id }, announcement);
        }

        // DELETE: api/Announcement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            //var announcement = await _context.Announcements.FindAsync(id);
            var announcement =  _unitOfWork.AnnouncementRepository.getannouncement(id);
            if (announcement == null)
            {
                return NotFound();
            }
            var courses = _unitOfWork.CourseRepository.GetAll();
            foreach (var course in courses)
            {
                course.Price /= ((100 - announcement.Discount)/100);
                // Ensure the modified course is tracked
                _unitOfWork.CourseRepository.updateCourse(course);
            }

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
