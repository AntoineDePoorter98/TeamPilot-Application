import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TournamentDTO } from '../model/tournamentDTO';
import { TeamMatchDTO } from '../model/teamMatchDTO';
import { TeamPlayerDTO } from '../model/teamPlayerDTO'; 
import { TeamDTO } from '../model/teamDTO';


@Injectable({
  providedIn: 'root'
})
export class TeamTournamentMatchService {

  constructor(private http: HttpClient) { }

  protected basePath = 'https://localhost:5000/teams';

  protected upcomingTournamentsPath = '/tournaments/upcoming';
  protected pastTournamentsPath = '/tournaments/past';
  protected ongoingTournamentsPath = '/tournaments';

  protected upcomingMatchesPath = '/matches/upcoming';
  protected pastMatchesPath = '/matches/past';
  protected teamPlayersPath = '/players';

  public getUpcomingTournaments(teamId: string):Observable<TournamentDTO[]>{return this.http.get<TournamentDTO[]>(`${this.basePath}${this.upcomingTournamentsPath}?teamId=${teamId}`)};
  public getOngoingTournaments(teamId: string):Observable<TournamentDTO[]>{return this.http.get<TournamentDTO[]>(`${this.basePath}${this.ongoingTournamentsPath}?teamId=${teamId}`)};
   public getPastTournaments(teamId: string):Observable<TournamentDTO[]>{return this.http.get<TournamentDTO[]>(`${this.basePath}${this.pastTournamentsPath}?teamId=${teamId}`)};
   public getUpcomingMatches(teamId: string):Observable<TeamMatchDTO[]>{return this.http.get<TeamMatchDTO[]>(`${this.basePath}${this.upcomingMatchesPath}?teamId=${teamId}`)};
   public getPastMatches(teamId: string):Observable<TeamMatchDTO[]>{return this.http.get<TeamMatchDTO[]>(`${this.basePath}${this.pastMatchesPath}?teamId=${teamId}`)};
   public getTeamPlayers(teamId: string):Observable<TeamPlayerDTO[]>{return this.http.get<TeamPlayerDTO[]>(`${this.basePath}${this.teamPlayersPath}?teamId=${teamId}`)};

   public updateTeamPlayers(teamId:string, team: TeamDTO):Observable<TeamDTO>{return this.http.put<TeamDTO>(`${this.basePath}/${teamId}${this.teamPlayersPath}`, team)};
}
