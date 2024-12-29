import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../shared/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-forgetpasswordtoken',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './forgetpasswordtoken.component.html',
  styleUrls: ['./forgetpasswordtoken.component.css']
})
export class ForgetpasswordtokenComponent implements OnInit {
  confirmationmessage: string = '';
  passwordErrors: string[] = [];
  passwordMismatch = false;
  newpasswordform!: {
    password: string;
    confirmPassword: string;
    email: string;
    token: string;
  };
  isloading: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private userservice: UserService,
    private router: Router,
    private toaster: ToastrService
  ) {
    this.route.queryParams.subscribe(params => {
      if (params['email'] && params['token']) {
        this.newpasswordform = {
          email: params['email'],
          token: decodeURIComponent(params['token']),
          password: '',
          confirmPassword: ''
        };
      } else {
        this.router.navigate(['/forget-password']);
      }
    });
  }

  ngOnInit(): void {}

  onsubmit(form: NgForm) {
    this.passwordErrors = [];
    this.confirmationmessage = '';
    
    // Check if password and confirm password match
    if (this.newpasswordform.password !== this.newpasswordform.confirmPassword) {
      this.passwordMismatch = true;
      this.passwordErrors.push('Passwords do not match.');
      return;
    }
    
    // Validate password rules (uppercase, digit, non-alphanumeric, length)
    if (!/[A-Z]/.test(this.newpasswordform.password)) {
      this.passwordErrors.push('Password must contain at least one uppercase letter.');
    }
    if (!/[0-9]/.test(this.newpasswordform.password)) {
      this.passwordErrors.push('Password must contain at least one digit.');
    }
    if (!/[@#$%^&+=]/.test(this.newpasswordform.password)) {
      this.passwordErrors.push('Password must contain at least one special character (@, #, $, etc.).');
    }
    if (this.newpasswordform.password.length < 10) {
      this.passwordErrors.push('Password must be at least 10 characters long.');
    }

    // If there are password errors, stop the submission
    if (this.passwordErrors.length > 0) {
      return;
    }

    // If everything is valid, proceed with form submission
    this.isloading = true;
    this.userservice.resetpassword(this.newpasswordform).subscribe({
      next: (response: any) => {
        this.toaster.success('Password reset successful');
        setTimeout(() => {
          this.router.navigate(['/']);
        }, 5000);
      },
      error: (error) => {
        this.isloading = false;
        if (error.error) {
          if (error.error.errors && error.error.errors.confirmPassword) {
            this.confirmationmessage = error.error.errors.confirmPassword[0];
          }
          if (error.error.PasswordRequiresDigit) {
            this.passwordErrors.push('Password must contain at least one digit.');
          }
          if (error.error.PasswordRequiresNonAlphanumeric) {
            this.passwordErrors.push('Password must contain at least one non-alphanumeric character.');
          }
          if (error.error.PasswordRequiresUpper) {
            this.passwordErrors.push('Password must contain at least one uppercase letter.');
          }
          if (error.error.message) {
            alert('Invalid token');
            this.router.navigate(['/forget-password']);
          }
        }
      }
    });
  }
}
