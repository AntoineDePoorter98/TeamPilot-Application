import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import {
  LeaderBoardPlayerDTO,
  LeaderboardService,
} from 'src/app/services/api/v1';

@Component({
  selector: 'app-leaderboard-player-list',
  templateUrl: './leaderboard-player-list.component.html',
  styleUrls: ['./leaderboard-player-list.component.css'],
})
export class LeaderboardPlayerListComponent {
  @Input() tournamentId?: string = undefined;
  @Input() teamOrPlayerName: string = '';

  dataSource!: MatTableDataSource<LeaderBoardPlayerDTO>;
  displayedColumns: string[] = [
    'playerName',
    'playerKDRatio',
    'playerKills',
    'playerDeaths',
  ];

  isLoading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _leaderboardService: LeaderboardService,
    private _router: Router
  ) {}

  ngOnChanges(changes: SimpleChanges) {
    let tournamentId = changes['tournamentId'].currentValue;
    this.isLoading = true;

    if (tournamentId != undefined) {
      this._leaderboardService
        .leaderboardsTournamentTournamentIdPlayersGet(tournamentId)
        .subscribe((res) => {
          this.dataSource = new MatTableDataSource(res);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.isLoading = false;
          this.applyDefaultFilter();
        });
    } else {
      this._leaderboardService.leaderboardsPlayersGet().subscribe((res) => {
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

  NavigateToPlayer(playerId: string) {
    this._router.navigateByUrl(`/users/${playerId}`);
  }
}
