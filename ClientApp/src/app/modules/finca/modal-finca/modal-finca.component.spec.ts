import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalFincaComponent } from './modal-finca.component';

describe('ModalFincaComponent', () => {
  let component: ModalFincaComponent;
  let fixture: ComponentFixture<ModalFincaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalFincaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalFincaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
