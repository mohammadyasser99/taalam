import { Component, Input } from '@angular/core';
import { ReadCourseRatingDTO } from '../../../models/Rating';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rating-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './rating-card.component.html',
  styleUrl: './rating-card.component.css',
})
export class RatingCardComponent {
  @Input() ratings: ReadCourseRatingDTO[] = [];
  currentPage = 1;
  itemsPerPage = 5;
  paginatedRatings: ReadCourseRatingDTO[] = [];

  ngOnInit(): void {
    this.updatePaginatedRatings();
  }

  get totalPages(): number {
    return Math.ceil(this.ratings.length / this.itemsPerPage);
  }

  updatePaginatedRatings(): void {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    this.paginatedRatings = this.ratings.slice(start, end);
  }

  goToPage(page: number): void {
    if (page > 0 && page <= this.totalPages) {
      this.currentPage = page;
      this.updatePaginatedRatings();
    }
  }
}
