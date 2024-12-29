import {
  CourseDataForEditing,
  Section,
} from './../../shared/interfaces/course-data';
import { UploadService } from './../../shared/services/upload.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CourseData } from '../../shared/interfaces/course-data';
import { CoursesService } from '../../shared/services/courses.service';
import { ToastrService } from 'ngx-toastr';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { catchError, forkJoin, Observable, of, tap, throwError } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-course',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgxDropzoneModule],
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css'],
})
export class EditCourseComponent implements OnInit {
  CourseForm: FormGroup;
  numberOfSections: number = 0;

  token: any;
  tokendata: any;
  userId: any;

  isLoading: boolean = false;
  courseId: any = 0;

  // Drag and Drop and Cloudinary Config and Functions
  files: File[] = [];
  lessonsFiles: { [sectionIndex: number]: { [lessonIndex: number]: File[] } } =
    {};

  constructor(
    private fb: FormBuilder,
    private courseService: CoursesService,
    private _ToastrService: ToastrService,
    private _UploadService: UploadService,
    private _Router: Router,
    private _ActivatedRoute: ActivatedRoute
  ) {
    this.token = localStorage.getItem('token');
    if (this.token) {
      this.tokendata = JSON.parse(atob(this.token.split('.')[1]));
      // Extracting user ID
      this.userId =
        this.tokendata[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ];
    }

    this.CourseForm = this.fb.group({
      title: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(30),
        ],
      ],
      description: ['', [Validators.required, Validators.minLength(50)]],
      category: ['', [Validators.required, Validators.minLength(5)]],
      duration: ['', [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      coverPicture: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      sections: this.fb.array([]),
    });
  }

  coverPictureFile: File[] = [];

  urlToFile(url: string, filename: string, mimeType: string): Promise<File> {
    return fetch(url)
      .then((res) => res.blob())
      .then((blob) => new File([blob], filename, { type: mimeType }));
  }

  ngOnInit(): void {
    this.loadCategories();
    this._ActivatedRoute.paramMap.subscribe({
      next: (params) => {
        this.courseId = params.get('id');
        this.courseService
          .getCourseById(this.courseId)
          .subscribe((courseData: any) => {
            console.log(courseData);
            console.log(this.courseId);
            // Patch the main course data
            this.CourseForm.patchValue({
              title: courseData.title,
              description: courseData.description,
              category: courseData.courseCategory,
              duration: courseData.duration,
              price: courseData.price,
            });
            this.numberOfSections = courseData.sectionsNo;

            // Convert the coverPicture URL to a File object and bind it to the files array
            if (courseData.coverPicture) {
              this.urlToFile(
                courseData.coverPicture,
                'coverPicture.jpg',
                'image/jpeg'
              )
                .then((file) => {
                  this.files.push(file); // Add the converted file to the files array
                  this.CourseForm.patchValue({
                    coverPicture: file,
                  });
                })
                .catch((err) => {
                  console.error(
                    'Error converting cover picture URL to File:',
                    err
                  );
                });
            }

            // Bind sections and lessons from response
            if (courseData.sections) {
              this.bindSections(courseData.sections);
            }
          });
      },
    });
  }

  bindSections(sectionsData: any[]) {
    const sectionsArray = this.CourseForm.get('sections') as FormArray;

    // Initialize lessonsFiles array
    this.lessonsFiles = [];

    // Clear existing sections
    sectionsArray.clear();

    sectionsData.forEach((section, sectionIndex) => {
      // Create section group including sectionId
      const sectionGroup = this.fb.group({
        sectionId: [section.sectionId], // Bind sectionId from the response
        sectionTitle: [section.sectionTitle, Validators.required],
        lessons: this.fb.array([]), // Create an empty lessons array for each section
      });

      // Initialize lessonsFiles for this section
      this.lessonsFiles[sectionIndex] = [];

      // Bind lessons to the section
      section.lessons.forEach((lesson: any, lessonIndex: number) => {
        // Create lesson group including lessonId
        const lessonGroup = this.fb.group({
          lessonId: [lesson.lessonId], // Bind lessonId from the response
          lessonTitle: [lesson.lessonTitle, Validators.required],
          lessonUrl: [lesson.lessonUrl, Validators.required],
        });

        // Add the lesson to the section's lessons array
        (sectionGroup.get('lessons') as FormArray).push(lessonGroup);

        // Initialize lessonsFiles for this lesson
        this.lessonsFiles[sectionIndex][lessonIndex] = [];

        // Convert the lesson URL to a File object and add it to the lessonsFiles array
        this.urlToFile(
          lesson.lessonUrl,
          `video_${lessonIndex}.mp4`,
          'video/mp4'
        )
          .then((file) => {
            this.lessonsFiles[sectionIndex][lessonIndex].push(file);
          })
          .catch((err) => {
            console.error('Error converting URL to File:', err);
          });
      });

      // Add the section group to the sections array
      sectionsArray.push(sectionGroup);
    });
  }

