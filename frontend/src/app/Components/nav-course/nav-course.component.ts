import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ShareModalComponent } from '../share-modal/share-modal.component';
import { CookieService } from 'ngx-cookie-service';
import { AnnouncementService } from '../../shared/services/announcement.service';
import { CartService } from '../../shared/services/cart.service';
import { CategoryService } from '../../shared/services/category.service';
import { OfferService } from '../../shared/services/offer.service';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-nav-course',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './nav-course.component.html',
  styleUrl: './nav-course.component.css',
})
export class NavCourseComponent {
  @Input() courseId!: number;
  @Input() courseTitle!: string;
  @Input() progressPercentage?: number;
  isNavbarOpen = false;

  isauth:boolean=false;
  token: any;
  tokendata: any;
  userId!: number;
  username!: string;
  role!: string;
 endofsale!: Date;
 amountofsale!: number;
 showsale:boolean=false;  

  constructor(private modalService: NgbModal,
    private _CategoryService: CategoryService,
    private _Router: Router,
    private _OfferService: OfferService,
    private userservice:UserService,
    private announcementservice:AnnouncementService,
    private cookieservice:CookieService,
    private cart:CartService,
  ) {
    if (typeof window !== 'undefined') {
      this.token = localStorage.getItem('token');
    }

    if (this.token) {
      this.isauth=true;
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
      console.log(this.userId);
      console.log(this.role)
    }

  }

  // toggleNavbar() {
  //   this.isNavbarOpen = !this.isNavbarOpen;
  // }


  openShareModal() {
    const shareLink = `http://localhost:4200/course/${this.courseId}`;
    const modalRef = this.modalService.open(ShareModalComponent, {
      size: 'md',
    });
    modalRef.componentInstance.shareLink = shareLink;
  }

  isDropdownOpen:any = {
    userDropdown: false,

    categoryDropdown: false
  };

  toggleNavbar() {
    this.isNavbarOpen = !this.isNavbarOpen;
  }

  toggleDropdown(dropdown: string) {
    // Close all dropdowns if the clicked one is already open
    if (this.isDropdownOpen[dropdown]) {
      this.isDropdownOpen[dropdown] = false;
    } else {
      // Close all other dropdowns
      Object.keys(this.isDropdownOpen).forEach(key => this.isDropdownOpen[key] = false);
      this.isDropdownOpen[dropdown] = true;
    }
  }
  logout() {
    this.userservice.logout().subscribe({
   
       next:(response)=>{
   if (typeof window !== 'undefined') {
         localStorage.removeItem('token');
         this.cookieservice.delete('taalam');
         this.cookieservice.delete('Identity.External');
     
         this.isauth=false;
         this._Router.navigate(['/login']);
       }
   
     
   }
     })
       }

}
