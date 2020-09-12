import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoCuentasComponent } from './tipo-cuentas.component';

describe('TipoCuentasComponent', () => {
  let component: TipoCuentasComponent;
  let fixture: ComponentFixture<TipoCuentasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoCuentasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoCuentasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