  get sections(): FormArray {
    return this.CourseForm.get('sections') as FormArray;
  }

  // addSection() {
  //   const section = this.fb.group({
  //     sectionTitle: ['', Validators.required],
  //     lessons: this.fb.array([]),
  //     // numberOfLessons: [0], // Add hidden control for lesson count
  //   });
  //   this.numberOfSections += 1;
  //   this.sections.push(section);
  //   const sectionsArray = this.CourseForm.get('sections') as FormArray;
  //   const sectionIndex = sectionsArray.length - 1;
  //   this.lessonsFiles[sectionIndex] = {}; // Initialize lessonsFiles for new section
  // }

  addSection() {
    const section = this.fb.group({
      sectionTitle: ['', Validators.required],
      lessons: this.fb.array([]),
      // numberOfLessons: [0], // Add hidden control for lesson count
    });
    this.numberOfSections += 1;
    this.sections.push(section);
    // const sectionsArray = this.CourseForm.get('sections') as FormArray;
    const sectionIndex = this.sections.length - 1;
    this.lessonsFiles[sectionIndex] = {}; // Initialize lessonsFiles for new section
  }

  // removeSection(index: number) {
  //   this.numberOfSections -= 1;
  //   this.sections.removeAt(index);
  // }

  removeSection(index: number) {
    this.numberOfSections -= 1;
    this.sections.removeAt(index);

    // Update lessonsFiles
    if (this.lessonsFiles[index]) {
      delete this.lessonsFiles[index];
    }

    // Adjust the indices of the remaining sections
    Object.keys(this.lessonsFiles).forEach((key) => {
      const sectionIndex = +key;
      if (sectionIndex > index) {
        this.lessonsFiles[sectionIndex - 1] = this.lessonsFiles[sectionIndex];
        delete this.lessonsFiles[sectionIndex];
      }
    });
  }

  getLessons(sectionIndex: number): FormArray {
    return this.sections.at(sectionIndex).get('lessons') as FormArray;
  }

  // addLesson(sectionIndex: number) {
  //   const lesson = this.fb.group({
  //     lessonTitle: ['', Validators.required],
  //     lessonUrl: ['', Validators.required],
  //   });

  //   this.getLessons(sectionIndex).push(lesson);
  //   // Update the lesson count
  //   this.updateLessonCount(sectionIndex);
  //   // Initialize lessonsFiles for new lesson
  //   const lessonsArray = this.getLessons(sectionIndex);
  //   const lessonIndex = lessonsArray.length - 1;
  //   if (!this.lessonsFiles[sectionIndex]) {
  //     this.lessonsFiles[sectionIndex] = {};
  //   }
  //   this.lessonsFiles[sectionIndex][lessonIndex] = []; // Initialize lessonsFiles for new lesson
  // }

  addLesson(sectionIndex: number) {
    const lesson = this.fb.group({
      lessonTitle: ['', Validators.required],
      lessonUrl: ['', Validators.required],
    });

    this.getLessons(sectionIndex).push(lesson);
    this.updateLessonCount(sectionIndex);
    const lessonIndex = this.getLessons(sectionIndex).length - 1;
    if (!this.lessonsFiles[sectionIndex]) {
      this.lessonsFiles[sectionIndex] = {};
    }
    this.lessonsFiles[sectionIndex][lessonIndex] = [];
  }

