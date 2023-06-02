import { Component } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";
import {TournamentService, UserService, UserWithNullablePlayerPropsDTO} from 'src/app/services/api/v1/';
import {TournamentDTO} from "../../../../services/api/v1";
import {CurrentUserService} from "../../../../services/current-user.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.scss']
})
export class TournamentComponent {
  tournament: TournamentDTO={};
  isLoading: boolean = false;
  currentUser?: UserWithNullablePlayerPropsDTO;
  currentDate: Date = new Date();
  endDate: Date = new Date();
  startDate: Date = new Date();

  constructor(private service: TournamentService, public currentUserService: CurrentUserService, private route: ActivatedRoute, private router: Router, private snackbar: MatSnackBar) {
    this.snackbar = snackbar;
    if (currentUserService.currentUser) {
      this.currentUser = currentUserService.currentUser;
    }
  }

  ngOnInit(){
    this.isLoading = true;
    const tournamentIdInRoute = this.route.snapshot.paramMap.get("tournamentId");
    if (tournamentIdInRoute != null) {
      this.service.tournamentsIdGet(tournamentIdInRoute).subscribe({
        next: (data: TournamentDTO) => {
          this.tournament = data
          this.isLoading = false
          this.endDate = new Date(this.tournament.tournamentEndDate!)
          this.startDate = new Date(this.tournament.tournamentStartDate!)
        },
        error: (err: HttpErrorResponse) => {
          this.isLoading = false
          this.TournamentNotFound()
        }
      }
      )
    }
  }

  TournamentNotFound() {
    this.router.navigate(["**"])
    this.snackbar.open(
      "Tournament not found. Redirecting in 5 seconds.",
      "Close",
      {
        duration: 5000,
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
      }
    )
    setTimeout(() => {
      this.router.navigate(["/tournaments/list"])
    }, 5000);
  }

  LinkToEditTournament(tournamentId: string | null | undefined){
    if(!tournamentId){
      this.router.navigate(["tournaments"])
    }
    this.router.navigate(["/tournaments/edit", tournamentId]);
  }

  LinkToLeaderboardForTournament(){
    this.router.navigate(["leaderboard"])
  }
}
