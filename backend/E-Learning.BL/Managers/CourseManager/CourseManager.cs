using E_Learning.BL.DTO.Course;
using E_Learning.BL.DTO.CourseDTO.CertDTO;
using E_Learning.BL.DTO.CourseDTO.CourseContentDTO;
using E_Learning.BL.DTO.CourseDTO.CourseSectionDTO;
using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseLessonDTO;
using E_Learning.BL.DTO.CourseDTO.CourseSectionInfoDTO.CourseQuizInfoDTO;
using E_Learning.BL.DTO.CourseDTO.CourseUploadDTO;
using E_Learning.BL.DTO.CourseDTO.InstructorInfoDTO;
using E_Learning.BL.DTO.User;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using System.Reflection.Metadata;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Drawing;
using Document = QuestPDF.Fluent.Document;
using E_Learning.BL.DTO.CourseAdminDTO;
using System;


namespace E_Learning.BL.Managers.CourseManager
{
    public class CourseManager : ICourseManager
    {
            
        private readonly IUnitOfWork _unitOfWork;

        public CourseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ReadOneCourseDetailsDto GetCourseDetailsById(int id)
        {
            var course = _unitOfWork.CourseRepository.getCourseDetailsById(id);
            if (course == null)
            {
                return null;
            }


            ReadOneCourseDetailsDto courseDetails = new ReadOneCourseDetailsDto
            {
                Id = course.Id,
                Instructor = new ReadCourseInstructorInfoDTO
                {
                    Id = course.User.Id,
                    FName = course.User.FName,
                    LName = course.User.LName,
                    Description = course.User.Description,
                    ProfilePicture = course.User.ProfilePicture != null ? course.User.ProfilePicture : null

                },

                CourseCategory = course.Category == null ? null : new Dtos.Category.ReadCategoryDto
                {
                    Id = course.Category.Id,
                    Name = course.Category.Name,
                },

                Title = course.Title,
                Description = course.Description,
                CoverPicture = course.CoverPicture,
                Price = course.Price,
                Rate = course.Rate,
                CreationDate = course.CreationDate,
                UpdatedDate = course.UpdatedDate,
                SectionsNo = course.Sections != null ? course.Sections.Count() : 0,

                Sections = course.Sections == null ? null : course.Sections.Select(section => new ReadCourseSectionInfoDTO
                {
                    Id = section.Id,
                    SectionNumber = section.SectionNumber,
                    Title = section.Title,
                    LessonsNo = section.Lessons != null ? section.Lessons.Count() : 0,

                    Lessons = section.Lessons == null ? null : section.Lessons.Select(lesson => new ReadCourseLessonDTO

                    {
                        Id = lesson.Id,
                        Title = lesson.Title,
                        Duration = lesson.Duration,

                    }).ToList(),
                    Quizes = section.Quizes == null ? null : section.Quizes.Select(quiz => new ReadCourseQuizInfoDTO
                    {
                        Id = quiz.Id,
                        Title = quiz.Title,


                    }).ToList(),
                }).ToList()
            };
            return courseDetails;
        }

        public ReadCourseContentDTO GetCourseContentForUser(int userId, int courseId)
        {

            (var course, var ennrollment) = _unitOfWork.CourseRepository.GetCourseContentForUser(userId, courseId);

            var completedLessonIds = _unitOfWork.CourseRepository.GetCompletedLessonIdsForUserAndCourse(userId, courseId);
            int totalLessons = course.Sections?.Sum(section => section.Lessons.Count) ?? 0;
            int completedLessonsCount = completedLessonIds.Count;

            ReadCourseContentDTO couresResult = new ReadCourseContentDTO
            {
                Id = course.Id,
                TeacherId = course.UserId,
                Duration = course.Duration,
                Title = course.Title,

                Sections = course.Sections?.Select(section => new ReadCourseSectionInfoDTO
                {
                    Id = section.Id,
                    SectionNumber = section.SectionNumber,
                    Title = section.Title,
                    LessonsNo = section.Lessons != null ? section.Lessons.Count() : 0,

                    Lessons = section.Lessons == null ? null : section.Lessons.Select(lesson => new ReadCourseLessonDTO
                    {
                        Id = lesson.Id,
                        Title = lesson.Title,
                        Duration = lesson.Duration,
                        Content = lesson.Content,
                        IsCompleted = completedLessonIds.Contains(lesson.Id)

                    }).ToList(),
                    Quizes = section.Quizes == null ? null : section.Quizes.Select(quiz => new ReadCourseQuizInfoDTO
                    {
                        Id = quiz.Id,
                        Title = quiz.Title,

                    }).ToList()
                }).ToList(),

                StudentEnrollment = new CourseEnrollmentInfoDTO
                {
                    ProgressPercentage = ennrollment.ProgressPercentage,
                    CompletedLessons = completedLessonsCount,
                    EnrollmentDate = ennrollment.EnrollmentDate,
                }
            };

            return couresResult;
        }