  removeLesson(sectionIndex: number, lessonIndex: number) {
    this.getLessons(sectionIndex).removeAt(lessonIndex);
    // Update the lesson count
    this.updateLessonCount(sectionIndex);
    delete this.lessonsFiles[sectionIndex][lessonIndex]; // Remove lesson files data
  }

  // updateLessonCount(sectionIndex: number) {
  //   const lessonsCount = this.getLessons(sectionIndex).length;
  //   this.sections
  //     .at(sectionIndex)
  //     .get('numberOfLessons')
  //     ?.setValue(lessonsCount);
  // }

  updateLessonCount(sectionIndex: number) {
    const lessonsCount = this.getLessons(sectionIndex).length;
    this.sections
      .at(sectionIndex)
      .get('numberOfLessons')
      ?.patchValue(lessonsCount);
  }

  // onSelect(event: any) {
  //   // Check if a file is already selected and clear it if necessary
  //   if (this.files.length > 0) {
  //     alert('You can only select one file at a time.');
  //     return;
  //   }

  //   // Get the selected file and validate it
  //   const file = event.addedFiles[0];
  //   if (!file.type.startsWith('image/')) {
  //     alert('Please select an image file (jpg, png, etc.).');
  //     return;
  //   }

  //   // Add the file to the array
  //   this.files.push(file);

  //   // Update the form control value for coverPicture with the selected file
  //   this.CourseForm.patchValue({
  //     coverPicture: file,
  //   });
  //   this.CourseForm.get('coverPicture')?.updateValueAndValidity(); // Recalculate validity
  // }

  onSelect(event: any) {
    // Clear the existing file if any
    if (this.files.length > 0) {
      this.files = []; // Clear the files array to allow only one file
    }

    // Get the selected file and validate it
    const file = event.addedFiles[0];
    if (!file.type.startsWith('image/')) {
      alert('Please select a valid image file (jpg, png, etc.).');
      return;
    }

    // Add the file to the array
    this.files.push(file);

    // Update the form control value for coverPicture with the selected file
    this.CourseForm.patchValue({
      coverPicture: file,
    });

    // Recalculate the validity of the control
    this.CourseForm.get('coverPicture')?.updateValueAndValidity();
  }

  onRemove(event: any) {
    this.files.splice(this.files.indexOf(event), 1);

    // Clear the form control when the file is removed
    this.CourseForm.patchValue({
      coverPicture: null,
    });

    // Update the form control after removing the file
    if (this.files.length === 0) {
      this.CourseForm.get('coverPicture')?.setValue(''); // Clear the form control value
      this.CourseForm.get('coverPicture')?.markAsTouched(); // Mark as touched to show validation error
      this.CourseForm.get('coverPicture')?.updateValueAndValidity(); // Recalculate validity
    }
  }

  uploadImageFile(): Observable<any> {
    // Check if the form is valid and if a file has been selected
    if (!this.CourseForm.get('coverPicture')?.valid) {
      alert('Please select a cover picture before uploading.');
      return of(null); // Return a dummy observable if no file is selected
    }

    const file = this.CourseForm.get('coverPicture')?.value;
    const formData = new FormData();
    formData.append('file', file);
    formData.append('upload_preset', 'Taalam_Project'); // Set your Cloudinary unsigned preset

    // Call the upload service and handle the response
    return this._UploadService.uploadImage(formData).pipe(
      tap((response) => {
        console.log(response.secure_url);
        const secureUrl = response.secure_url;
        this.CourseForm.patchValue({
          coverPicture: secureUrl,
        });
      }),
      catchError((err) => {
        console.error('Upload error:', err);
        alert('An error occurred while uploading the file.');
        return throwError(err); // Return an observable that throws an error
      })
    );
  }

  // onSelectLessonFile(event: any, sectionIndex: number, lessonIndex: number) {
  //   const files = event.addedFiles;

  //   // Check if more than one file is added
  //   if (files.length > 1) {
  //     // Show an error message or alert to the user (optional)
  //     alert('You can upload only one video at a time.');
  //     return; // Prevent further execution
  //   }

