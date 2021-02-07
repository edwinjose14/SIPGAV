import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFincaComponent } from './list-finca.component';

describe('ListFincaComponent', () => {
  let component: ListFincaComponent;
  let fixture: ComponentFixture<ListFincaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListFincaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListFincaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
