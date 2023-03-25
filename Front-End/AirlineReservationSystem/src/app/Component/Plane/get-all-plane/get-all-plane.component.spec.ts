import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllPlaneComponent } from './get-all-plane.component';

describe('GetAllPlaneComponent', () => {
  let component: GetAllPlaneComponent;
  let fixture: ComponentFixture<GetAllPlaneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAllPlaneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllPlaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
