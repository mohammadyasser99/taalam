import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rating, RatingDTO, ReadCourseRatingDTO } from '../../models/Rating';

@Injectable({
  providedIn: 'root',
})
export class RatingService {
  private apiUrl = 'http://localhost:5062/api'; // Base URL for the backend

  constructor(private http: HttpClient) {}

  // 1. Fetch all ratings for a course
  getAllRatingsForCourse(courseId: number): Observable<ReadCourseRatingDTO[]> {
    return this.http.get<ReadCourseRatingDTO[]>(
      `${this.apiUrl}/rating/courses/${courseId}`
    );
  }

  // 2. Fetch all ratings given by a user
  getAllRatingsGivenByUser(userId: number): Observable<Rating[]> {
    return this.http.get<Rating[]>(`${this.apiUrl}/rating/student/${userId}`);
  }

  // 3. Create a new rating for a course by the current user
  createRating(ratingDto: RatingDTO): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/rating`, ratingDto);
  }

  // 4. Edit a rating for a course by the current user
  editRating(ratingDto: RatingDTO): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/rating/edit`, ratingDto);
  }

  // 5. Fetch a specific rating by the current user for a course
  getOneRatingByUserForCourse(courseId: number): Observable<Rating> {
    return this.http.get<Rating>(`${this.apiUrl}/rating/course/${courseId}`);
  }
}
