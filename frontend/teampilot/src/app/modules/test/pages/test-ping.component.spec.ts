import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestPingComponent } from './test-ping.component';

describe('TestPingComponent', () => {
  let component: TestPingComponent;
  let fixture: ComponentFixture<TestPingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestPingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestPingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
