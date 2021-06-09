import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoProduccionComponent } from './info-produccion.component';

describe('InfoProduccionComponent', () => {
  let component: InfoProduccionComponent;
  let fixture: ComponentFixture<InfoProduccionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoProduccionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfoProduccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
