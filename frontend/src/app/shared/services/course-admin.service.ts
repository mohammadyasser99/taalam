import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CourseAdminService {
  private baseUrl =
    'http://localhost:5062/api'; // Replace with your API URL

  deleteCourse(courseIdToDelete: number): Observable<any> {
    return this.http.delete(
      `${this.baseUrl}/course/admin/DeleteCourse/${courseIdToDelete}`
    );
  }

  constructor(private http: HttpClient) {}
  getPaginatedCourses(
    searchTerm: string | null,
    page: number,
    pageSize: number,
    sortBy: string,
    sortOrder: string
  ): Observable<any> {
    let params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
      .set('sortBy', sortBy)
      .set('sortOrder', sortOrder);

    if (searchTerm) {
      params = params.set('searchTerm', searchTerm);
    }

    return this.http.get(`${this.baseUrl}/course/admin/GetPaginatedCourses`, {
      params,
    });
  }
}
