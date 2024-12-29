import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchService } from '../../shared/services/search.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CategoryService } from '../../shared/services/category.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-search-result',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './search-result.component.html',
  styleUrl: './search-result.component.css'
})
export class SearchResultComponent {
constructor(private _SearchService:SearchService, private _ActivatedRoute:ActivatedRoute, private _CategoryService:CategoryService, ){}

searchTerm: string = '';
courses: any[] = [];
allCourses: any[] = []; // To store the original list of courses
categories: any[] = [];

catFilter: string = 'All Categories';
priceFilter: string = 'All';
durationFilter: string = 'All';

ngOnInit() {
  this._ActivatedRoute.paramMap.subscribe({
    next: (params) => {
      const searchTermParam = params.get('SearchTerm');
      
      // Check if searchTermParam is null or undefined before using trim
      if (searchTermParam) {
        const newSearchTerm = searchTermParam.trim();

        if (newSearchTerm !== this.searchTerm) {
          this.searchTerm = newSearchTerm;
          this.resetFilters();
          this.fetchCourses();
        }
      }
    }
  });

  this._CategoryService.getCategories().subscribe({
    next: (response) => {
      this.categories = response;
    }
  });
}

private fetchCourses() {
  this._SearchService.getSearchResults(this.searchTerm).subscribe({
    next: (response) => {
      this.allCourses = response;
      this.courses = [...response];
    }
  });
}

private resetFilters() {
  this.catFilter = 'All Categories';
  this.priceFilter = 'All';
  this.durationFilter = 'All';
}

filterByCategory(event: Event) {
  const target = event.target as HTMLSelectElement;
  this.catFilter = target?.value || 'All Categories';
  this.applyFilters();
}

filterByPrice(event: Event) {
  const target = event.target as HTMLSelectElement;
  this.priceFilter = target?.value || 'All';
  this.applyFilters();
}

filterByDuration(event: Event) {
  const target = event.target as HTMLSelectElement;
  this.durationFilter = target?.value || 'All';
  this.applyFilters();
}

private applyFilters() {
  let filteredCourses = this.allCourses;

  // Apply Category Filter
  if (this.catFilter && this.catFilter !== 'All Categories') {
    filteredCourses = filteredCourses.filter(c => c.categoryName === this.catFilter);
  }

  // Apply Price Filter
  if (this.priceFilter === 'Free') {
    filteredCourses = filteredCourses.filter(c => c.price === 0);
  } else if (this.priceFilter === 'Paid') {
    filteredCourses = filteredCourses.filter(c => c.price !== 0);
  }

  // Apply Duration Filter
  if (this.durationFilter === '5 - 10 Hours') {
    filteredCourses = filteredCourses.filter(c => c.duration >= 5 && c.duration <= 10);
  } else if (this.durationFilter === '10 - 20 Hours') {
    filteredCourses = filteredCourses.filter(c => c.duration > 10 && c.duration <= 20);
  } else if (this.durationFilter === '20+ Hours') {
    filteredCourses = filteredCourses.filter(c => c.duration > 20);
  }

  this.courses = filteredCourses;
  console.log('Filtered Courses:', this.courses); // Debugging line
}
}
