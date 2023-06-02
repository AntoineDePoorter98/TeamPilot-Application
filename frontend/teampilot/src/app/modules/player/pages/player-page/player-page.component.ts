import { Component, OnInit } from '@angular/core';
import {
  UserService,
  UserWithNullablePlayerPropsDTO,
  TeamService,
  TeamDTO,
} from 'src/app/services/api/v1';
import { Router } from '@angular/router';

@Component({
  selector: 'app-player-page',
  templateUrl: './player-page.component.html',
  styleUrls: ['./player-page.component.css'],
})
export class PlayerPageComponent implements OnInit {
  ListOfPlayers!: (UserWithNullablePlayerPropsDTO & {
    teamName?: string | null;
  })[];
  filteredPlayers!: (UserWithNullablePlayerPropsDTO & {
    teamName?: string | null;
  })[];
  searchText = '';
  displayedColumns: string[] = [
    'nickname',
    'name',
    'team',
    'email',
    'monthlySalary',
  ];

  constructor(
    private _userService: UserService,
    private _teamService: TeamService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.GetListOfPlayers();
  }

  GetListOfPlayers() {
    this._userService.usersGet().subscribe((data) => {
      this.ListOfPlayers = data.filter((user) => user.userType === 'Player');
      this.filteredPlayers = this.ListOfPlayers;
      this.ListOfPlayers.forEach((player) => {
        if (player.teamId) {
          // check if teamId is truthy
          this.getTeamName(player.teamId).then((teamName) => {
            player.teamName = teamName;
          });
        }
      });
    });
  }

  getTeamName(teamId: string): Promise<string> {
    return new Promise((resolve, reject) => {
      this._teamService.teamsIdGet(teamId).subscribe({
        next: (data: TeamDTO) => {
          resolve(data.teamName!);
        },
        error: (error: any) => {
          console.error('Error: team name not fetched', error);
          reject(error);
        },
      });
    });
  }

  filterPlayers() {
    this.filteredPlayers = this.ListOfPlayers.filter(
      (player) =>
        player.nickname
          ?.toLowerCase()
          .includes(this.searchText.toLowerCase()) ||
        `${player.firstName} ${player.lastName}`
          .toLowerCase()
          .includes(this.searchText.toLowerCase()) ||
        player.email?.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  onPlayerClick(playerId: string): void {
    this._router.navigate([`/users/${playerId}`]);
  }
}
