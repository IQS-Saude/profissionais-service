FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app

COPY ["src/ProfissionaisService.api/*.csproj", "./src/ProfissionaisService.api/"]
COPY ["src/ProfissionaisService.application/*.csproj", "./src/ProfissionaisService.application/"]
COPY ["src/ProfissionaisService.domain/*.csproj", "./src/ProfissionaisService.domain/"]
COPY ["src/ProfissionaisService.common/*.csproj", "./src/ProfissionaisService.common/"]
COPY ["src/ProfissionaisService.infra.data/*.csproj", "./src/ProfissionaisService.infra.data/"]
COPY ["src/ProfissionaisService.infra.environment/*.csproj", "./src/ProfissionaisService.infra.environment/"]
COPY ["src/ProfissionaisService.infra.Crosscutting.IoC/*.csproj", "./src/ProfissionaisService.infra.Crosscutting.IoC/"]

RUN dotnet restore "/app/src/ProfissionaisService.api/ProfissionaisService.api.csproj"
COPY . .
WORKDIR "/app/src/ProfissionaisService.api"
RUN dotnet build "ProfissionaisService.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProfissionaisService.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfissionaisService.api.dll"]
