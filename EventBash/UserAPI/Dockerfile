FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserAPI.dll"]