  //   if (!this.lessonsFiles[sectionIndex]) {
  //     this.lessonsFiles[sectionIndex] = {};
  //   }
  //   if (!this.lessonsFiles[sectionIndex][lessonIndex]) {
  //     this.lessonsFiles[sectionIndex][lessonIndex] = [];
  //   }
  //   this.lessonsFiles[sectionIndex][lessonIndex].push(...files);

  //   // Update form control value for lessonUrl with the file name or path
  //   this.getLessons(sectionIndex)
  //     .at(lessonIndex)
  //     .get('lessonUrl')
  //     ?.setValue(files[0].name); // You can use URL.createObjectURL(files[0]) for a local URL

  //   // Mark as touched and recalculate the validity to trigger validation messages
  //   this.getLessons(sectionIndex)
  //     .at(lessonIndex)
  //     .get('lessonUrl')
  //     ?.markAsTouched();
  //   this.getLessons(sectionIndex)
  //     .at(lessonIndex)
  //     .get('lessonUrl')
  //     ?.updateValueAndValidity();
  // }

  onSelectLessonFile(event: any, sectionIndex: number, lessonIndex: number) {
    const files = event.addedFiles;

    // Ensure only video files are being added
    if (files.length > 0 && files[0].type.startsWith('video/')) {
      // Initialize the lessonsFiles object if necessary
      if (!this.lessonsFiles[sectionIndex]) {
        this.lessonsFiles[sectionIndex] = {};
      }

      // Clear any existing file to ensure only one video is allowed
      this.lessonsFiles[sectionIndex][lessonIndex] = [];

      // Add the new video file
      this.lessonsFiles[sectionIndex][lessonIndex].push(files[0]);

      // Update form control value for lessonUrl with the file name or path
      this.getLessons(sectionIndex)
        .at(lessonIndex)
        .get('lessonUrl')
        ?.setValue(files[0].name); // You can use URL.createObjectURL(files[0]) for a local URL

      // Mark as touched and recalculate the validity to trigger validation messages
      this.getLessons(sectionIndex)
        .at(lessonIndex)
        .get('lessonUrl')
        ?.markAsTouched();
      this.getLessons(sectionIndex)
        .at(lessonIndex)
        .get('lessonUrl')
        ?.updateValueAndValidity();
    } else {
      // If the file is not a video, show an error (optional)
      alert('Please upload a valid video file.');
    }
  }

  onRemoveLessonFile(file: File, sectionIndex: number, lessonIndex: number) {
    this.lessonsFiles[sectionIndex][lessonIndex] = this.lessonsFiles[
      sectionIndex
    ][lessonIndex].filter((f) => f !== file);
    // If no files left, clear the form control value for lessonUrl
    if (this.lessonsFiles[sectionIndex][lessonIndex].length === 0) {
      this.getLessons(sectionIndex)
        .at(lessonIndex)
        .get('lessonUrl')
        ?.setValue('');
    }

    // Mark as touched and recalculate the validity to trigger validation messages
    this.getLessons(sectionIndex)
      .at(lessonIndex)
      .get('lessonUrl')
      ?.markAsTouched();
    this.getLessons(sectionIndex)
      .at(lessonIndex)
      .get('lessonUrl')
      ?.updateValueAndValidity();
  }

  uploadVideoFile(sectionIndex: number, lessonIndex: number): Observable<any> {
    const file = this.lessonsFiles[sectionIndex][lessonIndex][0];

    if (!file) {
      alert('Please select a video before uploading.');
      return of(null); // Return a dummy observable if no file is selected
    }

    const formData = new FormData();
    formData.append('file', file);
    formData.append('upload_preset', 'Taalam_Project');

    // Return the observable for video upload
    return this._UploadService.uploadVideo(formData).pipe(
      tap((response) => {
         
        const secureUrl = response.secure_url;
        const publicId = response.public_id; // Store public_id

        // Update the lesson form with the video URL and public_id
        this.getLessons(sectionIndex).at(lessonIndex).patchValue({
          lessonUrl: secureUrl,
          lessonPublicId: publicId, // Add this field to store public_id
        });
        // this._ToastrService.success('Video uploaded successfully.');
      }),
      catchError((err) => {
        console.error('Upload error:', err);
        this._ToastrService.error(
          'An error occurred while uploading the video.'
        );
        return throwError(err); // Return an observable that throws an error
      })
    );
  }

