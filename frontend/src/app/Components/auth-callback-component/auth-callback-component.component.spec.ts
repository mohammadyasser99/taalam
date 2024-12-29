import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthCallbackComponentComponent } from './auth-callback-component.component';

describe('AuthCallbackComponentComponent', () => {
  let component: AuthCallbackComponentComponent;
  let fixture: ComponentFixture<AuthCallbackComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthCallbackComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthCallbackComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
