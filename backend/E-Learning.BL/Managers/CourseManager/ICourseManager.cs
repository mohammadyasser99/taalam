using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseAdminDTO;
using E_Learning.BL.DTO.CourseDTO.CertDTO;
using E_Learning.BL.DTO.CourseDTO.CourseContentDTO;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.CourseManager
{
    public interface ICourseManager
    {
        ReadOneCourseDetailsDto GetCourseDetailsById(int id);
        ReadCourseContentDTO GetCourseContentForUser(int userId, int courseId);

        bool EnrollUserInCourse(int userId, int courseId);
        bool CompleteLesson(int userId, int courseId, int lessonId);
        IEnumerable<ReadCourseDTO> GetAllCourses();
        IEnumerable<ReadCourseDTO> SearchCourses(string searchTerm);
        IEnumerable<ReadCourseDTO> GetCoursesByCategoty(int id);
        bool IsStudentEnrolled(int userId, int courseId);

        (bool success, string message) UploadCourse(UploadCourseDTO uploadCourse);
        IEnumerable<EnrolledCourse> GetCoursesByUserId(int id);

        UploadCourseDTO GetCourseById(int id);

        (bool success, string message) EditCourse(UploadCourseDTO uploadCourse);

        bool CreateCertificate(int userId, int courseId);
        byte[] GenerateCertificatePdf(CertificateOfCompletionDto certificateDto);
        CertificateOfCompletionDto? GetCertificateDetails(int userId, int courseId);

        bool IsEnrollmentComplete(int userId, int courseId);


        PaginatedCourseResponseDTO GetPaginatedCourses(string searchTerm, int page, int pageSize, string sortBy, string sortOrder);
        public void DeleteCourse(int courseId);





    }

}