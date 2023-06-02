using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Application.Services;
using TeamPilot.Infrastructure.DataAccess;
using TeamPilot.Infrastructure.Repositories;

namespace TeamPilot.Tests
{
    public class Startup
    {
        public Startup()
        {

        }

        //Needed if services use IConfiguration
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json");
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TeamPilotDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TeamPilotData;Trusted_Connection=True;MultipleActiveResultSets=true");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IRegisteredUserRepository, RegisteredUserRepository>();
            services.AddTransient<IRoundRepository, RoundRepository>();
            services.AddTransient<IRoundEventRepository, RoundEventRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamManagerRepository, TeamManagerRepository>();
            services.AddTransient<ITournamentRepository, TournamentRepository>();
            services.AddTransient<ITournamentManagerRepository, TournamentManagerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ArticleService>();
            services.AddTransient<LeaderboardService>();
            services.AddTransient<TeamService>();
            services.AddTransient<TournamentService>();
            services.AddTransient<UserService>();
            services.AddTransient<AuthService>();

            services.AddScoped<CurrentUserService>();


        }
    }
}
