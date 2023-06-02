using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(TeamPilotDbContext context) : base(context)
    {
    }
}