  onsubmit() {
    // Check if coverPicture is valid
    if (this.CourseForm.get('coverPicture')?.invalid) {
      this.CourseForm.get('coverPicture')?.markAsTouched();
    }

    if (this.CourseForm.invalid) {
      this.CourseForm.markAllAsTouched();
      return;
    } else {
      this.isLoading = true;

      // Create an array to hold all upload observables
      const uploadObservables: Observable<any>[] = [];

      // Upload image and add its observable to the array
      const imageUpload$ = this.uploadImageFile();
      uploadObservables.push(imageUpload$);

      // Iterate through each section
      Object.keys(this.lessonsFiles).forEach((sectionIndex) => {
        const sectionFiles = this.lessonsFiles[+sectionIndex]; // Convert sectionIndex to number

        // Iterate through each lesson within the section
        Object.keys(sectionFiles).forEach((lessonIndex) => {
          const lessonFiles = sectionFiles[+lessonIndex]; // Convert lessonIndex to number

          // Upload the video file for each lesson if there are files to upload
          if (lessonFiles.length > 0) {
            const videoUpload$ = this.uploadVideoFile(
              +sectionIndex,
              +lessonIndex
            ); // Pass numeric indexes to the upload function
            uploadObservables.push(videoUpload$);
          }
        });
      });

      // Wait for all uploads to complete
      forkJoin(uploadObservables).subscribe({
        next: () => {
          const formData = this.CourseForm.value;
          let json: CourseData = this.convertToJson(formData);
          console.log('Form Data to Submit:', json);

          // Submit JSON data to the backend
          this.courseService.editCourse(json).subscribe({
            next: (response) => {
              this.isLoading = false;
              console.log('Success Response:', response);
              this._ToastrService.success(
                response.message || 'Course Updated Successfully'
              );
              this._Router.navigate(['/home']);
            },
            error: (err) => {
              this.isLoading = false;
              console.error('Error Response:', err);
              this._ToastrService.error(
                err.message || 'An error occurred while Updating the course.'
              );
            },
          });
        },
        error: (err) => {
          this.isLoading = false;
          console.error('Upload error:', err);
          this._ToastrService.error(
            'An error occurred while uploading files. Please try again.'
          );
        },
      });
    }
  }

  convertToJson(formData: any): CourseDataForEditing {
    return {
      CourseId: this.courseId,
      userId: this.userId,
      title: formData.title,
      description: formData.description,
      duration: formData.duration,
      courseCategory: formData.category,
      coverPicture: formData.coverPicture,
      price: formData.price,
      sectionsNo: this.numberOfSections,
      sections: formData.sections.map((section: any) => ({
        sectionId: section.sectionId,
        sectionTitle: section.sectionTitle,
        numberOfLessons: section.numberOfLessons, // Include number of lessons in the JSON
        lessons: section.lessons.map((lesson: any) => ({
          lessonId: lesson.lessonId,
          lessonTitle: lesson.lessonTitle,
          lessonUrl: lesson.lessonUrl,
        })),
      })),
    };
  }

  categories: any[] = [];

  // ngOnInit() {
  //   // Simulate fetching categories from a service or API
  // }

  loadCategories() {
    // Simulated response from an API
    const response = [
      { id: 1, name: 'Programming' },
      { id: 2, name: 'Sporting' },
    ];

    // Assign the response to the categories array
    this.categories = response;
  }
}

// {
//   "title": "Machine Learning",
//   "description": "Supervise Learning and Unsupervise Learning",
//   "duration": "15",
//   "courseCategory": "Programming",
//   "coverPicture": "https://www.fsm.ac.in/blog/wp-content/uploads/2022/08/ml-e1610553826718.jpg",
//   "price": 500,
//   "sectionsNo": 1,
//   "rate": 0,
//   "creationDate": "2024-09-08T23:31:23.758Z",
//   "sections": [
//     {
//       "sectionTitle": "Section1",
//       "numberOfLessons": 1,
//       "lessons": [
//         {
//           "lessonTitle": "Lesson1",
//           "lessonUrl": "https://www.youtube.com/watch?v=o74WSoJxGPI"
//         }
//       ]
//     }
//   ]
// }