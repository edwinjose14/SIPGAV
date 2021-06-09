import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalMaquinaComponent } from './modal-maquina.component';

describe('ModalMaquinaComponent', () => {
  let component: ModalMaquinaComponent;
  let fixture: ComponentFixture<ModalMaquinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalMaquinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalMaquinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
