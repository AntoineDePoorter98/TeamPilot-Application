import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderboardTeamListComponent } from './leaderboard-team-list.component';

describe('LeaderboardTeamListComponent', () => {
  let component: LeaderboardTeamListComponent;
  let fixture: ComponentFixture<LeaderboardTeamListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderboardTeamListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaderboardTeamListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
