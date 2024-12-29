using E_Learning.BL.DTO.CourseDTO;
using E_Learning.BL.DTO.CourseDTO.CourseRatingDTO;
using E_Learning.BL.DTO.User;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;

namespace E_Learning.BL.Managers.RatingManager
{
    public class RatingManager: IRatingManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


       public IEnumerable<ReadCourseRatingByUserDTO> GetAllRatingGivenByUser(int userId)
        {
            var ratings = _unitOfWork.RatingRepository.GetAllRatingGivenByUser(userId).Select(rating => new ReadCourseRatingByUserDTO
            {
                Id = rating.Id,
                Description = rating.Description,
                Value = rating.Value,
                Course = rating.Course == null ? null : new ReadCourseInfoForRatingDTO
                {
                    Id = rating.Course.Id,
                    Title = rating.Course.Title,
                    Rate = rating.Course.Rate,

                }
            }).ToList();


            return ratings;
        }


        public IEnumerable<ReadCourseRatingDTO> GetAllRatingsForCourse(int courseId)
        {
            var ratings = _unitOfWork.RatingRepository.GetAllRatingsForCourse(courseId).Select(rating => new ReadCourseRatingDTO
            {
                Id = rating.Id,
                Description = rating.Description,
                Value = rating.Value,

                Student = rating.User==null ? null : new ReadUserInfoForRating()
                {
                    Id= rating.User.Id,
                    ProfilePicture = rating.User.ProfilePicture ?? null,
                    Name = rating.User.FName+" "+rating.User.LName

                }

            }).ToList();


            return ratings;
        }

        public bool CreateRating(CreateRatingByUser ratingDto)
        {


            var existingRating = _unitOfWork.RatingRepository.getOneRatingByUserForCourse(ratingDto.UserId, ratingDto.CourseId);
            if (existingRating != null)
            {
                return false; 
            }

            Rating newRating = new Rating
            {
                UserId = ratingDto.UserId,
                CourseId = ratingDto.CourseId,
                Value = ratingDto.Value,
                Description = ratingDto.Description
            };

             var ratingCreated=  _unitOfWork.RatingRepository.CreateRating(newRating);

            if (ratingCreated)
            {
                // Update course's average rating
                UpdateCourseAverageRating(ratingDto.CourseId);
            }

            return ratingCreated;

        }


        public bool EditRating(CreateRatingByUser ratingDto)
        {
            var existingRating = _unitOfWork.RatingRepository.getOneRatingByUserForCourse(ratingDto.UserId, ratingDto.CourseId);
            if (existingRating == null)
            {
                return false; 
            }

            existingRating.Value = ratingDto.Value;
            existingRating.Description = ratingDto.Description;

            var ratingWasEdited= _unitOfWork.RatingRepository.EditRating(existingRating);
            if (ratingWasEdited)
            {
                UpdateCourseAverageRating(ratingDto.CourseId);
            }
            return ratingWasEdited;
        }

        public ReadCourseRatingDTO? GetOneRatingByUserForCourse(int userId, int courseId)
        {
            var rating = _unitOfWork.RatingRepository.getOneRatingByUserForCourse(userId, courseId);
            if (rating == null)
            {
                return null;
            }
            var resultDto = new ReadCourseRatingDTO
            {
                Id = rating.Id,
                Description = rating.Description,
                Value = rating.Value,


            };

            return resultDto;
        }

        private void UpdateCourseAverageRating(int courseId)
        {
            var course = _unitOfWork.CourseRepository.GetById(courseId);

            if (course != null)
            {
                var ratings = _unitOfWork.RatingRepository.GetAllRatingsForCourse(courseId);
                if (ratings != null && ratings.Any())
                {
                    var averageRating = ratings.Average(r => r.Value);

                    course.Rate = (decimal)averageRating;

                    _unitOfWork.CourseRepository.Update(course);
                    _unitOfWork.SaveChanges();
                }
            }
        }

        
    }
}
