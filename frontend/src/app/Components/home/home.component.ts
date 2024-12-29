import { Component, OnInit } from '@angular/core';
import { CoursesService } from '../../shared/services/courses.service';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { CategoryService } from '../../shared/services/category.service';
import {
  ActivatedRoute,
  RouterLink,
  NavigationEnd,
  Router,
} from '@angular/router';
import { CarouselService } from '../../shared/services/carousel.service';
import { FormsModule } from '@angular/forms';
import { BackToTopService } from '../../shared/services/backtotop.service';
import { CourseCardComponent } from '../course-card/course-card.component';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    CarouselModule,
    FormsModule,
    CourseCardComponent,
  ],

  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  token!: any;
  tokendata: any;
  username: string = '';
  role!: string;
  private subscription: any;
  courses: any[] = [];
  categories: any[] = [];
  userId: any = '';
  userData: any;

  constructor(
    private _CoursesService: CoursesService,
    private _CategoryService: CategoryService,
    private _ActivatedRoute: ActivatedRoute,
    private carouselService: CarouselService,
    private router: Router,
    private backToTopService: BackToTopService
  ) {
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
      console.log(this.userId);
      console.log(this.role);
    }
  }

  ngOnInit(): void {
    this.carouselService.initializeCarousels();

    // Reinitialize carousel on route change
    this.subscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.carouselService.initializeCarousels();
      }
    });

    this.backToTopService.initializeBackToTop();

    // Reinitialize on route change
    this.subscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.backToTopService.initializeBackToTop();
      }
    });
    console.log(this.username);

    this._ActivatedRoute.paramMap.subscribe({
      next: (params) => {
        //shayl kol eli fe el url

        if (params.get('id')) {
          this.userId = params.get('id');
        }
      },
    });

    console.log(this.userId);
    this._CoursesService.getAllCourses().subscribe({
      next: (response) => {
         
        this.courses = response;
      },
    });

    this._CategoryService.getCategories().subscribe({
      next: (response) => {
        this.categories = response;
      },
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
