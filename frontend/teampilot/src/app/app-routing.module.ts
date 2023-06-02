import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { loginGuard } from './guards/login.guard';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./modules/feed/feed.module').then((x) => x.FeedModule),
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then((x) => x.AuthModule),
  },
  {
    path: 'tests',
    loadChildren: () =>
      import('./modules/test/test.module').then((x) => x.TestModule),
  },
  {
    path: 'users/:id',
    loadChildren: () =>
      import('./modules/user-profile/user-profile.module').then(
        (x) => x.UserProfileModule
      ),
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./modules/leaderboard/leaderboard.module').then(
        (x) => x.LeaderboardModule
      ),
    //canActivate: [loginGuard],
  },
  {
    path: 'teams',
    loadChildren: () =>
      import('./modules/team/team.module').then((x) => x.TeamModule),
  },
  {
    path: 'tournaments',
    loadChildren: () =>
      import('./modules/tournament/tournament.module').then(
        (x) => x.TournamentModule
      ),
  },
  {
    path: 'players',
    loadChildren: () =>
      import('./modules/player/player.module').then((x) => x.PlayerModule),
  },
  {
    path: '**',
    pathMatch: 'full',
    component: PagenotfoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
