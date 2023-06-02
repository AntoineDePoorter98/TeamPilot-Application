import { TestBed } from '@angular/core/testing';

import { TeamTournamentMatchService } from './team-tournament-match.service';

describe('TeamTournamentMatchService', () => {
  let service: TeamTournamentMatchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeamTournamentMatchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