        public bool IsStudentEnrolled(int userId, int courseId)

        {
            return _unitOfWork.EnrollmentRepository.IsStudentEnrolled(userId, courseId);
        }






        public PaginatedCourseResponseDTO GetPaginatedCourses(string searchTerm, int page, int pageSize, string sortBy, string sortOrder)
            {
                
                int totalCourses;
            searchTerm = string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm;
            var courses = _unitOfWork.CourseRepository.GetPaginatedCourses(searchTerm, page, pageSize, sortBy, sortOrder, out totalCourses);

                if (courses == null || !courses.Any())
                {
                return null;
                }

                // Map courses to DTO manually
                var courseDtos = courses.Select(course => new CourseAdminDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    CategoryName = course.Category?.Name,
                    InstructorName = course.User.FName + (course.User.LName != null ? " " + course.User.LName : " "),

                    EnrollmentCount = course.Enrollments.Count, // Number of enrollments
                    CreationDate = course.CreationDate
                }).ToList();

                // Prepare paginated response
                return new PaginatedCourseResponseDTO
                {
                    Courses = courseDtos,
                    TotalCourses = totalCourses,
                    Page = page,
                    PageSize = pageSize
                };
            }


        public void DeleteCourse(int courseId)
        {
            _unitOfWork.CourseRepository.DeleteCourse(courseId);
                
        }



