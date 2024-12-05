import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBeverageComponent } from './my-beverage.component';

describe('MyBeverageComponent', () => {
  let component: MyBeverageComponent;
  let fixture: ComponentFixture<MyBeverageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyBeverageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyBeverageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
