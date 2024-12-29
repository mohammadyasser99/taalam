import { Component, TemplateRef, ViewChild } from '@angular/core';
import { CourseAdminService } from '../../shared/services/course-admin.service';
import { NgbModal, NgbPagination } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-course-admin',
  standalone: true,
  imports: [NgbPagination, CommonModule, FormsModule],
  templateUrl: './course-admin.component.html',
  styleUrl: './course-admin.component.css',
})
export class CourseAdminComponent {
  @ViewChild('deleteModal') deleteModal: TemplateRef<any> | undefined;
  courses: any[] = [];
  totalCourses: number = 0;
  page: number = 1;
  pageSize: number = 10;
  searchTerm: string = '';
  sortBy: string = 'title';
  sortOrder: string = 'asc';
  courseIdToDelete: number | null = null;

  constructor(
    private courseAdminService: CourseAdminService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses(): void {
    this.courseAdminService
      .getPaginatedCourses(
        this.searchTerm,
        this.page,
        this.pageSize,
        this.sortBy,
        this.sortOrder
      )
      .subscribe((response: any) => {
        if(response){
        this.courses = response.courses;
        this.totalCourses = response.totalCourses;
        }else{
          this.courses=[]
          this.totalCourses=0;
        }
      });
  }

  onPageChange(page: number): void {
    this.page = page;
    this.loadCourses();
  }

 onSort(column: string) {
  if (column === 'description') {
    // Disable sorting for description
    return;
  }

  // Toggle sort order if the same column is clicked, otherwise set it to ascending
  this.sortOrder = this.sortBy === column && this.sortOrder === 'asc' ? 'desc' : 'asc';
  this.sortBy = column;

  // Fetch the sorted courses
  this.fetchCourses();
}

fetchCourses() {
  this.courseAdminService.getPaginatedCourses(
    this.searchTerm,
    this.page,
    this.pageSize,
    this.sortBy,
    this.sortOrder
  ).subscribe(response => {
    if(response){
    this.courses = response.courses;
    this.totalCourses = response.totalCourses;
    }
  });
}

  onSearch(): void {
    this.page = 1;
    this.loadCourses();
  }

  openDeleteModal(courseId: number): void {
    this.courseIdToDelete = courseId;
    this.modalService.open(this.deleteModal);
  }

  confirmDelete(modal: any): void {
    if (this.courseIdToDelete !== null) {
      this.courseAdminService
        .deleteCourse(this.courseIdToDelete)
        .subscribe(() => {
          this.loadCourses();
          modal.close();
        });
    }
  }
}
