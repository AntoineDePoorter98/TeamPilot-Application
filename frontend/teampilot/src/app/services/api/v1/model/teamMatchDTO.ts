import { TeamForTournamentDTO } from './teamForTournamentDTO';

export interface TeamMatchDTO { 

matchId?: string | null;
matchLengthInMinutes?: string | null;
matchDate?: string | null;
participatingTeams?: Array<TeamForTournamentDTO> | null;

tournamentId?: string | null;
tournamentTitle?: string | null;
}