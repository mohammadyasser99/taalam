import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'; // Import CommonModule
import { InstructorInfoWithCourses } from './../../shared/interfaces/instructor-info-with-courses';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-instructor-profile',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './instructor-profile.component.html',
  styleUrls: ['./instructor-profile.component.css'],
})
export class InstructorProfileComponent implements OnInit {
  instructorInfo: InstructorInfoWithCourses = {} as InstructorInfoWithCourses;
  paginatedCourses: any[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 6;
  totalPages: number = 0;
  pages: number[] = [];

  constructor(
    private _UserService: UserService,
    private _ActivatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this._ActivatedRoute.paramMap.subscribe({
      next: (params) => {
        let id: any = params.get('id');
        this._UserService.getInstructorInfo(id).subscribe({
          next: (response) => {
            this.instructorInfo = response;
            this.setupPagination();
          },
          error: (error) => {
            console.error('Error fetching instructor info:', error);
          },
        });
      },
    });
  }

  setupPagination(): void {
    if (this.instructorInfo.ownedCourses) {
      this.totalPages = Math.ceil(
        this.instructorInfo.ownedCourses.length / this.itemsPerPage
      );
      this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1); // Generate page numbers
      this.updatePaginatedCourses();
    }
  }

  updatePaginatedCourses(): void {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedCourses = this.instructorInfo.ownedCourses.slice(
      startIndex,
      endIndex
    );
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      window.scrollTo({ top: 0, behavior: 'smooth' }); // Scroll to the top smoothly
      this.updatePaginatedCourses();
    }
  }
}
