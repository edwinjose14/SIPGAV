import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalTrabajadorComponent } from './modal-trabajador.component';

describe('ModalTrabajadorComponent', () => {
  let component: ModalTrabajadorComponent;
  let fixture: ComponentFixture<ModalTrabajadorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalTrabajadorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalTrabajadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
