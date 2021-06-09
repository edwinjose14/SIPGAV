import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalGanadoComponent } from './modal-ganado.component';

describe('ModalGanadoComponent', () => {
  let component: ModalGanadoComponent;
  let fixture: ComponentFixture<ModalGanadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalGanadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalGanadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
