using Azure.Core;
using E_Learning.BL.DTO.User;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.AspNetCore.Hosting;

namespace E_Learning.BL.Managers.CategoryManager
{
    public class UserManager : IUserManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env; // To get access to the "uploads" folder path
        /*------------------------------------------------------------------------*/
        public UserManager(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public InstructorDTO GetInstructorInfo(int id)
        {
            var userFromDb = _unitOfWork.UserRepository.GetInstructorInfo(id);
            if (userFromDb == null)
                return null;
            var totalCourses = userFromDb.OwnedCourses;
            var totalStudents = 0;
            foreach (var course in totalCourses)
            {
                totalStudents += _unitOfWork.UserRepository.CountEnrollment(course.Id);
            }
            if (!string.IsNullOrEmpty(userFromDb.ProfilePicture))
            {
                if (userFromDb.ProfilePicture.Contains("/uploads/"))
                {
                    var fileName = Path.GetFileName(new Uri(userFromDb.ProfilePicture).LocalPath);
                    var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
                    if (!File.Exists(filePath))
                    {
                        userFromDb.ProfilePicture = null;
                    }
                }
            }

            InstructorDTO InstructorInfo = new InstructorDTO
            {
                FName = userFromDb.FName,
                LName = userFromDb.LName,
                Github = userFromDb.GitHub,
                Facebook = userFromDb.Facebook,
                Linkedin = userFromDb.Linkedin,
                Youtube = userFromDb.Youtube,
                Twitter = userFromDb.Twitter,
                Description = userFromDb.Description,
                ProfilePicture = userFromDb.ProfilePicture,
                TotalStudents = totalStudents,
                OwnedCourses = userFromDb.OwnedCourses.Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    CoverPicture = c.CoverPicture,
                    Description = c.Description,
                    Price = c.Price,
                    Rate = c.Rate,
                    Category=c.Category.Name
                
                }).ToList()
            };
            return InstructorInfo;
        }
        public async Task<bool> EditUserProfile(EditUserProfileDTO editUserProfileDTO, string scheme, string host)
        {
            var userFromDb = _unitOfWork.UserRepository.GetById(editUserProfileDTO.Id);
            if (userFromDb == null)
                return false;
            userFromDb.FName = editUserProfileDTO.FName;
            userFromDb.LName = editUserProfileDTO.LName;
            userFromDb.Description = editUserProfileDTO.Description;
            userFromDb.GitHub = editUserProfileDTO.Github;
            userFromDb.Twitter = editUserProfileDTO.Twitter;
            userFromDb.Facebook = editUserProfileDTO.Facebook;
            userFromDb.Linkedin = editUserProfileDTO.LinkedIn;
            userFromDb.Youtube = editUserProfileDTO.Youtube;

            if (!string.IsNullOrEmpty(userFromDb.ProfilePicture) &&
                userFromDb.ProfilePicture.Contains($"/uploads/"))
            {
                var oldFileName = Path.GetFileName(new Uri(userFromDb.ProfilePicture).LocalPath);
                var oldFilePath = Path.Combine(_env.WebRootPath, "uploads", oldFileName);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }
            if (editUserProfileDTO.ProfilePictureFile != null)
            {
                var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(editUserProfileDTO.ProfilePictureFile.FileName);
                var newFilePath = Path.Combine(_env.WebRootPath, "uploads", newFileName);

                // Save the new file
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await editUserProfileDTO.ProfilePictureFile.CopyToAsync(stream);
                }

                // Update the user's profile picture URL
                userFromDb.ProfilePicture = $"{scheme}://{host}/uploads/{newFileName}";
            }
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
