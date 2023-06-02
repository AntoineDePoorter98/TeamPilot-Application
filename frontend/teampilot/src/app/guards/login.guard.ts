import { inject } from '@angular/core';
import { map, of } from 'rxjs';
import {
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import {
  UserService,
  UserWithNullablePlayerPropsDTO,
} from '../services/api/v1';
import jwt_decode from 'jwt-decode';

export const loginGuard = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const router = inject(Router);
  const userService = inject(UserService);
  const currentUserService = inject(CurrentUserService);

  let authToken = localStorage.getItem('auth_token');

  if (!authToken) {
    router.navigateByUrl('/auth/login');
  }

  if (currentUserService.currentUser) return of(true);

  const decodedToken: any = jwt_decode(authToken!);

  return userService.usersIdGet(decodedToken.sub).pipe(
    map((user: UserWithNullablePlayerPropsDTO | undefined) => {
      currentUserService.currentUser = user;
      return user ? true : false;
    })
  );
};
