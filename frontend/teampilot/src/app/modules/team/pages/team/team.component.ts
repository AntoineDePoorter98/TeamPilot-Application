import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

// services

import { CurrentUserService } from 'src/app/services/current-user.service';
import {
  LeaderBoardPlayerDTO,
  LeaderboardService,
  PlayerDTO,
  UserWithNullablePlayerPropsDTO,
} from 'src/app/services/api/v1';
import { TeamTournamentMatchService } from 'src/app/services/api/v1/additional-team-services/team-tournament-match.service';
import { TeamService } from 'src/app/services/api/v1';
import { UserService } from 'src/app/services/api/v1';

// dtos

import { TournamentDTO } from 'src/app/services/api/v1';
import { TeamMatchDTO } from 'src/app/services/api/v1/model/teamMatchDTO';
import { PastMatchDTO } from 'src/app/services/api/v1';
import { LeaderBoardTeamDTO } from 'src/app/services/api/v1';
import { TeamPlayerDTO } from 'src/app/services/api/v1/model/teamPlayerDTO';
import { TeamDTO } from 'src/app/services/api/v1';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss'],
})
export class TeamComponent {
  manager?: UserWithNullablePlayerPropsDTO;

  team?: TeamDTO;
  teamToUpdate: TeamDTO = { teamName: '' };

  upcomingTournaments?: TournamentDTO[];
  pastTournaments?: TournamentDTO[];
  ongoingTournaments?: TournamentDTO[];

  upcomingMatches?: TeamMatchDTO[];
  pastMatches?: TeamMatchDTO[];

  futureTournamentMatches?: TeamMatchDTO[] = [];
  pastTournamentMatches?: PastMatchDTO[] = [];

  allTeamsStats?: LeaderBoardTeamDTO[] = [];
  teamStats?: LeaderBoardTeamDTO;

  teamPlayers?: TeamPlayerDTO[] = [];
  playerStats?: LeaderBoardPlayerDTO[] = [];

  playersToAdd: PlayerDTO[] = [];
  playerToAdd: string = '';
  editSalaryId: string = '';

  newSalary: number = 0.0;

  teamValues = [
    { name: 'Matches Won', num: 0 },
    { name: 'Matches Lost', num: 0 },
    { name: 'Rounds Won', num: 0 },
    { name: 'Rounds Lost', num: 0 },
  ];

  constructor(
    private teamService: TeamService,
    private teamTournamentMatchService: TeamTournamentMatchService,
    private userService: CurrentUserService,
    private leadService: LeaderboardService,
    private route: ActivatedRoute,
    private playerService: UserService
  ) {}

  ngOnInit(): void {
    this.getTeam();

    this.getOngoingTournaments();
    this.getUpcomingTournaments();
    this.getPastTournaments();

    this.getUpcomingMatches();
    this.getPastMatches();

    this.getTeamPlayers();
    this.getTeamStats();
  }

  getTeam(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamToUpdate.teamId = teamId;
    this.teamService.teamsIdGet(teamId).subscribe((team) => {
      this.team = team;
      this.manager = this.userService.currentUser;
    });
  }

  getUpcomingTournaments(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getUpcomingTournaments(teamId)
      .subscribe((tournaments) => {
        this.upcomingTournaments = tournaments;
        this.upcomingTournaments.forEach((t) => {
          t.tournamentStartDate = t.tournamentStartDate?.substring(0, 10);
          t.tournamentEndDate = t.tournamentEndDate?.substring(0, 10);
        });
      });
  }

  getOngoingTournaments(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getOngoingTournaments(teamId)
      .subscribe((tournaments) => {
        this.ongoingTournaments = tournaments;
        this.ongoingTournaments.forEach((t) => {
          t.tournamentStartDate = t.tournamentStartDate?.substring(0, 10);
          t.tournamentEndDate = t.tournamentEndDate?.substring(0, 10);
        });
      });
  }

  getPastTournaments(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getPastTournaments(teamId)
      .subscribe((tournaments) => {
        this.pastTournaments = tournaments.reverse();
        this.pastTournaments.forEach((t) => {
          t.tournamentStartDate = t.tournamentStartDate?.substring(0, 10);
          t.tournamentEndDate = t.tournamentEndDate?.substring(0, 10);
        });
      });
  }

  getUpcomingMatches(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getUpcomingMatches(teamId)
      .subscribe((matches) => (this.upcomingMatches = matches));
  }

  getPastMatches(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getPastMatches(teamId)
      .subscribe((matches) => (this.pastMatches = matches));
  }

  getTeamStats(): void {
    this.leadService.leaderboardsTeamsGet().subscribe((stats) => {
      const teamId = String(
        this.route.snapshot.paramMap.get('teamId')?.toString()
      );
      stats.forEach((t) => (t.teamId == teamId ? (this.teamStats = t) : null));
      this.teamValues[0].num = Number(this.teamStats?.teamWonMatches);
      this.teamValues[1].num = Number(this.teamStats?.teamLostMatches);
      this.teamValues[2].num = Number(this.teamStats?.teamWonRounds);
      this.teamValues[3].num = Number(this.teamStats?.teamLostRounds);
    });
  }

