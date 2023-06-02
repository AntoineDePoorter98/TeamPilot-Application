import {
  Component,
  Input,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import {
  LeaderBoardTeamDTO,
  LeaderboardService,
} from 'src/app/services/api/v1';

@Component({
  selector: 'app-leaderboard-team-list',
  templateUrl: './leaderboard-team-list.component.html',
  styleUrls: ['./leaderboard-team-list.component.css'],
})
export class LeaderboardTeamListComponent implements OnInit {
  @Input() tournamentId?: string = undefined;
  @Input() teamOrPlayerName: string = '';

  dataSource!: MatTableDataSource<LeaderBoardTeamDTO>;
  displayedColumns: string[] = [
    'teamName',
    'teamWonMatches',
    'teamLostMatches',
    'teamWonRounds',
    'teamLostRounds',
  ];

  isLoading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _leaderboardService: LeaderboardService,
    private _router: Router
  ) {}

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges) {
    let tournamentId = changes['tournamentId'].currentValue;
    this.isLoading = true;
    if (tournamentId != undefined) {
      this._leaderboardService
        .leaderboardsTournamentTournamentIdTeamsGet(tournamentId)
        .pipe(
          map((results: any) =>
            results.sort(
              (a: any, b: any) =>
                (b.teamWonMatches ?? 0) - (a.teamWonMatches ?? 0)
            )
          )
        )
        .subscribe((res) => {
          this.dataSource = new MatTableDataSource(res);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.isLoading = false;
          this.applyDefaultFilter();
        });
    } else {
      this._leaderboardService
        .leaderboardsTeamsGet()
        .pipe(
          map((results: any) =>
            results.sort(
              (a: any, b: any) =>
                (b.teamWonMatches ?? 0) - (a.teamWonMatches ?? 0)
            )
          )
        )
        .subscribe((res) => {
          this.dataSource = new MatTableDataSource(res);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.isLoading = false;
          this.applyDefaultFilter();
        });
    }
  }

  applyDefaultFilter() {
    if (this.teamOrPlayerName != null) {
      this.dataSource.filter = this.teamOrPlayerName.trim().toLowerCase();
    }
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  NavigateToTeam(teamId: string) {
    this._router.navigateByUrl(`/teams/${teamId}`);
  }
}
