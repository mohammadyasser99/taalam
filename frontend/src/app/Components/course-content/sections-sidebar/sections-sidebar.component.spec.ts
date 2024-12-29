import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionsSidebarComponent } from './sections-sidebar.component';

describe('SectionsSidebarComponent', () => {
  let component: SectionsSidebarComponent;
  let fixture: ComponentFixture<SectionsSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SectionsSidebarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SectionsSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
