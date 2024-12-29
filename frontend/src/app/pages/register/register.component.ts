import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { UserService } from '../../shared/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  isloading: boolean = false; 
  emailerrormessage: string ='';
  passworderrormessage: string ='';
  confirmPassworderrormessage: string ='';

  phonenumbererrormessage: string ='';

registerform!:{
  fName: string,
  LName: string,
  email: string,
  password: string,
  confirmPassword: string,
  phone : number,
  userRole: number
}

constructor(private userservice:UserService,private toastr: ToastrService,private router:Router) {

 }

ngOnInit(): void {
  this.registerform = {
    fName: '',
    LName: '',
    email: '',
    password: '',
    confirmPassword: '',
    phone: 0,
    userRole: 0

  }
}

  // Helper method to clear all error messages
  clearErrorMessages() {
    this.emailerrormessage = '';
    this.passworderrormessage = '';
    this.confirmPassworderrormessage = '';
  
  }

  onSubmit(form: NgForm) {
    if (form.valid && this.registerform.password === this.registerform.confirmPassword) {
      this.isloading = true;
      this.userservice.registerUser(form.value).subscribe({
        next: (response: any) => {
          this.isloading = false;
          this.toastr.success('Registration successful');
          setTimeout(() => {
            this.router.navigate(['/']);
          }, 5000);
        },
        error: (error) => {
          this.isloading = false;
          if (error.error.errors) {
            if (error.error.errors.ConfirmPassword) {
              this.confirmPassworderrormessage = error.error.errors.ConfirmPassword;
              this.toastr.error('Password confirmation error');
            }
            if (error.error.errors.Phone) {
              this.phonenumbererrormessage = error.error.errors.Phone;
              this.toastr.error('Phone number is invalid');
            }
          }
          if (error.error.detail) {
            if (error.error.detail.includes('Username')) {
              this.emailerrormessage = error.error.detail;
              this.toastr.error('Email already exists');
            }
          }
        }
      });
    } else {
      this.toastr.error('Please fill the form correctly');
    }
  }
  
googleLogin(){
  window.location.href = 'http://localhost:5062/api/account/signin-google';
}


}

