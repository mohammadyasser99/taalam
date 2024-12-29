import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { UserService } from '../../shared/services/user.service';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-forgetpassword',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterLink],
  templateUrl: './forgetpassword.component.html',
  styleUrl: './forgetpassword.component.css'
})
export class ForgetpasswordComponent implements OnInit {
errormessage: string = '';
forgetpasswordform!:{
  email: string
}
isloading: boolean = false;
constructor(private userservice:UserService,private route :Router,private toaster:ToastrService) { }
  ngOnInit(): void {
    this.forgetpasswordform = {
      email: ''
    }
  }

  onsubmit(form: NgForm) {
    this.errormessage ='';
      if (form.valid) {
this.isloading = true;
        this.userservice.forgetpassword(this.forgetpasswordform).subscribe({
          next: (response: any) => {
            this.isloading = false;
            console.log('Forget password successful', response);
            this.toaster.success('reset link sent to your email');
       
          //    this.route.navigate(['/forget-passwordToken']);
       
    
          },
          error: (error) => {
            console.log(error);
            this.errormessage = error.error.detail;
            console.log(error.error.detail);
            this.toaster.error(error.error.detail);
            
           // console.log('Error in forget password', error);
          //  console.log(error.error.detail);
            
          }
        });
      
        
      }
   
   }


}
