import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeaderboardLayoutComponent } from './layouts/leaderboard-layout/leaderboard-layout.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';

const routes: Routes = [
  {
    path: "",
    component: LeaderboardLayoutComponent,
    children: [
      {
        path: "",
        component: LeaderboardComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeaderboardRoutingModule { }
