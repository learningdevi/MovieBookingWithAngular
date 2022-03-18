import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineshowsComponent } from './onlineshows.component';

describe('OnlineshowsComponent', () => {
  let component: OnlineshowsComponent;
  let fixture: ComponentFixture<OnlineshowsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnlineshowsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineshowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
