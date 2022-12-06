import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityDetailPageComponent } from './city-detail-page.component';

describe('CityDetailPageComponent', () => {
  let component: CityDetailPageComponent;
  let fixture: ComponentFixture<CityDetailPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CityDetailPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CityDetailPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
