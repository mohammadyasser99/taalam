import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { catchError, Observable, throwError ,tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly apiUrl = 'http://localhost:5062/api/User';
  constructor(private http: HttpClient,  private cookieservice:CookieService) {} //service to make HTTP requests
  registerUser(user: any) {
    return this.http
      .post('http://localhost:5062/Api/Account/register', user)
      .pipe(
        tap((response: any) => {
          const token = response.token;
          if (token) {
            localStorage.setItem('token', token);
            // Set the expiration timer
            this.setTokenExpiration(token);
          }
        }),
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  setTokenExpiration(token: string) {
    const tokenData = JSON.parse(atob(token.split('.')[1]));
    const tokenExpiration = new Date(tokenData.exp * 1000);

    const now = new Date();
    const expiresIn = tokenExpiration.getTime() - now.getTime();
    setTimeout(() => {
      localStorage.removeItem('token');
    }, expiresIn);
  }

  loginUser(user: any) {

    return this.http.post('http://localhost:5062/Api/Account/login', user,{withCredentials: true }).pipe(

      tap((response: any) => {
        const token = response.token;
        if (token) {
          localStorage.setItem('token', token);
          this.setTokenExpiration(token);
        }
      }),
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  updateUserProfile(formData: FormData): Observable<any> {
    return this.http.put(`${this.apiUrl}/Edit-User-Profile`, formData).pipe(
      catchError((error) => {
        console.error('Error updating user profile', error);
        return throwError(() => error);
      })
    );
  }
  forgetpassword(form: { email: string }) {
    return this.http
      .post('http://localhost:5062/Api/Account/forget-password', form)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  resetpassword(form: {
    email: string;
    token: string;
    password: string;
    confirmPassword: string;
  }) {
    return this.http
      .post('http://localhost:5062/Api/Account/reset-password', form)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  getInstructorInfo(id: number): Observable<any> {
    return this.http.get(
      `http://localhost:5062/api/User/Get-Instructor-Info/${id}`
    );
  }

  getInstructorCourses(id: number): Observable<any> {
    return this.http.get(
      `http://localhost:5062/api/Account/instructor-courses/${id}`
    );
  }

  getUserInfo(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/Get-Instructor-Info/${id}`).pipe(
      catchError((error) => {
        console.error('Error getting user profile', error);
        return throwError(() => error);
      })
    );
  }

  getusers(): Observable<any> {
    return this.http.get(`http://localhost:5062/Api/Account/getusers`).pipe(
      catchError((error) => {
        console.error('Error getting users', error);
        return throwError(() => error);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  this.cookieservice.deleteAll();
    return this.http.get('http://localhost:5062/Api/Account/logout').pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  approveuser(id: number) {
    return this.http
      .get(`http://localhost:5062/Api/Account/approveuser/${id}`)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  deleteuser(id: number) {

    return this.http
      .delete(`http://localhost:5062/Api/Account/delete/${id}`)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
