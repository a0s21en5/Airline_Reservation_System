import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPlaneComponent } from './search-plane.component';

describe('SearchPlaneComponent', () => {
  let component: SearchPlaneComponent;
  let fixture: ComponentFixture<SearchPlaneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchPlaneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchPlaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
