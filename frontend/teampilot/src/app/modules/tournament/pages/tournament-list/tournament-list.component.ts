import {Component, ViewChild} from '@angular/core';
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {TournamentDTO, TournamentService} from "../../../../services/api/v1";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-tournament-list',
  templateUrl: './tournament-list.component.html',
  styleUrls: ['./tournament-list.component.css']
})
export class TournamentListComponent {
  tournament!: MatTableDataSource<TournamentDTO>;
  paginator!: MatPaginator;
  sort!: MatSort;
  isLoading: boolean = false;

  constructor(private service: TournamentService) {

  }

  ngOnInit() {
    this.isLoading = true;
    this.service.tournamentsGet().subscribe({
        next: (data: TournamentDTO[]) => {
          this.tournament = new MatTableDataSource<TournamentDTO>(data);
          this.tournament.paginator = this.paginator;
          this.tournament.sort = this.sort;

          this.sort.active = "tournamentStartDate";
          this.sort.direction = "desc";
          this.sort.sortChange.emit({
            active: this.sort.active,
            direction: this.sort.direction
          })
          this.isLoading = false;
        },
        error: (err: HttpErrorResponse) => {
          this.isLoading = false;
        }
      }
    )
  }

  displayedColumns: string[] = ["tournamentName", "tournamentStartDate", "tournamentEndDate", "tournamentPrizePool"/*, "tournamentWinner"*/];

  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    if (this.tournament) {
      this.tournament.paginator = this.paginator;
    }
  }

  @ViewChild(MatSort) set matSort(ms: MatSort) {
    this.sort = ms;
    if (this.tournament) {
      this.tournament.sort = this.sort;

      this.sort.active = "tournamentStartDate";
      this.sort.direction = "desc";
      this.sort.sortChange.emit({
        active: this.sort.active,
        direction: this.sort.direction
      })
    }
  }
}
