import { APP_INITIALIZER, ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { AuthInterceptor } from './interceptors/auth.interceptor';





export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }),
     provideRouter(routes),
      provideClientHydration(), provideHttpClient(
    withFetch(),
    withInterceptorsFromDi(),
    
   ), 
   { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
   provideAnimations(),

   provideToastr({
    autoDismiss: true,
    maxOpened: 1,
    newestOnTop: false,
    preventDuplicates: false,
    countDuplicates: false,
    resetTimeoutOnDuplicate: false,
    progressBar: true,
    progressAnimation: 'decreasing',
    timeOut: 3000,
    positionClass: 'toast-bottom-right',
    closeButton: false,
  }), // Toastr providers

  ]
};

