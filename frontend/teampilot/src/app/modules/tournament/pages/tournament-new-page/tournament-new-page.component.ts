import { Component } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {NewTournamentDTO, TeamForTournamentDTO, TournamentService, UserService} from "../../../../services/api/v1";
import {CurrentUserService} from "../../../../services/current-user.service";
import {Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-tournament-new-page',
  templateUrl: './tournament-new-page.component.html',
  styleUrls: ['./tournament-new-page.component.css']
})
export class TournamentNewPageComponent {
  teams = new FormControl([]);
  tournament: NewTournamentDTO={};
  inputName!: string;
  inputFormat!: string;
  inputSponsor!: string;
  inputPrizePool!: string;
  inputLocation!: string;
  inputStartDate!: string;
  inputEndDate!: string;
  teamsToSelect: TeamForTournamentDTO[] = [];
  userType!: string;

  constructor(private currentUserService: CurrentUserService, private service: TournamentService, private router: Router, private snackbar: MatSnackBar) {
    this.snackbar = snackbar;
  }

  ngOnInit(){
    if(this.currentUserService.currentUser?.userType != null){
      this.userType = this.currentUserService.currentUser?.userType;
    }

    this.service.tournamentsTeamsGet().subscribe(
      (data: TeamForTournamentDTO[]) => {
        this.teamsToSelect = data
      }
    )
  }

  SaveTournament(): void {
    this.tournament = {
      tournamentId: "00000000-0000-0000-0000-000000000000",
      tournamentName: this.inputName,
      tournamentFormat: this.inputFormat,
      tournamentSponsor: this.inputSponsor,
      tournamentPrizePool: parseInt(this.inputPrizePool),
      tournamentLocation: this.inputLocation,
      tournamentStartDate: this.inputStartDate,
      tournamentEndDate: this.inputEndDate,
      tournamentParticipatingTeams: this.teams.value
    }

    console.log(this.tournament);
    this.service.tournamentsPost(this.tournament).subscribe(
      success => {
        this.router.navigate(["/tournaments/list"])
      },
      error => {
        let errorMessage = "";
        for (const key in error.error.errors){
          errorMessage += key + ":" + error.error.errors[key].join(", ") + "\n";
        }

        this.snackbar.open(
          errorMessage,
          "Close",
          {
            duration: 5000,
            horizontalPosition: 'center',
            verticalPosition: 'bottom',
          }
        )
      }
    )
  }
}
