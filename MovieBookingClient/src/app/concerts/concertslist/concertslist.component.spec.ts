import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConcertslistComponent } from './concertslist.component';

describe('ConcertslistComponent', () => {
  let component: ConcertslistComponent;
  let fixture: ComponentFixture<ConcertslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConcertslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConcertslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
