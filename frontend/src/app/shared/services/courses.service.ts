import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError} from 'rxjs';
import { CourseData } from '../interfaces/course-data';


@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private _HttpClient: HttpClient) {}
  baseURL = 'http://localhost:5062';

  getAllCourses(): Observable<any> {
    return this._HttpClient.get(`${this.baseURL}/api/Course/GetAllCourses`);
  }

  submitCourse(data: any): Observable<any> {
    return this._HttpClient.post<any>(
      `${this.baseURL}/Api/course/uploadCourse`,
      data
    );
  }

  getAllUserCourses(id: number): Observable<any> {
    return this._HttpClient
      .get(`${this.baseURL}/api/Course/GetAllUserCourses/${id}`)
      .pipe(
        catchError((error) => {
          console.error('Error getting user courses', error);
          return throwError(() => error);
        })
      );
  }

  getCourseById(id: number): Observable<any> {
    return this._HttpClient.get(
      `${this.baseURL}/api/Course/GetCourseById/${id}`
    );
  }

  editCourse(data: any): Observable<any> {
    return this._HttpClient.put<any>(
      `${this.baseURL}/Api/course/editCourse`,
      data
    );
  }
}
