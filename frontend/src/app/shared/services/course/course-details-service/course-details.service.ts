import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CourseDetailsService {
  constructor(private httpClient: HttpClient) {}

  getCourseDetails(id: number): Observable<any> {
    return this.httpClient.get(`http://localhost:5062/api/Course`, {
      params: new HttpParams().set('id', id),
    });
  }

  getCourseContent(id: number): Observable<any> {
    return this.httpClient.get(
      `http://localhost:5062/api/course/content/${id}`
    );
  }

  markLessonAsCompleted(lessonId: number, courseId: number): Observable<any> {
    console.log('Lesson ID:', lessonId, 'Course ID:', courseId); // Check the values
    return this.httpClient.post(
      `http://localhost:5062/api/Course/complete-lesson`,
      {
        lessonId,
        courseId,
      }
    );
  }

  downloadCertificate(courseId: number): Observable<Blob> {
    const certUrl = `http://localhost:5062/api/course/getOrCreateCert/${courseId}`;
    return this.httpClient.get(certUrl, { responseType: 'blob' });
  }

  enrollFreeCourse() : Observable<any>{
    return this.httpClient.get(`http://localhost:5062/api/Course/enrollFree`)
  }
}
