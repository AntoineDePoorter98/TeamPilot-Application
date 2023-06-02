using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TeamPilot.Api.Middleware;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Application.Services;
using TeamPilot.Infrastructure.DataAccess;
using TeamPilot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

string _allowedOrigins = "allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TeamPilotDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TeamPilotData"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });


builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IMatchRepository, MatchRepository>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IRegisteredUserRepository, RegisteredUserRepository>();
builder.Services.AddTransient<IRoundRepository, RoundRepository>();
builder.Services.AddTransient<IRoundEventRepository, RoundEventRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<ITeamManagerRepository, TeamManagerRepository>();
builder.Services.AddTransient<ITournamentRepository, TournamentRepository>();
builder.Services.AddTransient<ITournamentManagerRepository, TournamentManagerRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<ArticleService>();
builder.Services.AddTransient<LeaderboardService>();
builder.Services.AddTransient<TeamService>();
builder.Services.AddTransient<TournamentService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<SearchService>();

builder.Services.AddScoped<CurrentUserService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _allowedOrigins,
        policy =>
        {
            policy.WithOrigins(
                "https://localhost:4200",
                "http://localhost:4200"
                ).AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
    //Need this to make "sub" claim work
    options.MapInboundClaims = false;
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(_allowedOrigins);

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseMiddleware<AuthMiddleware>();

app.Run();
