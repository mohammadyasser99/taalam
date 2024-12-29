import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForgetpasswordtokenComponent } from './forgetpasswordtoken.component';

describe('ForgetpasswordtokenComponent', () => {
  let component: ForgetpasswordtokenComponent;
  let fixture: ComponentFixture<ForgetpasswordtokenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ForgetpasswordtokenComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForgetpasswordtokenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
