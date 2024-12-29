import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CurrencyPipe, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [FormsModule, RouterLink, CurrencyPipe,NgIf,NgFor],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  categories: any[] = [];
  selectedCategoryId: number = 0;
  selectedCategoryName: string = '';
  courses: any[] = [];
  pagedCourses: any[] = [];
  currentPage: number = 1;
  pageSize: number = 8;
  totalPages: number = 0;
  totalPagesArray: number[] = [];

  constructor(private categoryService: CategoryService, private activateRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe({
      next: (params) => {
        let id: any = params.get('id');
        this.categoryService.getCoursesByCategory(id).subscribe({
          next: (response) => {
            this.selectedCategoryId = response.id;
            this.fetchCategories();            
          },
          error: (error) => {
            console.error('Error fetching category courses:', error);
          },
        });
      },
    });
   
  }

  fetchCategories(): void {
    this.categoryService.getCategories().subscribe((data: any[]) => {
      this.categories = data;
      if (this.categories.length > 0) {
        this.fetchCourses();
      }
    });
  }

  fetchCourses(): void {
    this.categoryService.getCoursesByCategory(this.selectedCategoryId).subscribe((data: any) => {
      this.selectedCategoryName = data.name;
      this.courses = data.courses;
      this.calculatePagination();
    });
  }

  onCategoryChange(categoryId: number, categoryName: string): void {
    this.selectedCategoryId = categoryId;
    this.selectedCategoryName = categoryName;
    this.currentPage = 1;
    this.fetchCourses();
  }

  calculatePagination(): void {
    this.totalPages = Math.ceil(this.courses.length / this.pageSize);
    this.totalPagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);
    this.paginate();
  }

  paginate(): void {
    const start = (this.currentPage - 1) * this.pageSize;
    const end = start + this.pageSize;
    this.pagedCourses = this.courses.slice(start, end);
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.paginate();
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.paginate();
    }
  }

  goToPage(page: number): void {
    this.currentPage = page;
    this.paginate();
  }
}
