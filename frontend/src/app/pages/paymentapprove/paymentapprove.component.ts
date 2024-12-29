import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';


@Component({
  selector: 'app-paymentapprove',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './paymentapprove.component.html',
  styleUrl: './paymentapprove.component.css'
})
export class PaymentapproveComponent {
  message:string = '';
  token: any;
  tokendata: any;
  userId!: number;
  username!: string;
  role!: string;
constructor(private activatedroute:ActivatedRoute ){
  this.activatedroute.queryParams.subscribe(params =>{
    if (params['success']) {
      this.message = params['success'];
    }
  });
  
  if (typeof window !== 'undefined') {
    this.token = localStorage.getItem('token');
  }

  if (this.token) {
    this.tokendata = JSON.parse(atob(this.token.split('.')[1]));

    // Extracting user ID, username, and role
    this.userId =
      this.tokendata[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ];
    this.username = this.tokendata['sub']; // Username claim
    this.role =
      this.tokendata[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ]; // Role claim
  }

}
}
