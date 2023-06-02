import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import {
  NewTournamentDTO,
  TeamForTournamentDTO,
  TournamentDTO,
  TournamentService,
} from '../../../../services/api/v1';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-tournament-edit-page',
  templateUrl: './tournament-edit-page.component.html',
  styleUrls: ['./tournament-edit-page.component.css'],
})
export class TournamentEditPageComponent {
  tournamentIncoming: TournamentDTO | undefined;
  tournamentOutgoing: NewTournamentDTO | undefined;
  teams = new FormControl<TeamForTournamentDTO[]>([]);
  allTeams: TeamForTournamentDTO[] = [];
  selectedTeams: TeamForTournamentDTO[] = [];
  constructor(
    private service: TournamentService,
    private route: ActivatedRoute,
    private router: Router,
    private snackbar: MatSnackBar
  ) {
    this.snackbar = snackbar;
  }

  ngOnInit() {
    const tournamentIdInRoute =
      this.route.snapshot.paramMap.get('tournamentId');
    if (tournamentIdInRoute != null) {
      this.service
        .tournamentsTeamsGet()
        .subscribe((data: TeamForTournamentDTO[]) => {
          this.allTeams = data;
        });
      this.service
        .tournamentsIdGet(tournamentIdInRoute)
        .subscribe((data: TournamentDTO) => {
          this.tournamentIncoming = data;
          this.selectedTeams = data.tournamentParticipatingTeams || [];
          this.teams.setValue(
            this.allTeams.filter((team) =>
              this.selectedTeams.some(
                (selectedTeam) => selectedTeam.teamId === team.teamId
              )
            )
          );
        });
    }
  }

  TeamChange(event: any) {
    console.log(event);
    this.teams.setValue(event.value);
  }

  SaveTournament() {
    this.tournamentOutgoing = {
      tournamentId: this.tournamentIncoming?.tournamentId,
      tournamentName: this.tournamentIncoming?.tournamentName,
      tournamentFormat: this.tournamentIncoming?.tournamentFormat,
      tournamentSponsor: this.tournamentIncoming?.tournamentSponsor,
      tournamentPrizePool: this.tournamentIncoming?.tournamentPrizePool,
      tournamentLocation: this.tournamentIncoming?.tournamentLocation,
      tournamentStartDate: this.tournamentIncoming?.tournamentStartDate,
      tournamentEndDate: this.tournamentIncoming?.tournamentEndDate,
      tournamentParticipatingTeams: this.teams.value,
    };
    if (this.tournamentOutgoing.tournamentId) {
      this.service
        .tournamentsIdPut(
          this.tournamentOutgoing.tournamentId,
          this.tournamentOutgoing
        )
        .subscribe(
          (success) => {
            this.router.navigate(['/tournaments/list']);
          },
          (error) => {
            this.snackbar.open(
              'errorMessage',

              'Close',
              {
                duration: 5000,
                horizontalPosition: 'center',
                verticalPosition: 'bottom',
              }
            );
          }
        );
    } else {
      this.snackbar.open('Invalid tournament', 'Close', {
        duration: 5000,
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
      });
    }
  }

  TournamentNotFound() {
    this.snackbar.open(
      'Tournament not found. Redirecting in 5 seconds.',
      'Close',
      {
        duration: 5000,
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
      }
    );
    setTimeout(() => {
      this.router.navigate([`/tournaments/list`]);
    }, 5000);
  }
}
