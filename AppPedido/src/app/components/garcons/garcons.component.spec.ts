import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarconsComponent } from './garcons.component';

describe('GarconsComponent', () => {
  let component: GarconsComponent;
  let fixture: ComponentFixture<GarconsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarconsComponent]
    });
    fixture = TestBed.createComponent(GarconsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
