import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayPlaneComponent } from './display-plane.component';

describe('DisplayPlaneComponent', () => {
  let component: DisplayPlaneComponent;
  let fixture: ComponentFixture<DisplayPlaneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayPlaneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayPlaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
