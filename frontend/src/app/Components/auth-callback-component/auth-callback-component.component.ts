import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-auth-callback-component',
  standalone: true,
  imports: [],
  templateUrl: './auth-callback-component.component.html',
  styleUrl: './auth-callback-component.component.css'
})
export class AuthCallbackComponentComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }


  ngOnInit(){
    this.route.queryParams.subscribe(params => {
      const token = params['token'];
      
      if (token) {
        // Store the token in localStorage
        if (typeof window !== 'undefined') {
          localStorage.setItem('token', token);
          
        }
   

        // Optionally navigate to the dashboard or home
        this.router.navigate(['/']);
      } else {
        // Handle error if token is missing
        console.error('Token is missing');
      }
    });

  }

}
