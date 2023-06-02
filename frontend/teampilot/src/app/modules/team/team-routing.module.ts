import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamComponent } from './pages/team/team.component';
import { TeamLayoutComponent } from './layouts/team-layout/team-layout.component';
import { TeamListComponent } from './pages/team-list/team-list.component';

const routes: Routes = [{path:'',
component:TeamLayoutComponent,
 children:[{path:'',
 component:TeamListComponent},
 {path:':teamId', 
 component: TeamComponent}]}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeamRoutingModule { }
