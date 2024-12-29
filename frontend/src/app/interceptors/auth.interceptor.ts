import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {





 
    const token = typeof window !== 'undefined' && localStorage.getItem('token');
    
    // Skip setting the token for specific URLs
    const isCloudinaryRequest = req.url.includes('https://api.cloudinary.com/v1_1/doiiwtmvq/video/upload');

    if (token && !isCloudinaryRequest && !req.url.includes('https://api.cloudinary.com/v1_1/doiiwtmvq/image/upload')) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
    
    

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          // Unauthorized response, clear the token
          typeof window !== 'undefined' && localStorage.removeItem('token');

          // Redirect to login or notify the user
          this.router.navigate(['/login']);
        }

        return throwError(() => error);
      })
    );
  }
}
