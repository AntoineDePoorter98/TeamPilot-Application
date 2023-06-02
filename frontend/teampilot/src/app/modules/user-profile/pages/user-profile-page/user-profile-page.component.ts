import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  TeamDTO,
  TeamService,
  TournamentMatchDTO,
  UserService,
} from 'src/app/services/api/v1';
import { UserWithNullablePlayerPropsDTO } from 'src/app/services/api/v1';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.css'],
})
export class UserProfilePageComponent implements OnInit {
  //user is the user we are currently viewing
  userId!: string;
  user!: UserWithNullablePlayerPropsDTO;
  userForm!: FormGroup;
  isEditMode: boolean = false;
  //currentUser is the user that is currently logged in
  currentUserDto!: UserWithNullablePlayerPropsDTO;
  currentUserType!: string;
  currentUserId!: string;
  followedPlayers!: UserWithNullablePlayerPropsDTO[];
  isPlayerFollowed: boolean = false;
  tournamentsMatches: TournamentMatchDTO[] = [];
  isOnOwnUserPage: boolean = false;
  teamName!: string;

  constructor(
    private _router: Router,
    private _route: ActivatedRoute,
    private _userService: UserService,
    private _teamService: TeamService,
    private _fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      this.userId = params['id'];

      this.userForm = this._fb.group({
        nickname: ['', [Validators.required, Validators.maxLength(50)]],
        firstName: ['', [Validators.required, Validators.maxLength(50)]],
        lastName: ['', [Validators.required, Validators.maxLength(50)]],
        email: [
          '',
          [Validators.required, Validators.email, Validators.maxLength(100)],
        ],
        avatarUrl: ['', [Validators.maxLength(150)]],
        bio: ['', [Validators.maxLength(300)]],
      });

      let authToken = localStorage.getItem('auth_token');

      if (authToken) {
        const decodedToken: any = jwt_decode(authToken);
        this.currentUserType = decodedToken.type;
        this.currentUserId = decodedToken.sub;
      }

      this.fetchUserDetails();
    });
  }

  viewUserProfile(userId: string) {
    this._router.navigate(['/user', userId]);
  }

  //we call this method in ngOnInit to check user type and call the appropriate method
  fetchUserDetails(): void {
    this._userService.usersIdGet(this.userId).subscribe({
      next: (data: UserWithNullablePlayerPropsDTO) => {
        this.user = data;
        this.userForm.patchValue(this.user);

        if (this.user && this.user.userType) {
          if (this.user.userType === 'TeamManager') {
            this.callMethodForTeamManager();
          } else if (this.user.userType === 'Player') {
            this.callMethodForPlayer();
          } else if (this.user.userType === 'RegisteredUser') {
            this.callMethodForRegisteredUser();
          } else if (this.user.userType === 'TournamentManager') {
            this.callMethodForTournamentManager();
          }
        }
      },
      error: (error: any) => {
        console.error('Error:', error);
      },
    });
  }

  toggleEditMode(): void {
    if (!this.isEditMode) {
      this.isEditMode = true;
      // Populate form with existing user data
      this.userForm.patchValue(this.user);
    } else {
      this.isEditMode = false;
    }
  }

  saveChanges(): void {
    if (this.userForm.valid) {
      const updatedUser: UserWithNullablePlayerPropsDTO = {
        ...this.user,
        ...this.userForm.value,
      };
      this._userService.usersIdPut(this.userId, updatedUser).subscribe({
        next: (data: UserWithNullablePlayerPropsDTO) => {
          this.user = data;
          this.isEditMode = false;
        },
        error: (error: any) => {
          console.error('Error:', error);
        },
      });
    }
  }

  callMethodForTeamManager(): void {
    // logic specific to team manager
    this.getTeamManagerTournamentsAndMatches();
  }

  async callMethodForPlayer(): Promise<void> {
    // logic specific to player
    this.getPlayerTournamentsAndMatches();
    await this.getTeamName(this.user?.teamId!);
    this.getAllFollows();
  }

  callMethodForRegisteredUser(): void {
    // logic specific to registered user
    this.getAllFollows();
  }

  callMethodForTournamentManager(): void {
    // logic specific to tournament manager
    this.getTournamentManagerTournamentsAndMatches();
  }

  confirmDeleteUser() {
    if (window.confirm('Are you sure you want to delete your account?')) {
      this.deleteUser();
    }
  }

  deleteUser(): void {
    this.deleteAllFollows();
    this._userService.usersIdDelete(this.userId).subscribe({
      next: (data: any) => {
        this._router.navigate(['/auth/register']);
      },
      error: (error: any) => {
        console.error('Error: account delete failed', error);
      },
    });
  }

  deleteAllFollows(): void {
    this._userService.usersUserIdUnfollowAllDelete(this.userId).subscribe({
      next: (data: any) => {
        this.fetchUserDetails();
      },
      error: (error: any) => {
        console.error('Error: user follows were not deleted', error);
      },
    });
  }

  getAllFollows(): void {
    this._userService.getFollowedPlayers(this.currentUserId).subscribe({
      next: (data: UserWithNullablePlayerPropsDTO[]) => {
        const requests = data.map((player) => {
          if (player.teamId) {
            return this._teamService
              .teamsIdGet(player.teamId)
              .toPromise()
              .then((team: TeamDTO | undefined) => {
                if (team) {
                  player.teamName = team.teamName || null;
                }
                return player;
              });
          } else {
            return Promise.resolve(player);
          }
        });

        Promise.all(requests).then((followedPlayers) => {
          this.followedPlayers = followedPlayers;
          this.checkIfPlayerIsFollowed();
        });
      },
      error: (error: any) => {
        console.error('Error: user follows query failed', error);
      },
    });
  }

  checkIfPlayerIsFollowed(): void {
    this.followedPlayers.forEach((player) => {
      if (player.userId === this.userId) {
        this.isPlayerFollowed = true;
      }
    });
  }

  registeredUserAddFollowToPlayer(): void {
    this._userService
      .usersUserIdFollowItemTypeItemIdPost(
        this.currentUserId,
        this.userId,
        'Player'
      )
      .subscribe({
        next: (data: any) => {
          this.fetchUserDetails();
        },
        error: (error: any) => {
          console.error('Error: follow failed', error);
        },
      });
  }

  registeredUserRemoveFollowFromPlayer(): void {
    this._userService
      .usersUserIdUnfollowItemTypeItemIdDelete(
        this.currentUserId,
        this.userId,
        'Player'
      )
      .subscribe({
        next: (data: any) => {
          this.isPlayerFollowed = false;
          this.fetchUserDetails();
        },
        error: (error: any) => {
          console.error('Error: unfollow failed', error);
        },
      });
  }

  getTeamManagerTournamentsAndMatches() {
    this._userService
      .usersTeamManagerTournamentsAndMatchesTeamManagerIdGet(this.userId)
      .subscribe({
        next: (data: TournamentMatchDTO[]) => {
          this.tournamentsMatches = data;
        },
        error: (error: any) => {
          console.error('Error: tournaments and matches not fetched', error);
        },
      });
  }

  getTournamentManagerTournamentsAndMatches() {
    this._userService
      .usersTournamentManagerTournamentsAndMatchesTournamentManagerIdGet(
        this.userId
      )
      .subscribe({
        next: (data: TournamentMatchDTO[]) => {
          this.tournamentsMatches = data;
        },
        error: (error: any) => {
          console.error('Error: tournaments and matches not fetched', error);
        },
      });
  }

  getPlayerTournamentsAndMatches() {
    this._userService
      .usersPlayerTournamentsAndMatchesPlayerIdGet(this.userId)
      .subscribe({
        next: (data: TournamentMatchDTO[]) => {
          this.tournamentsMatches = data;
        },
        error: (error: any) => {
          console.error('Error: tournaments and matches not fetched', error);
        },
      });
  }

  getTeamName(teamId: string): Promise<void> {
    return new Promise((resolve, reject) => {
      this._teamService.teamsIdGet(teamId).subscribe({
        next: (data: TeamDTO) => {
          this.teamName = data.teamName!;
          resolve();
        },
        error: (error: any) => {
          console.error('Error: team name not fetched', error);
          reject(error);
        },
      });
    });
  }

  GoToTournament(): void {
    this._router.navigate(['/tournaments']);
  }

  GoToTournamentId(tournamentId: string | null | undefined): void {
    this._router.navigate(['/tournaments', tournamentId]);
  }

  GoToTeamId(teamId: string | null | undefined): void {
    this._router.navigate(['/teams', teamId]);
  }

  GoToPlayerId(playerId: string | null | undefined): void {
    this._router.navigate(['/users', playerId]);
  }

  GoToPlayerLeaderboard(): void {
    this._router.navigate([
      '/leaderboard',
      { type: 'player', name: this.user?.nickname },
    ]);
  }

  GoToTeamLeaderboard(): void {
    if (
      this.tournamentsMatches.length > 0 &&
      this.tournamentsMatches[0].match &&
      this.tournamentsMatches[0].match.participatingTeams &&
      this.tournamentsMatches[0].match.participatingTeams.length > 0
    ) {
      const teamName =
        this.tournamentsMatches[0].match.participatingTeams[0].teamName;

      if (teamName) {
        this._router.navigate([
          '/leaderboard',
          { type: 'team', name: teamName },
        ]);
      }
    }
  }
}
