FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ScrimOrganizerV2/ScrimOrganizerV2.csproj", "ScrimOrganizerV2/"]
RUN dotnet restore "ScrimOrganizerV2/ScrimOrganizerV2.csproj"
COPY . .
WORKDIR "/src/ScrimOrganizerV2"
RUN dotnet build "ScrimOrganizerV2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScrimOrganizerV2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScrimOrganizerV2.dll"]