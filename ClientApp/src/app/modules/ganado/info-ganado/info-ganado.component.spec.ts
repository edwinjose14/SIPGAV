import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoGanadoComponent } from './info-ganado.component';

describe('InfoGanadoComponent', () => {
  let component: InfoGanadoComponent;
  let fixture: ComponentFixture<InfoGanadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoGanadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfoGanadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
