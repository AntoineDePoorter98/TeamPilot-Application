import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TournamentRoutingModule } from './tournament-routing.module';
import { TournamentLayoutComponent } from './layouts/tournament-layout/tournament-layout.component';
import { TournamentComponent } from './pages/tournament/tournament.component';
import { TournamentListComponent } from './pages/tournament-list/tournament-list.component';
import { TournamentNewPageComponent } from './pages/tournament-new-page/tournament-new-page.component';
import {MatInputModule} from "@angular/material/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatChipsModule} from "@angular/material/chips";
import {MatTableModule} from "@angular/material/table";
import {MatPaginatorModule} from "@angular/material/paginator";
import { TournamentEditPageComponent } from './pages/tournament-edit-page/tournament-edit-page.component';
import {MatListModule} from "@angular/material/list";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatSortModule} from "@angular/material/sort";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatSelectModule} from "@angular/material/select";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatExpansionModule} from "@angular/material/expansion";


@NgModule({
  declarations: [
    TournamentLayoutComponent,
    TournamentComponent,
    TournamentListComponent,
    TournamentNewPageComponent,
    TournamentEditPageComponent
  ],
  imports: [
    CommonModule,
    TournamentRoutingModule,
    MatInputModule,
    FormsModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatTableModule,
    MatPaginatorModule,
    MatListModule,
    MatCardModule,
    MatButtonModule,
    MatSortModule,
    MatSidenavModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatExpansionModule
  ]
})
export class TournamentModule { }
