export interface TeamPlayerDTO { 
    userId?: string | null;
    userType?: string | null;
    nickname?: string | null;
    firstName?: string | null;
    lastName?: string | null;
    email?: string | null;
    avatarUrl?: string | null;
    bio?: string | null;
    teamId?: string | null;
    monthlySalary?: string | null;

    playerKills?: number |null;
    playerDeaths?: number | null;
    playerKDRatio?: number | null;
}