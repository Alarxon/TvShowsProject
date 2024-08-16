import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertShowComponent } from './insert-show.component';

describe('InsertShowComponent', () => {
  let component: InsertShowComponent;
  let fixture: ComponentFixture<InsertShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InsertShowComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InsertShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
