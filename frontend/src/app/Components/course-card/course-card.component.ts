import { NgClass, NgFor, NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IEnrolledCourse } from '../../shared/interfaces/course-data';

@Component({
  selector: 'app-course-card',
  standalone: true,
  imports: [NgClass, NgIf, FormsModule, NgFor],
  templateUrl: './course-card.component.html',
  styleUrl: './course-card.component.css',
})
export class CourseCardComponent {
  isHeartFilled = true;

  // Inputs to control heart icon and progress bar
  @Input() course!: IEnrolledCourse;
  @Input() showHeartIcon: boolean = true; // Control visibility of heart icon
  @Input() showProgress: boolean = true; // Control visibility of progress bar

  Math = Math;
  Number = Number;

  toggleHeart() {
    this.isHeartFilled = !this.isHeartFilled;
  }
}
