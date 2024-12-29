import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'http://localhost:5062/api';

  constructor(private http: HttpClient) {}

  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/category`);
  }

  getCoursesByCategory(categoryId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/category/${categoryId}`);
  }

  createCategory(category: any): Observable<any> {
    let cat = category;
    return this.http.post(`${this.apiUrl}/category/`, cat);
  }

  // deleteCategory(id: number): Observable<any> {
  //   return this.http.delete(`${this.apiUrl}/category/${id}`);
  // }

  getCategoryById(categoryId: number): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/Category/GetCategoryById/${categoryId}`
    );
  }

  updateCategory(id: number, formData: FormData): Observable<any> {
    return this.http.put<any>(
      `http://localhost:5062/api/category/${id}`,
      formData
    );
  }
}
