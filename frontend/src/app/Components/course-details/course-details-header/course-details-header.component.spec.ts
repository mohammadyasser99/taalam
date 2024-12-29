import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseDetailsHeaderComponent } from './course-details-header.component';

describe('CourseDetailsHeaderComponent', () => {
  let component: CourseDetailsHeaderComponent;
  let fixture: ComponentFixture<CourseDetailsHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseDetailsHeaderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseDetailsHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
