import { Injectable } from '@angular/core';
import { UserService, UserWithNullablePlayerPropsDTO } from './api/v1';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class CurrentUserService {
  currentUser?: UserWithNullablePlayerPropsDTO | undefined;

  currentUserPlayerMock?: UserWithNullablePlayerPropsDTO | undefined = {
    userId: '96d7edd4-fe68-463f-83fb-f74d12d63dfe',
    email: 's1mple@navi.com',
    nickname: 's1mple',
    userType: 'Player',
  };


  currentUserTeamManagerMock?: UserWithNullablePlayerPropsDTO | undefined = {
    userId: 'd9773f35-52c0-49e8-81dc-787e27ade5e2',
    email: 'daps@liquid.com@g2.com',
    nickname: 'daps',
    userType: 'TeamManager',
  };

  // currentUserTeamManagerMock?: UserWithNullablePlayerPropsDTO | undefined = {
  //   userId: 'a896562e-47eb-4feb-a4a3-e289d7920dbf',
  //   email: 'swani@g2.com',
  //   nickname: 'Swani',
  //   userType: 'TeamManager',
  // };

  currentUserTournamentManagerPlayMock?:
    | UserWithNullablePlayerPropsDTO
    | undefined = {
    userId: '18939449-5193-4c86-a744-0b60f6b5cf17',
    email: 'potti@esl.com',
    nickname: 'Potti',
    userType: 'TournamentManager',
  };

  currentUserRegisterdUserMock?: UserWithNullablePlayerPropsDTO | undefined = {
    userId: '9b684792-2f6e-43b6-a524-256acdc6b0f5',
    email: 'Estefania52@gmail.com',
    nickname: 'Mellie_Kihn58',
    userType: 'RegisteredUser',
  };

  isCurrentUserLoading: boolean = false;

  constructor(private _userService: UserService) {}

  setCurrentUser() {
    let authToken = localStorage.getItem('auth_token');

    if (!this.currentUser && authToken) {
      const decodedToken: any = jwt_decode(authToken);

      this.isCurrentUserLoading = true;

      this._userService
        .usersIdGet(decodedToken.sub)
        .subscribe((res: UserWithNullablePlayerPropsDTO | undefined) => {
          this.currentUser = res;
          this.isCurrentUserLoading = false;
        });
    }
  }
}
