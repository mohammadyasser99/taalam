using E_Learning.BL.DTO.CourseDTO.CourseRatingDTO;
using E_Learning.BL.Managers.CourseManager;
using E_Learning.BL.Managers.RatingManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.APIs.Controllers
{
    public class RatingController : APIBaseController
    {
        private readonly IRatingManager _ratingManager;
        private readonly ICourseManager _courseManager;

        public RatingController(IRatingManager ratingManager, ICourseManager courseManager)
        {
            this._ratingManager = ratingManager;
            this._courseManager = courseManager;
        }

        [HttpGet("courses/{id}")]
        [AllowAnonymous]
        public IActionResult GetAllRatingsForCourse(int id)
        {
            var ratings = _ratingManager.GetAllRatingsForCourse(id);
            if (ratings == null)
            {
                return NotFound();
            }
            return Ok(ratings);
        }

        [HttpGet("student/{id}")]
        [AllowAnonymous]
        public IActionResult GetAllRatingsGivenByUser(int id)
        {
            var ratings = _ratingManager.GetAllRatingGivenByUser(id);
            if (ratings == null)
            {
                return NotFound();
            }
            return Ok(ratings);
        }

        [HttpPost]
        public IActionResult CreateRating([FromBody] CreateRatingByUser ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            ratingDto.UserId = userId;
            if (_courseManager.IsStudentEnrolled(userId,ratingDto.CourseId)==false)
            {
                return Unauthorized("user not enrolled in course");

            }

            var result = _ratingManager.CreateRating(ratingDto);
            if (result)
            {
                return Ok(new{message= "Rating successfully created."});
            }

            return StatusCode(500, "An error occurred while creating the rating.");
        }

        [HttpPut("edit")]
        public IActionResult EditRating([FromBody] CreateRatingByUser ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            if (_courseManager.IsStudentEnrolled(userId, ratingDto.CourseId)==false)
            {
                return Unauthorized("user not enrolled in course");

            }


            var existingRating = _ratingManager.GetOneRatingByUserForCourse(userId, ratingDto.CourseId);
            if (existingRating == null)
            {
                return NotFound("Rating does not exist.");
            }


            ratingDto.UserId = userId; 

            var result = _ratingManager.EditRating(ratingDto);
            if (result)
            {
                return Ok(new { message = "Rating successfully edited." });
            }

            return StatusCode(500, "An error occurred while editing the rating.");
        }

        [HttpGet("course/{courseId}")]
        public IActionResult GetOneRatingByUserForCourse(int courseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            var rating = _ratingManager.GetOneRatingByUserForCourse(userId, courseId);
            if (rating == null)
            {
                return NotFound("Rating not found.");
            }
            return Ok(rating);
        }
    }
}
