import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProduccionComponent } from './list-produccion.component';

describe('ListProduccionComponent', () => {
  let component: ListProduccionComponent;
  let fixture: ComponentFixture<ListProduccionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListProduccionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListProduccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
