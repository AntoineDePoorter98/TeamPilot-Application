using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Middleware;

public class AddSimulatedTokenMiddleware
{
    private readonly RequestDelegate _next;

    public AddSimulatedTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AuthService authService, IUserRepository userRepository)
    {
        var user = await userRepository.FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception();
        }

        var token = authService.GenerateJwt(user);

        if ((string)context.Request.Headers["Authorization"]! == null)
        {
            context.Request.Headers.Add("Authorization", $"Bearer {token}");
        }

        await _next(context);
    }
}
