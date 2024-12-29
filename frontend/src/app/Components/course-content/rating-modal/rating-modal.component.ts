import { Component, inject, Input } from '@angular/core';
import { NgbActiveModal, NgbRating } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { RatingDTO } from '../../../models/Rating';
import { RatingService } from '../../../shared/services/rating.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-rating-modal',
  standalone: true,

  imports: [CommonModule, FormsModule, NgbRating],
  templateUrl: './rating-modal.component.html',
  styleUrls: ['./rating-modal.component.css'],
})
export class RatingModalComponent {
  @Input() courseId!: number;
  ratingService = inject(RatingService);
  activeModal = inject(NgbActiveModal);
  toastr = inject(ToastrService);

  ratingValue = 0;
  description = '';
  isEditMode = false;

  ngOnInit(): void {
    this.loadRating();
  }

  loadRating() {
    this.ratingService.getOneRatingByUserForCourse(this.courseId).subscribe({
      next: (rating) => {
        if (rating) {
          this.ratingValue = rating.value;
          this.description = rating.description || '';
          this.isEditMode = true;
        }
      },
      error: (error) => {
        this.toastr.info('You have not rated this course yet.');
      },
    });
  }

  submitRating() {
    const ratingDto: RatingDTO = {
      courseId: this.courseId,
      value: this.ratingValue,
      description: this.description,
    };

    if (this.isEditMode) {
      this.ratingService.editRating(ratingDto).subscribe({
        next: () => {
          this.toastr.success('Rating updated successfully!');
          this.isEditMode = true; // Ensure the mode is set correctly
          this.loadRating(); // Refresh the rating data if needed
          this.activeModal.close();
        },
        error: (err) => {
           
          this.toastr.error('Failed to update the rating.');
        },
      });
    } else {
      this.ratingService.createRating(ratingDto).subscribe({
        next: () => {
          this.toastr.success('Rating submitted successfully!');
          this.isEditMode = true; // Set to edit mode after creating a rating
          this.loadRating(); // Refresh the rating data if needed
          this.activeModal.close();
        },
        error: (err) => {
           
          this.toastr.error('Failed to submit the rating.');
        },
      });
    }
  }

  closeModal() {
    this.activeModal.dismiss();
  }
}
