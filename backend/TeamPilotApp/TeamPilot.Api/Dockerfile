#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamPilot.Api/TeamPilot.Api.csproj", "TeamPilot.Api/"]
COPY ["TeamPilot.Application/TeamPilot.Application.csproj", "TeamPilot.Application/"]
COPY ["TeamPilot.Domain/TeamPilot.Domain.csproj", "TeamPilot.Domain/"]
COPY ["TeamPilot.Infrastructure/TeamPilot.Infrastructure.csproj", "TeamPilot.Infrastructure/"]
RUN dotnet restore "TeamPilot.Api/TeamPilot.Api.csproj"
COPY . .
WORKDIR "/src/TeamPilot.Api"
RUN dotnet build "TeamPilot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamPilot.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamPilot.Api.dll"]