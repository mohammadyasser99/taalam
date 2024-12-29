import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateannouncementComponent } from './createannouncement.component';

describe('CreateannouncementComponent', () => {
  let component: CreateannouncementComponent;
  let fixture: ComponentFixture<CreateannouncementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateannouncementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateannouncementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
