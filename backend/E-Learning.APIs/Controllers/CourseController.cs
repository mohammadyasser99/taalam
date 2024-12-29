using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;

using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseLessonDTO;
using E_Learning.BL.DTO.CourseDTO.EnrollmentDTO;

﻿using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.BL.DTO.User;
using E_Learning.BL.Managers.CourseManager;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EllipticCurve;
using E_Learning.DAL.UnitOfWorkDP;
using E_Learning.DAL.Migrations;

namespace E_Learning.APIs.Controllers
{


    public class CourseController : APIBaseController
    {
        private readonly ICourseManager _courseManager;
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(ICourseManager courseManager, IUnitOfWork unitOfWork)
        {
            this._courseManager = courseManager;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult getCourseDetailsById(int id)
        {
            var course = _courseManager.GetCourseDetailsById(id);
            if (course == null) {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet("content/{courseId}")]
        public IActionResult getCourseContentForUser(int courseId)

        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(); // Return 401 Unauthorized if the user is not logged in
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            if (_courseManager.IsStudentEnrolled(userId, courseId) == false) {
                return BadRequest("user is not enrolled in this course");
            }


            var course = _courseManager.GetCourseContentForUser(userId, courseId);
            if (course == null)
            {
                return NoContent();
            }
            return Ok(course);
        }

        [HttpPost("enroll")]
        public IActionResult EnrollInCourse([FromBody] EnrollPostRequestDTO enrollRequest)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(); // Return 401 Unauthorized if the user is not logged in
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }
            if (_courseManager.IsStudentEnrolled(userId, enrollRequest.CourseId))
            {
                return BadRequest("User is already enrolled in this course.");
            }

            var enrollmentResult = _courseManager.EnrollUserInCourse(userId, enrollRequest.CourseId);

            if (enrollmentResult)
            {
                return Ok(new { message = "User enrolled successfully!" });
            }

            return StatusCode(500, "There was an error enrolling the user.");
        }


