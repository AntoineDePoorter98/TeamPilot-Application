using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface ITeamManagerRepository : IRepository<TeamManager>
{
    Task<TeamManager> GetTeamManagerTournamentsAndMatchesAsync(string teamManagerId);
}