  getTeamPlayers(): void {
    const teamId = String(
      this.route.snapshot.paramMap.get('teamId')?.toString()
    );
    this.teamTournamentMatchService
      .getTeamPlayers(teamId)
      .subscribe((players) => {
        this.teamPlayers = players;
        this.leadService.leaderboardsPlayersGet().subscribe((lp) => {
          this.playerStats = lp;
          lp.forEach((plp) => {
            players.forEach((p) => {
              p.userId == plp.playerId
                ? ((p.playerKills = plp.playerKills),
                  (p.playerDeaths = plp.playerDeaths))
                : null;
              p.playerKDRatio =
                (p?.playerKills ?? 0) /
                ((p?.playerDeaths ?? 0) + (p?.playerKills ?? 0));
              p.playerKDRatio = Math.floor(p.playerKDRatio * 100);
            });
          });
        });
      });
  }

  getMatches(id: string) {
    this.futureTournamentMatches?.length == 0
      ? this.upcomingMatches?.forEach((m) =>
          m.tournamentId == id && !this.futureTournamentMatches?.includes(m)
            ? this.futureTournamentMatches?.push(m)
            : null
        )
      : (this.futureTournamentMatches = []);
    this.pastTournamentMatches?.length == 0
      ? this.pastMatches?.forEach((m) => {
          if (m.tournamentId == id) {
            this.pastTournaments?.forEach((t) => {
              t.pastTournamentMatches?.forEach((pm) =>
                pm.matchId == m.matchId
                  ? ((pm.tournamentId = id),
                    this.pastTournamentMatches?.push(pm))
                  : null
              );
              if (this.pastTournamentMatches?.length == 0) {
                this.ongoingTournaments?.forEach((ot) => {
                  ot.pastTournamentMatches?.forEach((opm) =>
                    opm.matchId == m.matchId
                      ? ((opm.tournamentId = id),
                        this.pastTournamentMatches?.push(opm))
                      : null
                  );
                });
              }
            });
          }
        })
      : (this.pastTournamentMatches = []);
  }

  // team manager methods

  updateTeamDetails() {
    this.teamToUpdate.teamId = this.team?.teamId;
    this.teamService
      .teamsIdPut(this.teamToUpdate?.teamId ?? '', this.teamToUpdate)
      .subscribe((r) => {
        this.teamToUpdate = r;
        location.reload();
      });
  }

  updatePlayerPay() {
    this.teamToUpdate = this.team ? this.team : { teamId: '' };
    this.teamToUpdate.players?.forEach((op) =>
      op.userId == this.editSalaryId
        ? (op.monthlySalary = this.newSalary.toString())
        : null
    );
    this.teamTournamentMatchService
      .updateTeamPlayers(this.teamToUpdate?.teamId ?? '', this.teamToUpdate)
      .subscribe((t) => {
        this.teamToUpdate = t;
        location.reload();
      });
  }

  removePlayer(userId: string) {
    this.teamToUpdate = this.team ? this.team : { teamId: '' };
    this.teamToUpdate.players?.forEach((e, i) => {
      e.userId == userId
        ? this.teamToUpdate.players?.splice(i, 1)
        : console.log('nope' + e.nickname);
    });
    this.teamTournamentMatchService
      .updateTeamPlayers(this.teamToUpdate?.teamId ?? '', this.teamToUpdate)
      .subscribe((t) => {
        this.teamToUpdate = t;
        location.reload();
      });
  }

  addPlayer() {
    this.teamToUpdate = this.team ? this.team : { teamId: '' };
    this.playersToAdd.forEach((p) =>
      p.userId == this.playerToAdd && !this.teamToUpdate.players?.includes(p)
        ? this.teamToUpdate.players?.push(p)
        : null
    );
    this.teamTournamentMatchService
      .updateTeamPlayers(this.team?.teamId ?? '', this.teamToUpdate)
      .subscribe((t) => {
        this.teamToUpdate = t;
        location.reload();
      });
  }

  getAvailablePlayers() {
    if (this.playersToAdd.length == 0) {
      this.playerService.usersGet().subscribe((users) =>
        users.forEach((u) =>
          u.userType == 'Player' && u.teamId == ''
            ? this.playersToAdd?.push({
                userId: u.userId,
                nickname: u.nickname,
                monthlySalary: u.monthlySalary?.toString(),
              })
            : null
        )
      );
      this.playersToAdd?.forEach((e) => console.log(e.nickname));
    } else {
      this.playersToAdd = [];
      this.playerToAdd = '';
    }
  }

  toggleSalaryEditor(userId: string) {
    this.editSalaryId == ''
      ? (this.editSalaryId = userId)
      : ((this.editSalaryId = ''), (this.newSalary = 0.0));
  }
}
