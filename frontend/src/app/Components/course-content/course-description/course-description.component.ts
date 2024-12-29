import {
  Component,
  EventEmitter,
  inject,
  Input,
  Output, // <-- Add Output for emitting events
} from '@angular/core';
import {
  NgbModal,
  NgbModalModule,
  NgbProgressbarModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { CourseDetailsService } from '../../../shared/services/course/course-details-service/course-details.service';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { Lesson } from '../../../models/CourseDetails';
import { RatingModalComponent } from '../rating-modal/rating-modal.component';

@Component({
  selector: 'app-course-description',
  standalone: true,
  imports: [NgbModalModule, CommonModule, NgbProgressbarModule,NgbTooltipModule],
  templateUrl: './course-description.component.html',
  styleUrl: './course-description.component.css',
})
export class CourseDescriptionComponent {
  @Input() courseId!: number;
  @Input() progressPercentage!: number;
  @Input({ required: true }) selectedLesson!: Lesson;
  @Input() isLastLesson!: boolean;
  @Input() isFirstLesson!:boolean;

  @Output() progressUpdated = new EventEmitter<void>();

  @Output() nextLesson = new EventEmitter<void>();
  @Output() PrevLesson = new EventEmitter<void>();


  goToNextLesson() {
    this.nextLesson.emit(); // Notify parent component
  }

  goToPrevLession(){
    this.PrevLesson.emit(); // Notify parent component

  }

  loadingSubject = new BehaviorSubject<boolean>(false);
  loading$ = this.loadingSubject.asObservable();
  toastr = inject(ToastrService);
  modalService = inject(NgbModal);
  courseDetailsSrv = inject(CourseDetailsService);

  markAsCompleted() {
    if (!this.selectedLesson.id || this.selectedLesson.isCompleted) {
      return;
    }

    this.loadingSubject.next(true);
    this.courseDetailsSrv
      .markLessonAsCompleted(this.selectedLesson.id, this.courseId)
      .subscribe({
        next: () => {
          this.selectedLesson.isCompleted = true;
          this.progressUpdated.emit();
        },
        error: () => {
          this.toastr.error('Something went wrong');
          this.loadingSubject.next(false);
        },
        complete: () => {
          this.loadingSubject.next(false);
        },
      });
  }

  openRatingModal() {
    const modalRef = this.modalService.open(RatingModalComponent, {
      size: 'md',
    });
    modalRef.componentInstance.courseId = this.courseId;
  }

  downloadCertificate() {
    this.courseDetailsSrv.downloadCertificate(this.courseId).subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `Certificate_Course_${this.courseId}.pdf`; // Name the file
        a.click();
        window.URL.revokeObjectURL(url); // Clean up
      },
      error: () => {
        this.toastr.error('Failed to download the certificate');
      },
    });
  }
}
