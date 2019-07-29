FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app
EXPOSE 80

COPY . .
RUN dotnet restore WebMvc.csproj

FROM build AS publish
RUN dotnet publish "WebMvc.csproj" -c Release -o /app

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebMvc.dll"]