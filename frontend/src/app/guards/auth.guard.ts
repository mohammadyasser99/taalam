import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";




export const authGuard: CanActivateFn = (route, state) => {
    const _Router = inject(Router);
  
    // if (localStorage.getItem('token')) {
    //   return true;
    // } else {
    //   _Router.navigate(['/login']);
    //   return false;
    // }

    if (typeof window !== 'undefined') {
      if (localStorage.getItem('token') ) {
        return true;
      } else {
        _Router.navigate(['/login']);
        return false;
        

    }

    }
    return false;

  };

  export const authGuardLogin: CanActivateFn = (route, state) => {
    const _Router = inject(Router);
    const cookiesservice = inject(CookieService);
  
    // if (localStorage.getItem('_token')) {
    //   _Router.navigate(['/home']);
    //   return false;
    // } else {
    //   return true;
    // }

    if (typeof window !== 'undefined') {
      if (localStorage.getItem('token') || cookiesservice.get('taalam')) {
        _Router.navigate(['/home']);
        return false;
      } else {
        return true;
        
    }
    }
    return false;
  };

  export const authGuardadmin: CanActivateFn = (route, state) => {
    const _Router = inject(Router);
    const cookieService = inject(CookieService);
  
    // Role of the user (will be determined later)
    let role: string | null = null;
  
    // Ensure we are in the browser environment
    if (typeof window !== 'undefined') {
const token = localStorage.getItem('token');
if (token) {
  const tokendata = JSON.parse(atob(token.split('.')[1]));
  role = tokendata['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
}

if (role === 'Admin') {
  return true;
}else{
  alert('You are not authorized to access this page');
  _Router.navigate(['/login']);
  return false;
}

    }
  
    // Default return false if any condition fails
    return false;
  };


