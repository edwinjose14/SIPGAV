import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGanadoComponent } from './list-ganado.component';

describe('ListGanadoComponent', () => {
  let component: ListGanadoComponent;
  let fixture: ComponentFixture<ListGanadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListGanadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListGanadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
