import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeamRoutingModule } from './team-routing.module';
import { TeamLayoutComponent } from './layouts/team-layout/team-layout.component';
import { TeamComponent } from './pages/team/team.component';
import { TeamListComponent } from './pages/team-list/team-list.component';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { EditComponent } from './svgs/edit/edit.component';
import { AddComponent } from './svgs/add/add.component';
import { RemoveComponent } from './svgs/remove/remove.component';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    TeamLayoutComponent,
    TeamComponent,
    TeamListComponent,
    EditComponent,
    AddComponent,
    RemoveComponent
  ],
  imports: [
    CommonModule,
    TeamRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatSelectModule,
    MatToolbarModule,
    MatPaginatorModule
  ]
})
export class TeamModule { }
