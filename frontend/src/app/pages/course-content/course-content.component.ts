import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course, Lesson, Section } from '../../models/CourseDetails';
import { CourseDetailsService } from '../../shared/services/course/course-details-service/course-details.service';
import { CourseVideoPlayerComponent } from '../../Components/course-content/course-video-player/course-video-player.component';
import { CourseDescriptionComponent } from '../../Components/course-content/course-description/course-description.component';
import { SectionsSidebarComponent } from '../../Components/course-content/sections-sidebar/sections-sidebar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NavCourseComponent } from '../../Components/nav-course/nav-course.component';
import { ShareModalComponent } from '../../Components/share-modal/share-modal.component';
import { FooterComponent } from "../../Components/footer/footer.component";

@Component({
  selector: 'app-course-content',
  standalone: true,
  imports: [
    CourseVideoPlayerComponent,
    CourseDescriptionComponent,
    SectionsSidebarComponent,
    FormsModule,
    CommonModule,
    NavCourseComponent,
    ShareModalComponent,
    FooterComponent
],

  templateUrl: './course-content.component.html',
  styleUrl: './course-content.component.css',
})
export class CourseContentComponent {
  courseId!: number;
  lessonId!: number;
  selectedLesson: Lesson | undefined;
  course: Course | null = null;
  progressPercentage!: number;

  courseDetailsSrv = inject(CourseDetailsService);
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  cdr = inject(ChangeDetectorRef);
  completedLessons?: number = 0;

  isLastLesson: boolean = false;
  isFirstLesson: boolean = false
  // To track if it's the last lesson

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.courseId = +params['courseId'];
      if (!params['lessonId']) {
        this.lessonId = this.course?.sections[0].lessons[0].id!;
      }
      this.lessonId = +params['lessonId'];
      this.getCourseDetails(this.courseId);
      this.checkIfLastLesson();
    this.checkFirstLesson();
    });
  }

  getCourseDetails(id: number) {
    this.courseDetailsSrv.getCourseContent(id).subscribe({
      next: (res) => {
        this.course = res;
        this.progressPercentage =
          this.course?.studentEnrollment?.progressPercentage || 0;
        this.selectedLesson = this.course?.sections[0].lessons[0];

        const totalLessons = this.course?.sections.flatMap(
          (section) => section.lessons
        ).length;
        this.completedLessons = this.course?.studentEnrollment.completedLessons;
        this.updateProgress(totalLessons!, this.completedLessons!);
        this.loadLesson();
      },
      error: () => {
        this.router.navigate(['not-found']);
      },
    });
  }

  loadLesson() {
    if (this.lessonId && this.course?.sections) {
      this.selectedLesson = this.course.sections
        .flatMap((section) => section.lessons)
        .find((lesson) => lesson.id === this.lessonId);
    }
  }

  onLessonSelected(lesson: Lesson) {
    this.selectedLesson = lesson;
    this.router
this.router.navigate([`/course/content/${this.courseId}/${lesson.id}`], {
  replaceUrl: true,
})      .then(() => this.loadLesson());
    this.cdr.detectChanges();
  }

  updateProgress(totalLessons: number, completedLessons: number) {
    if (totalLessons > 0) {
      this.progressPercentage = (completedLessons / totalLessons) * 100;
    } else {
      this.progressPercentage = 0;
    }
  }

  onProgressUpdated(completedLessonIncrement: number) {
    const totalLessons =
      this.course?.sections.flatMap((section) => section.lessons).length || 0;

    this.completedLessons! += completedLessonIncrement;

    this.updateProgress(totalLessons, this.completedLessons!);
  }

  goToNextLesson() {
    if (!this.course || !this.selectedLesson) return;

    // Find current section and lesson indexes
    let sectionIndex = this.course.sections.findIndex((section) =>
      section.lessons.includes(this.selectedLesson!)
    );
    let lessonIndex = this.course.sections[sectionIndex].lessons.findIndex(
      (lesson) => lesson.id === this.selectedLesson!.id
    );

    // Move to the next lesson in the same section
    if (lessonIndex < this.course.sections[sectionIndex].lessons.length - 1) {
      this.onLessonSelected(
        this.course.sections[sectionIndex].lessons[lessonIndex + 1]
      );
    }
    // Move to the first lesson in the next section if current section ends
    else if (sectionIndex < this.course.sections.length - 1) {
      this.onLessonSelected(this.course.sections[sectionIndex + 1].lessons[0]);
    }

    // Check if this is the last lesson in the entire course
    this.checkIfLastLesson();
  }

  goToPrevLesson() {
    if (!this.course || !this.selectedLesson) return;

    // Find current section and lesson indexes
    let sectionIndex = this.course.sections.findIndex((section) =>
      section.lessons.includes(this.selectedLesson!)
    );
    let lessonIndex = this.course.sections[sectionIndex].lessons.findIndex(
      (lesson) => lesson.id === this.selectedLesson!.id
    );

    // Move to the previous lesson in the same section
    if (lessonIndex > 0) {
      this.onLessonSelected(
        this.course.sections[sectionIndex].lessons[lessonIndex - 1]
      );
    }
    // Move to the last lesson in the previous section if current section starts
    else if (sectionIndex > 0) {
      const prevSection = this.course.sections[sectionIndex - 1];
      this.onLessonSelected(prevSection.lessons[prevSection.lessons.length - 1]);
    }

    // Check if this is the first lesson in the entire course
    this.checkFirstLesson();
}


  checkIfLastLesson() {
    if (!this.course || !this.selectedLesson) return;

    // Check if current lesson is the last in the course
    const allLessons = this.course.sections.flatMap(
      (section) => section.lessons
    );
    this.isLastLesson =
      this.selectedLesson?.id === allLessons[allLessons.length - 1].id;
  }

  checkFirstLesson() {
    if (!this.course || !this.selectedLesson) return;

    // Check if current lesson is the first in the course
    const allLessons = this.course.sections.flatMap(
      (section) => section.lessons
    );
    this.isFirstLesson =
      this.selectedLesson?.id === allLessons[0].id;
}

}