        ////////////////////////////////////////////////////////////////////////////////
        public IEnumerable<ReadCourseDTO> GetAllCourses()
        {

            return _unitOfWork.CourseRepository.GetAllCourses()
                .Select(c => new ReadCourseDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    InstructorName = c.User.FName + " " + c.User.LName,
                    Description = c.Description,
                    Price = c.Price,
                    Rate = c.Rate,
                    CoverPicture = c.CoverPicture,
                    CategoryName = c.Category?.Name,
                    Duration = c.Duration,
                });
        }

        public bool EnrollUserInCourse(int userId, int courseId)
        {
            //var existingEnrollment = _unitOfWork.EnrollmentRepository.IsStudentEnrolled(userId,courseId);

            //if (existingEnrollment)
            //{
            //    return false; 
            //}

            var enrollment = new Enrollment
            {
                UserId = userId,
                CourseId = courseId,
                EnrollmentDate = DateTime.UtcNow,
                ProgressPercentage = 0,
                CompletedLessons = 0
            };

            _unitOfWork.EnrollmentRepository.AddEnrollment(enrollment);
            _unitOfWork.SaveChanges();
            return true;
        }



        public bool CompleteLesson(int userId, int courseId, int lessonId)
        {

            var enrollment = _unitOfWork.EnrollmentRepository.GetEnrollment(userId, courseId);
            if (enrollment == null) return false;

            var completedLesson = new CompletedLesson
            {
                UserId = userId,
                LessonId = lessonId,
                CourseId = courseId,
                CompletedDate = DateTime.Now
            };

            _unitOfWork.LessonRepository.MarkLessonAsComplete(userId, lessonId, courseId);
            var completedLessonIds = _unitOfWork.CourseRepository.GetCompletedLessonIdsForUserAndCourse(userId, courseId);
            var totalLessons = _unitOfWork.LessonRepository.GetTotalLessonsForCourse(courseId);
            int completedLessonsCount = completedLessonIds.Count;

            decimal progressPercentage = totalLessons > 0 ? (decimal)completedLessonsCount / totalLessons * 100 : 0;

            enrollment.ProgressPercentage = progressPercentage;
            _unitOfWork.EnrollmentRepository.Update(enrollment);


            _unitOfWork.SaveChanges();
            return true;

        }

        public bool CreateCertificate(int userId, int courseId)
        {
            if (_unitOfWork.EnrollmentRepository.IsStudentEnrolled(userId, courseId) == false)
            {
                return false;
            }
            if (_unitOfWork.EnrollmentRepository.IsEnrollmentComplete(userId, courseId) == false)
            {
                return false;
            }

            if (_unitOfWork.CourseRepository.CertAlreadyExists(userId, courseId))
            {
                return false;
            }

            _unitOfWork.CourseRepository.CreateCertificate(userId, courseId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool IsEnrollmentComplete(int userId, int courseId)
        {
            return _unitOfWork.EnrollmentRepository.IsEnrollmentComplete(userId, courseId);

        }



        public IEnumerable<ReadCourseDTO> SearchCourses(string searchTerm)
        {
            return _unitOfWork.CourseRepository.SearchCourses(searchTerm)
                .Select(c => new ReadCourseDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    InstructorName = c.User?.FName + " " + c.User?.LName,
                    Description = c.Description,
                    Price = c.Price,
                    Rate = c.Rate,
                    CoverPicture = c.CoverPicture,
                    CategoryName = c.Category?.Name,
                    Duration = c.Duration,

                });
        }

        public CertificateOfCompletionDto? GetCertificateDetails(int userId, int courseId)
        {
            var certificate = _unitOfWork.CourseRepository.GetCertOfComp(userId, courseId);

            if (certificate == null)
            {
                return null;
            }

            return new CertificateOfCompletionDto
            {
                Id = certificate.Id,
                IssuedAy = certificate.IssuedAy,
                User = new ReadCourseInstructorInfoDTO
                {
                    Id = certificate.User.Id,
                    FName = certificate.User.FName,
                    LName = certificate.User.LName
                },
                Course = new ReadOneCourseDetailsDto
                {
                    Id = certificate.Course.Id,
                    Title = certificate.Course.Title
                }
            };
        }





        public byte[] GenerateCertificatePdf(CertificateOfCompletionDto certificateDto)
        {
            // Define the PDF document using QuestPDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(50);
                    page.Background(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    // Header with certificate title
                    page.Header()
                        .AlignCenter()
                        .Text("Certificate of Completion")
                        .FontSize(42)
                        .SemiBold()
                        .FontColor(Colors.Blue.Medium)
                        .Underline();

                    page.Content().PaddingVertical(40).Column(column =>
                    {
                        column.Spacing(20);

                        column.Item().AlignCenter().Text("Taalam Academy")
                            .FontSize(28)
                            .Bold()
                            .FontColor(Colors.Blue.Darken3); // Mocked logo text

                        var fullName = $"{certificateDto.User.FName} {certificateDto.User.LName}";
                        column.Item().AlignCenter().Text($"This certifies that {fullName}")
                            .FontSize(28)
                            .Bold()
                            .FontColor(Colors.Black);

                        column.Item().AlignCenter().Text($"has successfully completed the course:")
                            .FontSize(22)
                            .FontColor(Colors.Black);

                        column.Item().AlignCenter().Text($"{certificateDto.Course.Title}")
                            .FontSize(32)
                            .Bold()
                            .FontColor(Colors.Green.Medium);



                        column.Item().AlignCenter().Text($"Date of Issuance: {certificateDto.IssuedAy.ToString("MMMM dd, yyyy")}")
                            .FontSize(20)
                            .FontColor(Colors.Black);



                        //var verificationUrl = $"http://localhost:4000/cert/ver/{certificateDto.Id}";
                        //column.Item().AlignCenter().Text($"Verify this certificate: {verificationUrl}")
                        //    .FontSize(16)
                        //    .FontColor(Colors.Blue.Darken2)
                        //    .Underline();
                    });

                    // Footer with academy name and certificate ID
                    page.Footer()
                        .AlignCenter()
                        .Text(txt =>
                        {
                            txt.Span("Taalam Academy")
                                .FontSize(12)
                                .SemiBold();
                            txt.Line($" | Certificate ID: {certificateDto.Id}")
                                .FontSize(12)
                                .FontColor(Colors.Grey.Medium);
                        });
                });
            });

            // Generate the PDF and return it as a byte array
            using (var memoryStream = new MemoryStream())
            {
                document.GeneratePdf(memoryStream);
                return memoryStream.ToArray();
            }
        }



        public IEnumerable<ReadCourseDTO> GetCoursesByCategoty(int id)
        {
            return _unitOfWork.CourseRepository.GetAllCourses().Where(c => c.CategoryId == id)
                .Select(c => new ReadCourseDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    InstructorName = c.User.FName + " " + c.User.LName,
                    Description = c.Description,
                    Price = c.Price,
                    Rate = c.Rate,
                    CoverPicture = c.CoverPicture,
                    CategoryName = c.Category.Name,
                    Duration = c.Duration,

                });
        }

        public (bool success, string message) UploadCourse(UploadCourseDTO uploadCourse)
        {
            #region trying
            try
            {
                Course uploadedCourse = new Course
                {
                    UserId = uploadCourse.UserId,
                    Title = uploadCourse.Title,
                    Description = uploadCourse.Description,
                    Duration = uploadCourse.Duration,
                    CategoryId = _unitOfWork.CategoryRepository.GetCategoryIdByName(uploadCourse.CourseCategory),
                    CoverPicture = uploadCourse.CoverPicture,
                    Price = uploadCourse.Price,
                    Rate = 0,
                    CreationDate = DateTime.Now,
                    SectionsNo = uploadCourse.SectionsNo,
                    Sections = uploadCourse == null ? null : uploadCourse.Sections.Select(section => new Section
                    {
                        Title = section.SectionTitle,
                        LessonsNo = section.NumberOfLessons,
                        Lessons = section.Lessons == null ? null : section.Lessons.Select(lesson => new Lesson
                        {
                            Title = lesson.LessonTitle,
                            Content = lesson.LessonUrl
                        }).ToList()
                    }).ToList()
                };
                _unitOfWork.CourseRepository.Create(uploadedCourse);
                _unitOfWork.SaveChanges();
                return (true, "Course Uploaded Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            #endregion
        }

        public IEnumerable<EnrolledCourse> GetCoursesByUserId(int userId)
        {
            if (_unitOfWork.EnrollmentRepository.IsStudentEnrolled(userId))
            {
                return _unitOfWork.CourseRepository.GetAllCoursesByUserId(userId)
                    .Select(c => new EnrolledCourse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        InstructorName = (c.User != null)? $"{c.User.FName} {(string.IsNullOrEmpty(c.User.LName) ? "" : c.User.LName)}": "null",
                        InstructorInfo = c.User.Description,
                        Description = c.Description,
                        Price = c.Price,
                        Rate = c.Rate,
                        Progress=c.Enrollments.FirstOrDefault(e => e.UserId == userId).ProgressPercentage,
                        CoverPicture = c.CoverPicture,
                        CategoryName = (c.Category != null) ? c.Category.Name : "null",
                        Duration = c.Duration,
                    });
            }
            return Enumerable.Empty<EnrolledCourse>();
        }

        public UploadCourseDTO GetCourseById(int id)
        {
            Course courseFromDb = _unitOfWork.CourseRepository.GetCourseById(id);
            UploadCourseDTO courseDTO = new UploadCourseDTO()
            {
                UserId = courseFromDb.UserId,
                Title = courseFromDb.Title,
                Description = courseFromDb.Description,
                Duration = courseFromDb.Duration,
                CourseCategory = courseFromDb.Category?.Name,
                CoverPicture = courseFromDb.CoverPicture,
                Price = (int)courseFromDb.Price,
                SectionsNo = courseFromDb.SectionsNo,
                Sections = courseFromDb.Sections?.Select(s => new UploadSectionDto()
                {



                    SectionId = s.Id,

                    SectionTitle = s.Title,
                    NumberOfLessons = s.LessonsNo,
                    Lessons = s.Lessons?.Select(l => new UploadLessonDto()
                    {
                        LessonId = l.Id,
                        LessonTitle = l.Title,
                        LessonUrl = l.Content
                    }).ToList(),
                }).ToList()
            };
            return courseDTO;
        }

        public (bool success, string message) EditCourse(UploadCourseDTO editCourse)
        {
            Course courseFromDb = _unitOfWork.CourseRepository.GetCourseById((int)editCourse.CourseId);
            courseFromDb.Title = editCourse.Title;
            courseFromDb.Description = editCourse.Description;
            courseFromDb.Duration = editCourse.Duration;
            courseFromDb.CategoryId = _unitOfWork.CategoryRepository.GetCategoryIdByName(editCourse.CourseCategory);
            courseFromDb.CoverPicture = editCourse.CoverPicture;
            courseFromDb.Price = editCourse.Price;
            courseFromDb.UpdatedDate = DateTime.Now;
            //foreach (var sectionDto in editCourse.Sections)
            //{
            //    var existingSection = courseFromDb.Sections
            //        .FirstOrDefault(s => s.Id == sectionDto.SectionId);

            //    if (existingSection != null)
            //    {
            //        // Update the existing section
            //        existingSection.Title = sectionDto.SectionTitle;
            //        existingSection.LessonsNo = sectionDto.NumberOfLessons;

            //        // Update or add lessons within the section
            //        foreach (var lessonDto in sectionDto.Lessons)
            //        {
            //            var existingLesson = existingSection.Lessons
            //                .FirstOrDefault(l => l.Id == lessonDto.LessonId);

            //            if (existingLesson != null)
            //            {
            //                // Update the existing lesson
            //                existingLesson.Title = lessonDto.LessonTitle;
            //                existingLesson.Content = lessonDto.LessonUrl; // Assuming LessonUrl is stored as Content
            //            }
            //            else
            //            {
            //                // Add a new lesson
            //                var newLesson = new Lesson
            //                {
            //                    Title = lessonDto.LessonTitle,
            //                    Content = lessonDto.LessonUrl,
            //                    SectionId = existingSection.Id
            //                };
            //                existingSection.Lessons.Add(newLesson);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // Add a new section
            //        var newSection = new Section
            //        {
            //            Title = sectionDto.SectionTitle,
            //            LessonsNo = sectionDto.NumberOfLessons,
            //            CourseId = courseFromDb.Id,
            //            //SectionNumber = courseFromDb.Sections.Count + 1, // Assuming auto increment for new sections
            //            Lessons = sectionDto.Lessons.Select(l => new Lesson
            //            {
            //                Title = l.LessonTitle,
            //                Content = l.LessonUrl
            //            }).ToList()
            //        };
            //        courseFromDb.Sections.Add(newSection);
            //    }
            //}

            // Get the list of section IDs coming from the request
            var sectionIdsFromRequest = editCourse.Sections.Select(s => s.SectionId).ToList();

            // Remove sections that are in the database but not in the request
            var sectionsToRemove = courseFromDb.Sections
                .Where(s => !sectionIdsFromRequest.Contains(s.Id))
                .ToList();

            foreach (var sectionToRemove in sectionsToRemove)
            {
                courseFromDb.Sections.Remove(sectionToRemove);
            }

            // Update existing sections and lessons, or add new ones
            foreach (var sectionDto in editCourse.Sections)
            {
                var existingSection = courseFromDb.Sections
                    .FirstOrDefault(s => s.Id == sectionDto.SectionId);

                if (existingSection != null)
                {
                    // Update the existing section
                    existingSection.Title = sectionDto.SectionTitle;
                    existingSection.LessonsNo = sectionDto.NumberOfLessons;

                    // Get the list of lesson IDs from the request for this section
                    var lessonIdsFromRequest = sectionDto.Lessons.Select(l => l.LessonId).ToList();

                    // Remove lessons that are in the database but not in the request
                    var lessonsToRemove = existingSection.Lessons
                        .Where(l => !lessonIdsFromRequest.Contains(l.Id))
                        .ToList();

                    foreach (var lessonToRemove in lessonsToRemove)
                    {
                        existingSection.Lessons.Remove(lessonToRemove);
                    }

                    // Update or add lessons
                    foreach (var lessonDto in sectionDto.Lessons)
                    {
                        var existingLesson = existingSection.Lessons
                            .FirstOrDefault(l => l.Id == lessonDto.LessonId);

                        if (existingLesson != null)
                        {
                            // Update the existing lesson
                            existingLesson.Title = lessonDto.LessonTitle;
                            existingLesson.Content = lessonDto.LessonUrl; // Assuming LessonUrl is stored as Content
                        }
                        else
                        {
                            // Add a new lesson
                            var newLesson = new Lesson
                            {
                                Title = lessonDto.LessonTitle,
                                Content = lessonDto.LessonUrl,
                                SectionId = existingSection.Id
                            };
                            existingSection.Lessons.Add(newLesson);
                        }
                    }
                }
                else
                {
                    // Add a new section
                    var newSection = new Section
                    {
                        Title = sectionDto.SectionTitle,
                        LessonsNo = sectionDto.NumberOfLessons,
                        CourseId = courseFromDb.Id,
                        Lessons = sectionDto.Lessons.Select(l => new Lesson
                        {
                            Title = l.LessonTitle,
                            Content = l.LessonUrl
                        }).ToList()
                    };
                    courseFromDb.Sections.Add(newSection);
                }
            }


            courseFromDb.SectionsNo = editCourse.SectionsNo;
            _unitOfWork.SaveChanges();
            return (true, "Course Updated Successfully");
        }

    }

}
