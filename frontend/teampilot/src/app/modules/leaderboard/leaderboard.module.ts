import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LeaderboardRoutingModule } from './leaderboard-routing.module';
import { LeaderboardLayoutComponent } from './layouts/leaderboard-layout/leaderboard-layout.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';
import { LeaderboardPlayerListComponent } from './components/leaderboard-player-list/leaderboard-player-list.component';
import { LeaderboardTeamListComponent } from './components/leaderboard-team-list/leaderboard-team-list.component';

import { MatTabsModule } from '@angular/material/tabs';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    LeaderboardLayoutComponent,
    LeaderboardComponent,
    LeaderboardPlayerListComponent,
    LeaderboardTeamListComponent,
  ],
  imports: [
    CommonModule,
    LeaderboardRoutingModule,
    FormsModule,
    MatTabsModule,
    MatAutocompleteModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
  ],
})
export class LeaderboardModule {}
