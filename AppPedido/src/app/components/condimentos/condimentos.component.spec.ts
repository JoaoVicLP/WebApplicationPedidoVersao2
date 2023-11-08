import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CondimentosComponent } from './condimentos.component';

describe('CondimentosComponent', () => {
  let component: CondimentosComponent;
  let fixture: ComponentFixture<CondimentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CondimentosComponent]
    });
    fixture = TestBed.createComponent(CondimentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
