using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, CurrentUserService currentUserService, IUserRepository userRepository)
    {
        var identity = context.User.Identity as ClaimsIdentity;
        var userClaims = identity?.Claims.ToList();
        var indentityIdClaim = userClaims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value ?? "";
        var user = await userRepository.FirstOrDefaultAsync(x => x.UserId.ToString() == indentityIdClaim);

        var isProtectedRoute = context.GetEndpoint()?.Metadata?.GetMetadata<IAuthorizeData>() is object;

        if (user == null && isProtectedRoute)
        {
            throw new UnknownIdentityException("No identity specified in auth token");
        }

        if (user != null)
        {
            currentUserService.CurrentUser = user;
        }

        await _next(context);
        return;
    }
}
