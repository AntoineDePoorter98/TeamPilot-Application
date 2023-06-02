import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderboardLayoutComponent } from './leaderboard-layout.component';

describe('LeaderboardLayoutComponent', () => {
  let component: LeaderboardLayoutComponent;
  let fixture: ComponentFixture<LeaderboardLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderboardLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaderboardLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
