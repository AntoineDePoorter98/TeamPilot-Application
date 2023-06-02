/**
 * TeamPilot.Api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { TeamForTournamentDTO } from './teamForTournamentDTO';


export interface NewTournamentDTO { 
    tournamentId?: string | null;
    tournamentName?: string | null;
    tournamentFormat?: string | null;
    tournamentPrizePool?: number;
    tournamentLocation?: string | null;
    tournamentSponsor?: string | null;
    tournamentStartDate?: string | null;
    tournamentEndDate?: string | null;
    tournamentParticipatingTeams?: Array<TeamForTournamentDTO> | null;
}

