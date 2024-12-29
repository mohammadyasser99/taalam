import { Component, Input, OnInit } from '@angular/core';
import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';
import { Course } from '../../../models/CourseDetails';
import { CommonModule } from '@angular/common';
import { CartService } from '../../../shared/services/cart.service';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course-details-header',
  standalone: true,
  imports: [NgbRatingModule, CommonModule,RouterModule],
  templateUrl: './course-details-header.component.html',
  styleUrl: './course-details-header.component.css',
})
export class CourseDetailsHeaderComponent implements OnInit {
  @Input() course!: Course;
  @Input()isenrolled: boolean = false;
  @Input() isauth: boolean = false;



  constructor(
    private cartService: CartService,
    private toastr: ToastrService,
    private route:Router,
    private httpclient:HttpClient

  ) {}
  ngOnInit(): void {
this.httpclient.get(`http://localhost:5062/api/Course/IsEnrolled/${this.course.id}`).subscribe((data: any) => {

      this.isenrolled = data.isEnrolled;
      console.log(this.isenrolled);
    });
  }

  getFormattedDate(dateString: string): string {
    const date = new Date(dateString);
    return date.toLocaleDateString(undefined, {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
    });
  }

  // Add to Cart Function
  addToCart(courseId: number): void {
    if (!this.isauth) {
      
      this.route.navigate(['/login']);
    }
    this.cartService.addtoCart(courseId).subscribe({
      next: () => {
        this.toastr.success('Course added to cart successfully!');
      },
      error: () => {
        this.toastr.error('Failed to add course to cart.');
      },
    });
  }
}
