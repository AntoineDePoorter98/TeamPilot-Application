import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderboardPlayerListComponent } from './leaderboard-player-list.component';

describe('LeaderboardPlayerListComponent', () => {
  let component: LeaderboardPlayerListComponent;
  let fixture: ComponentFixture<LeaderboardPlayerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderboardPlayerListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaderboardPlayerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
