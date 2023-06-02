import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestPingLayoutComponent } from './test-ping-layout.component';

describe('TestPingLayoutComponent', () => {
  let component: TestPingLayoutComponent;
  let fixture: ComponentFixture<TestPingLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestPingLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestPingLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
