import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalProduccionComponent } from './modal-produccion.component';

describe('ModalProduccionComponent', () => {
  let component: ModalProduccionComponent;
  let fixture: ComponentFixture<ModalProduccionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalProduccionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalProduccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
