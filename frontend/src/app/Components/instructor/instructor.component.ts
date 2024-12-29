import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { UserService } from '../../shared/services/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-instructor',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './instructor.component.html',
  styleUrl: './instructor.component.css',
})
export class InstructorComponent implements OnInit {
  constructor(
    private _UserService: UserService,
    private _ActivatedRoute: ActivatedRoute
  ) {}

  instructorCourses: any[] = [];

  ngOnInit(): void {
    this._ActivatedRoute.paramMap.subscribe({
      next: (params) => {
        let id: any = params.get('id');
        this._UserService.getInstructorCourses(id).subscribe({
          next: (response) => {
            this.instructorCourses = response;
            console.log(this.instructorCourses);
          },
        });
      },
    });
  }
}
