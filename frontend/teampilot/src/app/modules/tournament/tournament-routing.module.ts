import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TournamentLayoutComponent} from "./layouts/tournament-layout/tournament-layout.component";
import {TournamentListComponent} from "./pages/tournament-list/tournament-list.component";
import {TournamentComponent} from "./pages/tournament/tournament.component";
import {TournamentNewPageComponent} from "./pages/tournament-new-page/tournament-new-page.component";
import {TournamentEditPageComponent} from "./pages/tournament-edit-page/tournament-edit-page.component";

const routes: Routes = [
  {
    path: "",
    component: TournamentLayoutComponent,
    children: [
      {
        path: "list",
        component: TournamentListComponent
      },
      {
        path: "new",
        component: TournamentNewPageComponent
      },
      {
        path: ":tournamentId",
        component: TournamentComponent
      },
      {
        path: "edit/:tournamentId",
        component: TournamentEditPageComponent
      },
      {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TournamentRoutingModule { }
