import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { TournamentDTO, TournamentService } from 'src/app/services/api/v1';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css'],
})
export class LeaderboardComponent implements OnInit {
  globalRanking: TournamentDTO = {
    tournamentId: null,
    tournamentName: 'Global Ranking',
  };

  showPlayerList: boolean = true;
  showTeamList: boolean = true;
  teamOrPlayerName: string = '';

  tournaments: TournamentDTO[] = [];
  filteredTournaments$!: Observable<TournamentDTO[]>;

  selectedTournament = new FormControl<string | TournamentDTO | undefined>('');

  constructor(
    private _tournamentService: TournamentService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      const leaderboardType = params['type'];
      const name = params['name'];
      this.teamOrPlayerName = name;

      if (leaderboardType === 'player') {
        this.showPlayerList = true;
        this.showTeamList = false;
      } else if (leaderboardType === 'team') {
        this.showTeamList = true;
        this.showPlayerList = false;
      }
    });

    this._tournamentService.tournamentsGet().subscribe((res) => {
      this.tournaments = res;
      this.tournaments.unshift(this.globalRanking);
      this.selectedTournament.setValue(this.globalRanking);
      this.filteredTournaments$ = this.selectedTournament.valueChanges.pipe(
        startWith(''),
        map((value) => {
          const name =
            typeof value === 'string' ? value : value?.tournamentName;
          return name ? this._filter(name as string) : this.tournaments.slice();
        })
      );
    });
  }

  displayFn(tournament: TournamentDTO): string {
    return tournament && tournament.tournamentName
      ? tournament.tournamentName
      : '';
  }

  clear(event: any) {
    event.stopPropagation();

    if (typeof this.selectedTournament.value === 'object') {
      if (this.selectedTournament.value?.tournamentId === null)
        this.selectedTournament.setValue('');
      else {
        this.selectedTournament.setValue(this.globalRanking);
      }
    }
  }

  getCurrentTournamentId(): string | undefined {
    if (typeof this.selectedTournament.value === 'object') {
      return this.selectedTournament.value?.tournamentId ?? undefined;
    } else {
      return undefined;
    }
  }

  private _filter(name: string): TournamentDTO[] {
    const filterValue = name.toLowerCase();

    return this.tournaments.filter((option) =>
      option.tournamentName!.toLowerCase().includes(filterValue)
    );
  }
}
