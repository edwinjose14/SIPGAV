import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoMaquinaComponent } from './info-maquina.component';

describe('InfoMaquinaComponent', () => {
  let component: InfoMaquinaComponent;
  let fixture: ComponentFixture<InfoMaquinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoMaquinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfoMaquinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
