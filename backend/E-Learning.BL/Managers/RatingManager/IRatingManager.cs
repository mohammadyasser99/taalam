using E_Learning.BL.DTO.CourseDTO.CourseRatingDTO;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.RatingManager
{
    public interface IRatingManager
    {
        IEnumerable<ReadCourseRatingDTO> GetAllRatingsForCourse(int courseId);
        IEnumerable<ReadCourseRatingByUserDTO> GetAllRatingGivenByUser(int userId);
        public bool CreateRating(CreateRatingByUser ratingDto);


        public ReadCourseRatingDTO? GetOneRatingByUserForCourse(int userId, int courseId);
        public bool EditRating(CreateRatingByUser ratingDto);



    }
}