        [HttpPost("complete-lesson")]
        public IActionResult CompleteLesson([FromBody] CompleteLessonRequestDTO request)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }


            if (_courseManager.IsStudentEnrolled(userId, request.CourseId) == false)
            {
                return BadRequest("User is not enrolled in course.");
            }

            var result = _courseManager.CompleteLesson(userId, request.CourseId, request.LessonId);
            if (!result)
            {
                return BadRequest("Failed to mark lesson as completed.");
            }

            return Ok(new { message = "Lesson marked as completed" });
        }


        [HttpGet("debuguser")]
        public IActionResult debugUser()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }

        [Authorize]
        [HttpPost("createCert/{courseId}")]
        public IActionResult CreateAPI(int courseId )
        {
            try
            {

                if (User.Identity==null ||!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }
                var isCertCreated = _courseManager.CreateCertificate(userId, courseId);
                if (isCertCreated == false)
                {
                    return BadRequest();
                }
                return Ok(new { message = "cert created" });


            }
            catch (Exception e)
            {
                return BadRequest(new {message= e.Message});
            }
        }
        [HttpGet("generate-cert-pdf/{courseId}")]
        public IActionResult GenerateCertificatePdf(int courseId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            var certificateDto = _courseManager.GetCertificateDetails(userId, courseId);

            if (certificateDto == null)
            {
                return NotFound();
            }

            var pdfBytes = _courseManager.GenerateCertificatePdf(certificateDto);

            return File(pdfBytes, "application/pdf", $"Certificate_{userId}_{courseId}.pdf");
        }

        [Authorize]
        [HttpGet("getOrCreateCert/{courseId}")]
        public IActionResult GetOrCreateCertificate(int courseId)
        {
            try
            {
                // Ensure user is authenticated
                if (!User.Identity.IsAuthenticated)
                {
                    return Unauthorized();
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                {
                    return Unauthorized();
                }

                // Check if the user is enrolled in the course
                if (!_courseManager.IsStudentEnrolled(userId, courseId))
                {
                    return BadRequest(new { message = "User is not enrolled in this course." });
                }

                // Try to get the certificate details
                var certificateDto = _courseManager.GetCertificateDetails(userId, courseId);

                // If the certificate doesn't exist, create it
                if (certificateDto == null)
                {
                    // Ensure the course is completed before creating a certificate
                    if (!_courseManager.IsEnrollmentComplete(userId, courseId))
                    {
                        return BadRequest(new { message = "Course is not yet completed." });
                    }

                    // Create the certificate
                    if (!_courseManager.CreateCertificate(userId, courseId))
                    {
                        return BadRequest(new { message = "Certificate could not be created." });
                    }

                    // Get the newly created certificate details
                    certificateDto = _courseManager.GetCertificateDetails(userId, courseId);

                    if (certificateDto == null)
                    {
                        return BadRequest(new { message = "Error retrieving newly created certificate." });
                    }
                }

                // Generate the certificate PDF
                var pdfBytes = _courseManager.GenerateCertificatePdf(certificateDto);

                // Return the generated PDF as a file response
                return File(pdfBytes, "application/pdf", $"Certificate_{userId}_{courseId}.pdf");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("admin/GetPaginatedCourses")]
        public IActionResult GetPaginatedCourses(
         [FromQuery] string? searchTerm = null,
         [FromQuery] int page = 1,
         [FromQuery] int pageSize = 10,
         [FromQuery] string sortBy = "title",
         [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var paginatedCourses = _courseManager.GetPaginatedCourses(searchTerm, page, pageSize, sortBy, sortOrder);
                if (paginatedCourses == null)
                {
                    return NotFound();
                }
                return Ok(paginatedCourses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpDelete("admin/DeleteCourse/{courseId}")]
        [AllowAnonymous]

        public IActionResult DeleteCourse(int courseId)
        {
            try
            {
                _courseManager.DeleteCourse(courseId);
                return Ok(new { message = "Course deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }





        /////////////////////////////////////////////////////////////////////////////
        [AllowAnonymous]

        [HttpGet("GetAllCourses")]
        public ActionResult<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = _courseManager.GetAllCourses();
            return Ok(courses);
        }

        [AllowAnonymous]

        [HttpGet("SearchCourses")]
        public ActionResult<IEnumerable<CourseDTO>> SearchCourses(string searchTerm)
        {
            var courses = _courseManager.SearchCourses(searchTerm);
            return Ok(courses);
        }

        [HttpPost("uploadCourse")]
        
        public ActionResult UploadCourse(UploadCourseDTO courseDto)
        {
            (var success, var message) = _courseManager.UploadCourse(courseDto);
            if (success == true)
            {
                return Ok(new { message = message });
            }
            else
            {
                return BadRequest(new { message = message });
            }
        }

        [HttpGet("GetAllUserCourses/{userId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<EnrolledCourse>> GetAllUserCourses(int userId)
        {
            var courses = _courseManager.GetCoursesByUserId(userId);
            if (courses.Any())
            {
                return Ok(courses);
            }
            return NotFound("No courses found for this user.");
        }


        [HttpGet("GetCourseById/{courseId}")]
        [AllowAnonymous]
        public ActionResult<UploadCourseDTO> GetCourseById(int courseId)
        {
            UploadCourseDTO course = _courseManager.GetCourseById(courseId);
            return Ok(course);
        }

        [HttpPut("editCourse")]
        [AllowAnonymous]
        public ActionResult editCourse(UploadCourseDTO courseDto)
        {
            (var success, var message) = _courseManager.EditCourse(courseDto);
            if (success == true)
            {
                return Ok(new { message = message });
            }
            else
            {
                return BadRequest(new { message = message });
            }
        }


        [HttpGet("enrollFree")]
        public IActionResult EnrollFreeCourses()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(); // Return 401 Unauthorized if the user is not logged in
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized();
            }
            using (var unitOfWork = _unitOfWork)
            {
                var carts = unitOfWork.CartRepository.GetCartItemsByUserId(userId);
                foreach (var cart in carts)
                {
                    var enrollment = new Enrollment
                    {
                        UserId = userId,
                        CourseId = cart.CourseId,
                        EnrollmentDate = DateTime.UtcNow,
                        ProgressPercentage = 0,
                        CompletedLessons = 0
                    };

                    unitOfWork.EnrollmentRepository.AddEnrollment(enrollment);
                    unitOfWork.CartRepository.Delete(cart);
                }

                unitOfWork.SaveChanges();
            }
            return Ok(new { url = "http://localhost:4200/paymentapprove?success=true" });

        }

        [AllowAnonymous]
        [HttpGet("IsEnrolled/{courseId}")]
        public IActionResult CheckIsEnrolled(int courseId)
        {
            try
            {
                // Ensure user is authenticated
                if (!User.Identity.IsAuthenticated)
                {
                    return Ok(new { isEnrolled = false });
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                {
                    return Ok(new { isEnrolled = false });
                }


                return Ok(new {isEnrolled= _courseManager.IsStudentEnrolled(userId, courseId)});
                
               
                
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}
